using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.Services.Interfaz_service
{
    public interface ICustomerRepository
    {
        // Método para obtener todos los clientes
        IEnumerable<CustomersDto> GetAllCustomers();

        //Método crear un nuevo cliente
        int CreateCustomer(CustomerCreateDto customer);

    } //end interface
} //end namespace