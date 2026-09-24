using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.Presenter
{
    public class CustomerEditPresenter
    {
        private readonly ICustomerEditView _view;
        private readonly ICustomerRepository _repository;
        private readonly int _customerId;

        public CustomerEditPresenter(ICustomerEditView view, 
                                     ICustomerRepository repository,
                                     int customerId)
        {
            _view = view
                    ?? throw new ArgumentNullException(nameof(view));

            _repository = repository
                        ?? throw new ArgumentNullException(nameof(repository));
            //Prevenir que no se pueda editar un cliente con un Id inválido (0 o negativo)
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id del cliente no es válido.");
            }

            _customerId = customerId;
        }

        /// <summary>
        /// Consulta el cliente y envía sus datos a la vista.
        /// </summary>
        public void LoadCustomer()
        {
            try
            {
                CustomersDto? customer =
                    _repository.GetCustomerById(_customerId);

                _view.ShowCustomer(customer);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"No fue posible cargar el cliente: {ex}");
            }
        }

        /// <summary>
        /// Obtiene los valores de la vista y solicita al repositorio actualizar el cliente.
        /// </summary>
        public void SaveChanges()
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

                _repository.UpdateCustomer(_customerId, customer);

                _view.ShowMessage(
                    "Cliente actualizado correctamente.");

                //_view.CloseView();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"No fue posible guardar los cambios: {ex}");
            }

        }



    } // end class
} // end namespace
