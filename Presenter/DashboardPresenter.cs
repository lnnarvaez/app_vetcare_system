using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.Presenter
{
    public class DashboardPresenter
    {
        private readonly IVisualizeDataView _view;
        private readonly IDashboardRepository _repository;

        public DashboardPresenter(
            IVisualizeDataView view,
            IDashboardRepository repository)
        {
            _view = view
                ?? throw new ArgumentNullException(nameof(view));
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public void LoadDashboard()
        {
            try
            {
                DashboardSummaryDto summary =
                    _repository.GetSummary(DateTime.Now);

                _view.ShowDashboardSummary(summary);
            }
            catch (Exception)
            {
                _view.ShowErrorMessage(
                    "No fue posible cargar los indicadores del panel.");
            }
        }
    }
}
