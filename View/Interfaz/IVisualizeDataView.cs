using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.View.Interfaz
{
    public interface IVisualizeDataView
    {
        void ShowDashboardSummary(DashboardSummaryDto summary);

        void ShowErrorMessage(string message);
    }
}
