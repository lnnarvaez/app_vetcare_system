using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.Services.Interfaz_service;

public interface IDashboardRepository
{
    Task<MonthlyDashboardDto> GetOctoberSummaryAsync(
        int year,
        CancellationToken cancellationToken = default);
}
