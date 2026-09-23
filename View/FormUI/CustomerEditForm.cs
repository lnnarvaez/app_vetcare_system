using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Presenter;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.View.FormUI
{
    public partial class CustomerEditForm : Form, ICustomerEditView
    {
        private readonly CustomerEditPresenter _presenter;
        
        public CustomerEditForm(ICustomerRepository repository, int customerId)
        {
            InitializeComponent();

            _presenter = new CustomerEditPresenter(this, repository, customerId);

            Load += CustomerEditForm_Load;
        }

        private void CustomerEditForm_Load(object? sender, EventArgs e)
        {
            _presenter.LoadCustomer();
        }

        /// <summary>
        /// Cargar información del cliente en los controles de la vista.
        /// </summary>
        /// <param name="customer"></param>
        public void ShowCustomer(CustomersDto customer)
        {
            txtName.Text = customer.FirstName;
            txtSurname.Text = customer.LastName;
            mskNationalId.Text = customer.NationalId;
            mskMainPhone.Text = customer.MainPhone;
            mskAlternPhone.Text = customer.EmergencyPhone;
            txtAddress.Text = customer.Address;
            txtEmail.Text = customer.Email;
            cmbPayMethod.SelectedItem = customer.PreferredPaymentMethod;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            // El formulario no actualiza directamente. La operación la coordina el Presenter. 
            _presenter.SaveChanges();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Implementar ICustomerEditView
        public string FirstName => txtName.Text.Trim();

        public string LastName => txtSurname.Text.Trim();

        public string NationalId => mskNationalId.Text.Trim();

        public string MainPhone => mskMainPhone.Text.Trim();

        public string? EmergencyPhone => mskAlternPhone.Text.Trim();

        public string? Address => txtAddress.Text.Trim();

        public string? Email => txtEmail.Text.Trim();

        public string? PreferredPaymentMethod => cmbPayMethod.SelectedItem?.ToString();

        #endregion

    } // end of class
} // end of namespace
