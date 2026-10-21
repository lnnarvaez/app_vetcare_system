namespace app_vetcare_system.Models.DTOs
{
    public class DashboardSummaryDto
    {
        public int TotalNewCustomers { get; set; }

        public int TotalNewPatients { get; set; }

        public int WeeklyAppointments { get; set; }

        public int AppointmentsFromFirstToFifteenth { get; set; }

        public int MonthlyAppointments { get; set; }
    }
}
