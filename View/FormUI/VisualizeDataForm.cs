using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Presenter;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.View.FormUI
{
    public partial class VisualizeDataForm : Form, IVisualizeDataView
    {
        private readonly DashboardPresenter _presenter;

        public VisualizeDataForm(IDashboardRepository repository)
        {
            InitializeComponent();

            _presenter = new DashboardPresenter(this, repository);

            Load += VisualizeDataForm_Load;
        }

        private void VisualizeDataForm_Load(object? sender, EventArgs e)
        {
            _presenter.LoadDashboard();
        }

        public void ShowDashboardSummary(DashboardSummaryDto summary)
        {
            lblTotalCustomers.Text =
                summary.TotalNewCustomers.ToString();
            lblTotalPacients.Text =
                summary.TotalNewPatients.ToString();
            lblWeeklyAppointment.Text =
                summary.WeeklyAppointments.ToString();
            lblMedicalappointment15.Text =
                summary.AppointmentsFromFirstToFifteenth.ToString();
            lblMonthlyAppointments.Text =
                summary.MonthlyAppointments.ToString();
        }

        public void ShowErrorMessage(string message)
        {
            lblTotalCustomers.Text = "0";
            lblTotalPacients.Text = "0";
            lblWeeklyAppointment.Text = "0";
            lblMedicalappointment15.Text = "0";
            lblMonthlyAppointments.Text = "0";

            MessageBox.Show(
                this,
                message,
                "Panel de indicadores",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void label2_Click(object? sender, EventArgs e)
        {
            // El indicador es informativo; no requiere una acción al hacer clic.
        }
    }
}
