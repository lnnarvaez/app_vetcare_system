using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.Presenter
{
    public class CustomerPresenter
    {
        private readonly ICustomerView _view;
        private readonly ICustomerRepository _repository;

        public CustomerPresenter(ICustomerView view, ICustomerRepository repository)
        {
            _view = view;
            _repository = repository;
        }

        public void LoadCustomers()
        {
            try
            {
                var customers = _repository
                    .GetAllCustomers()
                    .ToList();

                if (!customers.Any())
                {
                    _view.ShowNoRecords();
                    return;
                }

                _view.ShowCustomers(customers);
            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage(ex.Message);
            }
        } //end LoadCustomers

    } //end class
} //end namespace
