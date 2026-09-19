namespace app_vetcare_system.Models.DTOs
{
    public class CustomerCreateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public string MainPhone { get; set; } = string.Empty;
        public string? EmergencyPhone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PreferredPaymentMethod { get; set; }

    } //end class
} //end namespace
