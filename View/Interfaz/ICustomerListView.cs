using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.View.Interfaz
{
    public interface ICustomerListView
    {
        /// <summary>
        /// Notifica que el usuario desea registrar un nuevo cliente.
        /// </summary>
        event EventHandler NewCustomerRequested;

        /// <summary>
        /// Muestra la lista de clientes.
        /// </summary>
        void ShowCustomers(IEnumerable<CustomersDto> customers);

        /// <summary>
        /// Muestra un mensaje cuando no existen clientes.
        /// </summary>
        void ShowNoRecords();

        /// <summary>
        /// Muestra un mensaje de error.
        /// </summary>
        void ShowErrorMessage(string mensaje);

    } // End interface
} // End namespace
