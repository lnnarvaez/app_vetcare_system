using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.Services.Interfaz_service
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomersDto> GetAllCustomers();
    } //end interface
} //end namespace