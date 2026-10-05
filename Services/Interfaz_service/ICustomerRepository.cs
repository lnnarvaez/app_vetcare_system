using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.Services.Interfaz_service
{
    public interface ICustomerRepository
    {
        // Método para obtener todos los clientes
        Task<IReadOnlyList<CustomersDto>> GetAllCustomersAsync();
      
        //Método crear un nuevo cliente
        Task<int> CreateCustomerAsync(CustomerCreateDto customer);

        Task<CustomersDto?> GetCustomerByIdAsync (int customerId);

        Task UpdateCustomerAsync    (int customerId, CustomerCreateDto customer);

        //Método para eliminar un cliente por su ID
        //Task DeleteCustomerAsync (int customerId);

    } //end interface
} //end namespace