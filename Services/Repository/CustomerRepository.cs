using System.Text.Json;
using System.Diagnostics;
using app_vetcare_si.Data;
using app_vetcare_si.Models.Entities;
using app_vetcare_system.Data.DbSqlite;
using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using SqliteCustomer = app_vetcare_system.Data.DbSqlite.Entities.Cliente;
using SqliteOperation = app_vetcare_system.Data.DbSqlite.Entities.ColaOperacione;
using SqliteKeyMapping = app_vetcare_system.Data.DbSqlite.Entities.MapeoClavesSincronizacion;

namespace app_vetcare_system.Services.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly VetCareDbSI2VContext _context;
        private readonly VetCareSqliteContext? _sqliteContext;

        public CustomerRepository(
            VetCareDbSI2VContext context,
            VetCareSqliteContext? sqliteContext = null)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
            _sqliteContext = sqliteContext;
        }

        /// <summary>
        /// Obtiene todos los clientes de la base de datos y los mapea a objetos CustomersDto
        /// </summary>
        /// <returns>Una lista de objetos CustomersDto</returns>
        public async Task<IReadOnlyList<CustomersDto>> GetAllCustomersAsync()
        {
            try
            {
                // Los clientes inactivos se excluyen para respetar el borrado lógico.
                return await _context.Clientes
                    .AsNoTracking()
                    .Where(cliente => cliente.EstaActivo)
                    .Select(c => new CustomersDto
                    {
                        Id = c.ClienteId,
                        FirstName = c.Nombre,
                        LastName = c.Apellido,
                        NationalId = c.Cedula,
                        MainPhone = c.TelefonoPrincipal,
                        EmergencyPhone = c.TelefonoEmergencia,
                        Address = c.Direccion,
                        Email = c.CorreoElectronico
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("No fue posible obtener los clientes.", ex);
            }
        }

        /// <summary>
        /// Crea un nuevo cliente en la base de datos a partir de un objeto CustomerCreateDto
        /// </summary>
        /// <param name="customer">El objeto CustomerCreateDto que contiene la información del cliente a crear</param>
        /// <returns>El Id del cliente creado</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el objeto CustomerCreateDto es nulo</exception>
        /// <exception cref="InvalidOperationException">Se lanza si ocurre un error al crear el cliente</exception>
        public async Task<int> CreateCustomerAsync(CustomerCreateDto customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(
                    "Información del cliente es vacía.");
            }

            try
            {
                var entity = new Cliente
                {
                    Nombre = customer.FirstName,
                    Apellido = customer.LastName,
                    Cedula = customer.NationalId,
                    TelefonoPrincipal = customer.MainPhone,
                    TelefonoEmergencia = customer.EmergencyPhone,
                    Direccion = customer.Address,
                    CorreoElectronico = customer.Email,
                    MetodoPagoPreferido =
                        customer.PreferredPaymentMethod,
                    //EstaActivo = true
                };

                _context.Clientes.Add(entity);

                await _context.SaveChangesAsync();

                return entity.ClienteId;
            }
            catch (Exception ex) when (IsConnectionFailure(ex))
            {
                Debug.WriteLine(
                    $"SQL Server no está disponible; se intentará SQLite: {ex}");

                // Evita conservar en el contexto SQL Server una entidad cuyo guardado falló.
                foreach (var entry in _context.ChangeTracker.Entries<Cliente>().ToList())
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.State = EntityState.Detached;
                    }
                }

                if (_sqliteContext is null)
                {
                    throw new InvalidOperationException(
                        "Error al crear el cliente.",
                        ex);
                }

                return await CreateCustomerLocallyAsync(customer, ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Error al crear el cliente.",
                    ex);
            } //End try-catch
        } //end CreateCustomer

        private async Task<int> CreateCustomerLocallyAsync(
            CustomerCreateDto customer,
            Exception serverException)
        {
            try
            {
                await using var transaction =
                    await _sqliteContext!.Database.BeginTransactionAsync();

                var localCustomer = new SqliteCustomer
                {
                    Nombre = customer.FirstName,
                    Apellido = customer.LastName,
                    Cedula = customer.NationalId,
                    TelefonoPrincipal = customer.MainPhone,
                    TelefonoEmergencia = customer.EmergencyPhone,
                    Direccion = customer.Address,
                    CorreoElectronico = customer.Email,
                    MetodoPagoPreferido = customer.PreferredPaymentMethod,
                    EstaActivo = 1
                };

                _sqliteContext.Clientes.Add(localCustomer);
                await _sqliteContext.SaveChangesAsync();

                string operationId = Guid.NewGuid().ToString("N");
                string localKey = localCustomer.ClienteId.ToString();
                string payload = JsonSerializer.Serialize(customer);

                var queuedOperation = new SqliteOperation
                {
                    OperacionId = operationId,
                    ClaveIdempotencia = operationId,
                    NombreEntidad = "Clientes",
                    Accion = "INSERTAR",
                    IdentificadorEntidad = localKey,
                    PayloadJson = payload,
                    Estado = "PENDIENTE",
                    Intentos = 0
                };

                var keyMapping = new SqliteKeyMapping
                {
                    NombreEntidad = "Clientes",
                    ClaveLocal = localKey,
                    OperacionId = operationId,
                    Estado = "PENDIENTE",
                    Operacion = queuedOperation
                };

                queuedOperation.MapeoClavesSincronizacion = keyMapping;
                _sqliteContext.ColaOperaciones.Add(queuedOperation);
                await _sqliteContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return localCustomer.ClienteId;
            }
            catch (Exception localException)
            {
                Debug.WriteLine(
                    $"Fallback SQLite de clientes falló: {localException}");

                throw new InvalidOperationException(
                    "No fue posible guardar el cliente localmente después de perder la conexión con SQL Server.",
                    new AggregateException(serverException, localException));
            }
        }

        private static bool IsConnectionFailure(Exception exception)
        {
            for (Exception? current = exception;
                 current is not null;
                 current = current.InnerException)
            {
                if (current is TimeoutException)
                {
                    return true;
                }

                if (current is SqlException sqlException)
                {
                    if (sqlException.Errors.Cast<SqlError>().Any(error =>
                            error.Number is 0 or -2 or 53 or 64 or 233 or
                            10053 or 10054 or 10060 or 11001))
                    {
                        return true;
                    }

                    return sqlException.Message.Contains(
                               "network-related",
                               StringComparison.OrdinalIgnoreCase) ||
                           sqlException.Message.Contains(
                               "server-specific",
                               StringComparison.OrdinalIgnoreCase) ||
                           sqlException.Message.Contains(
                               "error occurred while establishing a connection",
                               StringComparison.OrdinalIgnoreCase);
                }
            }

            return false;
        }

        /// <summary>
        /// Obtiene un cliente por su Id y lo mapea a un objeto CustomersDto
        /// </summary>
        /// <param name="customerId">El Id del cliente a obtener</param>
        /// <returns>Un objeto CustomersDto si se encuentra el cliente, de lo contrario null</returns>
        /// <exception cref="ArgumentOutOfRangeException"> El Id del cliente no es válido </exception>
        /// <exception cref="InvalidOperationException"> No fue posible consultar el cliente </exception>
        public async Task<CustomersDto?> GetCustomerByIdAsync(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Identificador del cliente no es válido.");
            }

            try
            {
                return await _context.Clientes
                    .AsNoTracking()
                    .Where(cliente =>
                        cliente.ClienteId == customerId &&
                        cliente.EstaActivo)
                    .Select(cliente => new CustomersDto
                    {
                        Id = cliente.ClienteId,
                        FirstName = cliente.Nombre,
                        LastName = cliente.Apellido,
                        NationalId = cliente.Cedula,
                        MainPhone = cliente.TelefonoPrincipal,
                        EmergencyPhone = cliente.TelefonoEmergencia,
                        Address = cliente.Direccion,
                        Email = cliente.CorreoElectronico,
                        PreferredPaymentMethod = cliente.MetodoPagoPreferido
                    })
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("No fue posible consultar el cliente.",
                    ex);
            }//end try-catch
        }

        /// <summary>
        /// Actualiza la información de un cliente existente en la base de datos
        /// </summary>
        /// <param name="customerId">El Id del cliente a actualizar</param>
        /// <param name="customer">Los datos del cliente a actualizar</param>
        /// <exception cref="ArgumentOutOfRangeException"> El Id del cliente no es válido </exception>
        /// <exception cref="ArgumentNullException"> Los datos del cliente son nulos </exception>
        /// <exception cref="InvalidOperationException"> No fue posible actualizar el cliente </exception>
        public async Task UpdateCustomerAsync(int customerId, CustomerCreateDto customer)
        {
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Identificador del cliente no es válido.");
            }

            if (customer is null)
            {
                throw new ArgumentNullException("El cliente no existe.");
            }

            try
            {
                var entity = await _context.Clientes
                    .SingleOrDefaultAsync(cliente =>
                        cliente.ClienteId == customerId);

                if (entity is null)
                {
                    throw new InvalidOperationException("El cliente no se coincide con el especificado.");
                }

                entity.Nombre = customer.FirstName;
                entity.Apellido = customer.LastName;
                entity.Cedula = customer.NationalId;
                entity.TelefonoPrincipal = customer.MainPhone;
                entity.TelefonoEmergencia =
                    customer.EmergencyPhone;
                entity.Direccion = customer.Address;
                entity.CorreoElectronico =
                    customer.Email;
                entity.MetodoPagoPreferido =
                    customer.PreferredPaymentMethod;
                entity.FechaActualizacion = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("No fue posible actualizar el cliente.",
                    ex);
            }
        }

        /// <summary>
        /// Desactiva lógicamente un cliente sin eliminarlo de la base de datos.
        /// </summary>
        /// <param name="customerId">El Id del cliente a desactivar</param>
        /// <exception cref="ArgumentOutOfRangeException">El Id no es válido</exception>
        /// <exception cref="InvalidOperationException">No fue posible desactivar el cliente</exception>
        public async Task DeleteCustomerAsync(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(customerId),
                    "El Id del cliente no es válido.");
            }

            try
            {
                var entity = await _context.Clientes
                    .SingleOrDefaultAsync(cliente =>
                        cliente.ClienteId == customerId &&
                        cliente.EstaActivo);

                if (entity is null)
                {
                    throw new InvalidOperationException(
                        "El cliente no existe o ya está inactivo.");
                }

                entity.EstaActivo = false;
                entity.FechaActualizacion = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "No fue posible desactivar el cliente.",
                    ex);
            }
        }


    } //end class
} //end namespace
