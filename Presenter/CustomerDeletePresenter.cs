using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.Presenter
{
    public class CustomerDeletePresenter
    {
        private readonly ICustomerDeleteView _view;
        private readonly ICustomerRepository _repository;

        public CustomerDeletePresenter(
            ICustomerDeleteView view,
            ICustomerRepository repository)
        {
            _view = view
                ?? throw new ArgumentNullException(nameof(view));

            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Solicita al repositorio desactivar lógicamente al cliente.
        /// </summary>
        public void DeleteCustomer(CustomerDeleteDto customer)
        {
            try
            {
                if (customer is null)
                {
                    throw new ArgumentNullException(nameof(customer));
                }

                _repository.DeleteCustomer(customer.CustomerId);

                _view.ShowMessage(
                    "El cliente fue desactivado correctamente.");

                _view.CloseView();
            }
            catch (Exception)
            {
                _view.ShowMessage(
                    "No fue posible desactivar el cliente.");
            }
        }
    }
}
