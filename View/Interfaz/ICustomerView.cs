using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.View.Interfaz
{
    public interface ICustomerView
    {
        void ShowCustomers(IEnumerable<CustomersDto> customer);
        void ShowNoRecords(); // Metodo que mostrara un mensaje cuando no haya registros
        void ShowErrorMessage(string mensaje);
        

    } // End interface
} // End namespace
