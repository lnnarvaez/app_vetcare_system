namespace app_vetcare_system.Models.DTOs
{
    public class UserAuthenticationDataDto
    {
        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        public IReadOnlyCollection<string> Roles { get; set; } =
            Array.Empty<string>();
    }
}
