using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.FormUI;

namespace app_vetcare_system.Presenter;

public sealed class DashboardPresenter
{
    private readonly VisualiceDataForm _view;
    private readonly IDashboardRepository _repository;

    public DashboardPresenter(
        VisualiceDataForm view,
        IDashboardRepository repository)
    {
        _view = view
            ?? throw new ArgumentNullException(nameof(view));
        _repository = repository
            ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task LoadOctoberSummaryAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            MonthlyDashboardDto summary =
                await _repository.GetOctoberSummaryAsync(
                    DateTime.Now.Year,
                    cancellationToken);

            _view.ShowOctoberSummary(summary);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception)
        {
            _view.ShowDashboardError(
                "No fue posible cargar los totales de octubre.");
        }
    }
}
