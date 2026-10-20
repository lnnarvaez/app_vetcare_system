using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using app_vetcare_si.Data;
using app_vetcare_si.Models.Entities;
using app_vetcare_system.Data.DbSqlite;
using app_vetcare_system.Models.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SqlServerCliente = app_vetcare_si.Models.Entities.Cliente;
using SqliteOperation = app_vetcare_system.Data.DbSqlite.Entities.ColaOperacione;

namespace app_vetcare_system.Services;

/// <summary>
/// Envía a SQL Server las inserciones de clientes que quedaron pendientes en SQLite.
/// </summary>
public sealed class CustomerSynchronizationService
{
    private static readonly TimeSpan RetryDelay = TimeSpan.FromMinutes(1);
    private readonly SemaphoreSlim _executionLock = new(1, 1);

    public async Task SynchronizePendingCustomersAsync(
        CancellationToken cancellationToken = default)
    {
        if (!await _executionLock.WaitAsync(0, cancellationToken))
        {
            return;
        }

        try
        {
            await RecoverInterruptedOperationsAsync(cancellationToken);

            while (!cancellationToken.IsCancellationRequested)
            {
                bool synchronized =
                    await SynchronizeNextCustomerAsync(cancellationToken);

                if (!synchronized)
                {
                    return;
                }
            }
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Sincronización de clientes falló: {ex}");
        }
        finally
        {
            _executionLock.Release();
        }
    }

    private async Task<bool> SynchronizeNextCustomerAsync(
        CancellationToken cancellationToken)
    {
        await using var sqliteContext = CreateSqliteContext();
        string now = UtcText(DateTime.UtcNow);

        var operations = await sqliteContext.ColaOperaciones
            .Include(item => item.MapeoClavesSincronizacion)
            .Where(item =>
                item.NombreEntidad == "Clientes" &&
                item.Accion == "INSERTAR" &&
                (item.Estado == "PENDIENTE" || item.Estado == "REINTENTAR"))
            .OrderBy(item => item.Secuencia)
            .ToListAsync(cancellationToken);

        var operation = operations.FirstOrDefault(item =>
            item.ProximoIntentoUtc is null ||
            string.CompareOrdinal(item.ProximoIntentoUtc, now) <= 0);

        if (operation is null)
        {
            return false;
        }

        operation.Estado = "EN_PROCESO";
        operation.Intentos++;
        operation.UltimoIntentoUtc = now;
        operation.UltimoError = null;
        await sqliteContext.SaveChangesAsync(cancellationToken);

        try
        {
            var customer = JsonSerializer.Deserialize<CustomerCreateDto>(
                operation.PayloadJson)
                ?? throw new InvalidOperationException(
                    "El payload del cliente está vacío o no es válido.");

            int serverCustomerId = await InsertOrFindCustomerAsync(
                customer,
                cancellationToken);

            if (operation.MapeoClavesSincronizacion is null)
            {
                throw new InvalidOperationException(
                    "La operación no tiene un mapeo de clave local.");
            }

            operation.MapeoClavesSincronizacion.ClaveServidor =
                serverCustomerId.ToString(CultureInfo.InvariantCulture);
            operation.MapeoClavesSincronizacion.Estado = "CONFIRMADA";
            operation.MapeoClavesSincronizacion.ConfirmadaUtc =
                UtcText(DateTime.UtcNow);
            operation.Estado = "CONFIRMADA";
            operation.ConfirmadaUtc = UtcText(DateTime.UtcNow);
            operation.ProximoIntentoUtc = null;

            await sqliteContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex) when (IsTransientSqlFailure(ex))
        {
            operation.Estado = "REINTENTAR";
            operation.ProximoIntentoUtc =
                UtcText(DateTime.UtcNow.Add(RetryDelay));
            operation.UltimoError = ex.Message;
            await sqliteContext.SaveChangesAsync(cancellationToken);
            Debug.WriteLine($"Cliente pendiente de reintento: {ex}");
            return false;
        }
        catch (Exception ex)
        {
            operation.Estado = "ERROR_PERMANENTE";
            operation.UltimoError = ex.Message;
            operation.ProximoIntentoUtc = null;
            await sqliteContext.SaveChangesAsync(cancellationToken);
            Debug.WriteLine($"Cliente no sincronizable: {ex}");
            return true;
        }
    }

    private static async Task<int> InsertOrFindCustomerAsync(
        CustomerCreateDto customer,
        CancellationToken cancellationToken)
    {
        await using var sqlContext = new VetCareDbSI2VContext();

        if (string.IsNullOrWhiteSpace(customer.NationalId))
        {
            throw new InvalidOperationException(
                "No se puede sincronizar un cliente sin cédula.");
        }

        SqlServerCliente? existingCustomer = await sqlContext.Clientes
            .SingleOrDefaultAsync(
                item => item.Cedula == customer.NationalId && item.EstaActivo,
                cancellationToken);

        if (existingCustomer is not null)
        {
            return existingCustomer.ClienteId;
        }

        var entity = new SqlServerCliente
        {
            Nombre = customer.FirstName,
            Apellido = customer.LastName,
            Cedula = customer.NationalId,
            TelefonoPrincipal = customer.MainPhone,
            TelefonoEmergencia = customer.EmergencyPhone,
            Direccion = customer.Address,
            CorreoElectronico = customer.Email,
            MetodoPagoPreferido = customer.PreferredPaymentMethod
        };

        sqlContext.Clientes.Add(entity);
        await sqlContext.SaveChangesAsync(cancellationToken);
        return entity.ClienteId;
    }

    private static async Task RecoverInterruptedOperationsAsync(
        CancellationToken cancellationToken)
    {
        await using var sqliteContext = CreateSqliteContext();
        var interruptedOperations = await sqliteContext.ColaOperaciones
            .Where(item =>
                item.NombreEntidad == "Clientes" &&
                item.Accion == "INSERTAR" &&
                item.Estado == "EN_PROCESO")
            .ToListAsync(cancellationToken);

        if (interruptedOperations.Count == 0)
        {
            return;
        }

        foreach (var operation in interruptedOperations)
        {
            operation.Estado = "REINTENTAR";
            operation.ProximoIntentoUtc = UtcText(DateTime.UtcNow);
            operation.UltimoError =
                "La operación quedó interrumpida y será reintentada.";
        }

        await sqliteContext.SaveChangesAsync(cancellationToken);
    }

    private static VetCareSqliteContext CreateSqliteContext()
    {
        string databasePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Data",
            "DbSqlite",
            "VetCareLocal.db");

        var options = new DbContextOptionsBuilder<VetCareSqliteContext>()
            .UseSqlite($"Data Source={databasePath}")
            .Options;

        return new VetCareSqliteContext(options);
    }

    private static string UtcText(DateTime value)
    {
        return value.ToUniversalTime().ToString(
            "yyyy-MM-dd'T'HH:mm:ss.fff'Z'",
            CultureInfo.InvariantCulture);
    }

    private static bool IsTransientSqlFailure(Exception exception)
    {
        for (Exception? current = exception;
             current is not null;
             current = current.InnerException)
        {
            if (current is TimeoutException)
            {
                return true;
            }

            if (current is SqlException)
            {
                return true;
            }
        }

        return false;
    }
}
