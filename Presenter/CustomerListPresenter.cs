using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.Presenter
{
    /// <summary>
    /// Presenter responsable exclusivamente de la pantalla de listado de clientes.
    /// </summary>
    public class CustomerListPresenter
    {
        private readonly ICustomerListView _view;
        private readonly ICustomerRepository _repository;                

        public CustomerListPresenter(ICustomerListView view, ICustomerRepository repository)
        {
            _view = view
               ?? throw new ArgumentNullException(nameof(view));

            _repository = repository
               ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Obtiene los clientes desde el repositorio y solicita a la Vista que los muestre.
        /// </summary>
        public void LoadCustomers()
        {
            try
            {
                var customers =
                    _repository
                        .GetAllCustomers()
                        .ToList();

                if (customers.Count == 0)
                {
                    _view.ShowNoRecords();
                    return;
                }

                _view.ShowCustomers(customers);
            }
            catch (Exception ex)
            {
                // No exponemos detalles internos de la BD directamente al usuario.
                _view.ShowErrorMessage("No fue posible cargar la lista de clientes.");
            }
        } //end LoadCustomers
        
    } //end class
} //end namespace
