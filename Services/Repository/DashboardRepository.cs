using app_vetcare_si.Data;
using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using Microsoft.EntityFrameworkCore;

namespace app_vetcare_system.Services.Repository;

public sealed class DashboardRepository : IDashboardRepository
{
    private readonly VetCareDbSI2VContext _context;

    public DashboardRepository(VetCareDbSI2VContext context)
    {
        _context = context
            ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<MonthlyDashboardDto> GetOctoberSummaryAsync(
        int year,
        CancellationToken cancellationToken = default)
    {
        DateTime startDate = new(year, 10, 1);
        DateTime endDate = startDate.AddMonths(1);

        try
        {
            // El límite superior exclusivo evita depender de la hora exacta del último día.
            int newClients = await _context.Clientes
                .AsNoTracking()
                .CountAsync(customer =>
                    customer.EstaActivo &&
                    customer.FechaCreacion >= startDate &&
                    customer.FechaCreacion < endDate,
                    cancellationToken);

            int newPatients = await _context.Pacientes
                .AsNoTracking()
                .CountAsync(patient =>
                    patient.EstaActivo &&
                    patient.FechaCreacion >= startDate &&
                    patient.FechaCreacion < endDate,
                    cancellationToken);

            return new MonthlyDashboardDto
            {
                NewClients = newClients,
                NewPatients = newPatients
            };
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                "No fue posible cargar los totales de octubre.",
                ex);
        }
    }
}
