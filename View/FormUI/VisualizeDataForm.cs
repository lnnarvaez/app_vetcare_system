using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Presenter;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;
using ScottPlot;

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

            RenderAppointmentsByStatus(summary.AppointmentsByStatus);
        }

        public void ShowErrorMessage(string message)
        {
            lblTotalCustomers.Text = "0";
            lblTotalPacients.Text = "0";
            lblWeeklyAppointment.Text = "0";
            lblMedicalappointment15.Text = "0";
            lblMonthlyAppointments.Text = "0";
            RenderAppointmentsByStatus(
                Array.Empty<DashboardAppointmentStatusDto>());

            MessageBox.Show(
                this,
                message,
                "Panel de indicadores",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void RenderAppointmentsByStatus(
            IReadOnlyCollection<DashboardAppointmentStatusDto> appointments)
        {
            // El control gráfico ya pertenece al diseñador; aquí solo se actualizan sus datos.
            frmBarsAppointmentStatus.Plot.Clear();

            if (appointments.Count == 0)
            {
                frmBarsAppointmentStatus.Refresh();
                return;
            }

            double[] values = appointments
                .Select(appointment => (double)appointment.Total)
                .ToArray();
            string[] labels = appointments
                .Select(appointment => appointment.StatusName)
                .ToArray();

            var bars = frmBarsAppointmentStatus.Plot.Add.Bars(values);
            bars.Color = Colors.SteelBlue;

            var tickGenerator =
                new ScottPlot.TickGenerators.NumericManual();

            for (int index = 0; index < labels.Length; index++)
            {
                tickGenerator.AddMajor(index, labels[index]);
            }

            frmBarsAppointmentStatus.Plot.Axes.Bottom.TickGenerator =
                tickGenerator;
            frmBarsAppointmentStatus.Plot.Axes.Margins(bottom: 0);
            frmBarsAppointmentStatus.Plot.Axes.SetLimitsY(
                0,
                Math.Max(1, values.Max() * 1.1));
            frmBarsAppointmentStatus.Plot.Title("Citas por estado");
            frmBarsAppointmentStatus.Refresh();
        }
    }
}
