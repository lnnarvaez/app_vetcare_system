using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.Services.Interfaz_service
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<CustomersDto>> GetAllCustomersAsync();

        Task<int> CreateCustomerAsync(CustomerCreateDto customer);

        Task<CustomersDto?> GetCustomerByIdAsync(int customerId);

        Task UpdateCustomerAsync(int customerId, CustomerCreateDto customer);

        Task DeleteCustomerAsync(int customerId);

    } //end interface
} //end namespace
