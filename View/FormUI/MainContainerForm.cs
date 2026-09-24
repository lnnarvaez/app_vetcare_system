using app_vetcare_si.Data;
using app_vetcare_system.Services;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View;
using app_vetcare_system.View.FormUI;

namespace app_vetcare_system
{
    public partial class MainContainerForm : Form
    {
        private readonly VetCareDbSI2VContext _context;

        public MainContainerForm()
        {
            InitializeComponent();
            _context = new VetCareDbSI2VContext();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _context.Dispose();

            Dispose();
        }

        /// <summary>
        /// Cargar un formulario hijo en el panel derecho del contenedor principal
        /// </summary>
        /// <param name="ChildForm">El formulario hijo a cargar</param>
        private void LoadFormIntoPanel(Form childForm)
        {
            if (childForm is null)
            {
                throw new ArgumentNullException(nameof(childForm));
            }

            // Obtener primero el formulario actualmente cargado.
            Form? currentForm =
                splitMain.Panel2.Controls
                    .OfType<Form>()
                    .FirstOrDefault();

            if (currentForm is not null)
            {
                // Quitar el formulario del panel.
                splitMain.Panel2.Controls.Remove(currentForm);

                // Liberar los recursos del formulario anterior.
                currentForm.Dispose();
            }

            // Configurar el formulario nuevo como control hijo.
            childForm.TopLevel = false;
            childForm.FormBorderStyle =
                FormBorderStyle.None;

            childForm.Dock = DockStyle.Fill;

            splitMain.Panel2.Controls.Add(childForm);

            splitMain.Panel2.Tag = childForm;

            childForm.Show();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                ICustomerRepository repository =
                    new CustomerRepository(_context);

                var customerListForm =
                    new ListCustomerForm(repository);

                // Escuchar la solicitud de crear un nuevo cliente.
                customerListForm.NewCustomerRequested +=
                    CustomerListForm_NewCustomerRequested;

                // Escucha la solicitud de edición de un cliente.
                customerListForm.EditCustomerRequested +=
                    CustomerListForm_EditCustomerRequested;

                LoadFormIntoPanel(customerListForm);
            }
            catch (Exception)
            {
                MessageBox.Show("No fue posible abrir el módulo de clientes.", "Error", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Atiende la solicitud realizada desde ListCustomerForm para registrar un nuevo cliente.
        /// </summary>

        private void CustomerListForm_NewCustomerRequested(object? sender, EventArgs e)
        {
            try
            {
                ICustomerRepository repository = new CustomerRepository(_context);
                var customerForm = new CustomerForm(repository);
                LoadFormIntoPanel(customerForm);
            }
            catch (Exception)
            {
                MessageBox.Show("No fue posible abrir el formulario de cliente.", "Error", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CustomerListForm_EditCustomerRequested(
    int customerId)
        {
            try
            {
                if (customerId <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(customerId));
                }

                ICustomerRepository repository =
                    new CustomerRepository(_context);

                // Se abre CustomerEditForm, no CustomerForm.
                var customerEditForm =
                    new CustomerEditForm(
                        repository,
                        customerId);

                LoadFormIntoPanel(customerEditForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No fue posible abrir el formulario de edición: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    } //End class   
} //End namespace
