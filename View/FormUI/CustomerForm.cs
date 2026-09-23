using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Presenter;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.View.FormUI
{
    public partial class CustomerForm : Form, ICreateCustomerView
    {
        private readonly CustomerCreatePresenter _presenter;

        public CustomerForm(ICustomerRepository repository)
        {
            InitializeComponent();

            _presenter = new CustomerCreatePresenter(this, repository);
        }

        #region Implementación de ICustomerView
        public string FirstName => txtName.Text.Trim();

        public string LastName => txtSurname.Text.Trim();

        public string NationalId => mskCedula.Text.Trim();

        public string MainPhone => mskMainPhone.Text.Trim();

        public string? EmergencyPhone => mskAlternPhone.Text.Trim();

        public string? Address => txtAddress.Text.Trim();

        public string? Email => txtEmail.Text.Trim();

        public string? PreferredPaymentMethod => mskPreferredPay.SelectedItem?.ToString();

        #endregion Implementación de ICustomerView

        public void ClearCustomerForm()
        {
            txtName.Clear();
            txtSurname.Clear();
            mskCedula.Clear();
            mskMainPhone.Clear();
            mskAlternPhone.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            mskPreferredPay.SelectedIndex = -1;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            } //end if

            _presenter.CreateCustomer();
        }
        public void ShowMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                e.Cancel = true; // Cancela el evento, evita que el control pierda el foco
                errorProvider1.SetError(txtName, "El nombre del cliente es necesario.");
            } //end if
            else
            {
                e.Cancel = false; // Permite que el control pierda el foco
                errorProvider1.SetError(txtName, string.Empty);
            }

        }
        private void txtSurname_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Validar si el campo de apellido está vacío
            if (string.IsNullOrWhiteSpace(LastName))
            {
                e.Cancel = true; // Cancela el evento, evita que el control pierda el foco
                errorProvider1.SetError(txtSurname, "El apellido del cliente es necesario.");
            } //end if
            else
            {
                e.Cancel = false; // Permite que el control pierda el foco
                errorProvider1.SetError(txtSurname, string.Empty);
            }
        }

        private void txtAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Verificar que se tenga un valor en el campo de dirección
            if (string.IsNullOrWhiteSpace(Address))
            {
                e.Cancel = true; // Cancela el evento, evita que el control pierda el foco
                errorProvider1.SetError(txtAddress, "La dirección del cliente es necesaria.");
            } //end if
            else
            {
                e.Cancel = false; // Permite que el control pierda el foco
                errorProvider1.SetError(txtAddress, string.Empty);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Dispose(); //Cerrar el formulario y liberar recursos
        }
    } //end class
} //end namespace
