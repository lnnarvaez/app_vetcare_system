namespace app_vetcare_system.Models.DTOs
{
    public class CustomersDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName  { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public string MainPhone { get; set; } = string.Empty;
        public string EmergencyPhone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PreferredPaymentMethod { get; set; } = string.Empty;

        //Definir una propiedad calculada para obtener el nombre completo del cliente
        public string FullName => $"{FirstName} {LastName}";
        
    } // End class
} // End namespace
