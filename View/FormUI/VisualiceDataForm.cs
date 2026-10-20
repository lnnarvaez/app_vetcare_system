using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Presenter;
using app_vetcare_system.Services.Interfaz_service;

namespace app_vetcare_system.View.FormUI
{
    public partial class VisualiceDataForm : Form
    {
        private readonly DashboardPresenter _presenter;

        public VisualiceDataForm(IDashboardRepository repository)
        {
            InitializeComponent();
            _presenter = new DashboardPresenter(this, repository);
            Load += VisualiceDataForm_Load;
        }

        public void ShowOctoberSummary(MonthlyDashboardDto summary)
        {
            lblNewClients.Text = summary.NewClients.ToString();
            lblNewPatients.Text = summary.NewPatients.ToString();
        }

        public void ShowDashboardError(string message)
        {
            MessageBox.Show(
                this,
                message,
                "Dashboard",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private async void VisualiceDataForm_Load(
            object? sender,
            EventArgs e)
        {
            await _presenter.LoadOctoberSummaryAsync();
        }
    }
}
