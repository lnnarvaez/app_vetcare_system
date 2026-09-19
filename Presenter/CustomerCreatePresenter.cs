using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.Presenter
{
    /// <summary>
    /// Presenter encargado exclusivamente de registrar clientes.
    /// </summary>
    public class CustomerCreatePresenter
    {
        private readonly ICreateCustomerView _view;
        private readonly ICustomerRepository _repository;

        public CustomerCreatePresenter(ICreateCustomerView view, ICustomerRepository repository)
        {
            _view = view
                ?? throw new ArgumentNullException(nameof(view));

            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Captura los datos de la Vista y solicita al repositorio registrar el cliente.
        /// </summary>
        public void CreateCustomer()
        {
            try
            {
                var customer = new CustomerCreateDto
                {
                    FirstName = _view.FirstName,
                    LastName = _view.LastName,
                    NationalId = _view.NationalId,
                    MainPhone = _view.MainPhone,
                    EmergencyPhone = _view.EmergencyPhone,
                    Address = _view.Address,
                    Email = _view.Email,
                    PreferredPaymentMethod = _view.PreferredPaymentMethod
                };

                _repository.CreateCustomer(customer);

                _view.ShowMessage("El cliente fue registrado correctamente.");

                _view.ClearCustomerForm();
            }
            catch (Exception)
            {
                _view.ShowMessage("No fue posible registrar el cliente.");
            }
        }

    } // end class
} // end namespace
