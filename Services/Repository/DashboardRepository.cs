using app_vetcare_si.Data;
using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;

namespace app_vetcare_system.Services.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly VetCareDbSI2VContext _context;

        public DashboardRepository(VetCareDbSI2VContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public DashboardSummaryDto GetSummary(DateTime referenceDate)
        {
            DateTime monthStart = new DateTime(
                referenceDate.Year,
                referenceDate.Month,
                1);
            DateTime nextMonthStart = monthStart.AddMonths(1);

            DateTime currentDate = referenceDate.Date;
            int daysFromSunday = (int)currentDate.DayOfWeek;
            DateTime weekStart = currentDate.AddDays(-daysFromSunday);
            DateTime nextWeekStart = weekStart.AddDays(7);
            DateTime fifteenthStart = new DateTime(
                referenceDate.Year,
                referenceDate.Month,
                15).AddDays(1);
            DateTime firstToFifteenthStart = monthStart;

            int totalNewCustomers = _context.Clientes.Count(cliente =>
                cliente.FechaCreacion >= monthStart &&
                cliente.FechaCreacion < nextMonthStart);

            int totalNewPatients = _context.Pacientes.Count(paciente =>
                paciente.FechaCreacion >= monthStart &&
                paciente.FechaCreacion < nextMonthStart);

            int weeklyAppointments = _context.Citas.Count(cita =>
                cita.FechaHoraInicioProgramada >= weekStart &&
                cita.FechaHoraInicioProgramada < nextWeekStart);

            int appointmentsFromFirstToFifteenth = _context.Citas.Count(cita =>
                cita.FechaHoraInicioProgramada >= firstToFifteenthStart &&
                cita.FechaHoraInicioProgramada < fifteenthStart);

            int monthlyAppointments = _context.Citas.Count(cita =>
                cita.FechaHoraInicioProgramada >= monthStart &&
                cita.FechaHoraInicioProgramada < nextMonthStart);

            return new DashboardSummaryDto
            {
                TotalNewCustomers = totalNewCustomers,
                TotalNewPatients = totalNewPatients,
                WeeklyAppointments = weeklyAppointments,
                AppointmentsFromFirstToFifteenth =
                    appointmentsFromFirstToFifteenth,
                MonthlyAppointments = monthlyAppointments
            };
        }
    }
}
