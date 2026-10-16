using app_vetcare_si.Data;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.Services.Repository;
using app_vetcare_system.Services;
using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Data.DbSqlite;
using app_vetcare_system.View;
using app_vetcare_system.View.FormUI;
using Microsoft.EntityFrameworkCore;

namespace app_vetcare_system
{
    public partial class MainContainerForm : Form
    {
        private readonly VetCareDbSI2VContext _context;
        private readonly VetCareSqliteContext _sqliteContext;
        private AuthenticationLoginForm? _authenticationForm;
        private readonly Control[] _menuControls;

        public MainContainerForm()
        {
            InitializeComponent();
            _context = new VetCareDbSI2VContext();
            SqliteSchemaInitializer.TryInitialize();
            _sqliteContext = CreateSqliteContext();

            _menuControls =
            [
                btnHome,
                BtnClientes,
                btnPatient,
                btnService,
                btnHospital,
                btnReports,
                btnAccount
            ];

            SetAuthenticatedState(false);
            LoadAuthenticationForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _sqliteContext.Dispose();
            _context.Dispose();

            Dispose();
        }

        private static VetCareSqliteContext CreateSqliteContext()
        {
            string databasePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                "DbSqlite",
                "VetCareLocal.db");

            var options = new DbContextOptionsBuilder<VetCareSqliteContext>()
                .UseSqlite($"Data Source={databasePath}")
                .Options;

            return new VetCareSqliteContext(options);
        }

        private void LoadAuthenticationForm()
        {
            var authenticationService = new AuthenticationService(
                new UsuarioRepository(_context),
                new PasswordHasher());

            _authenticationForm =
                new AuthenticationLoginForm(authenticationService);

            _authenticationForm.AuthenticationSucceeded +=
                AuthenticationForm_AuthenticationSucceeded;

            _authenticationForm.TopLevel = false;
            _authenticationForm.FormBorderStyle = FormBorderStyle.None;
            _authenticationForm.Anchor = AnchorStyles.Top;
            splitMain.Panel2.Controls.Add(_authenticationForm);

            PositionAuthenticationForm();
            splitMain.Panel2.Resize += SplitMainPanel2_Resize;
            _authenticationForm.Show();
        }

        private void PositionAuthenticationForm()
        {
            if (_authenticationForm is null || _authenticationForm.IsDisposed)
            {
                return;
            }

            int availableHeight =
                splitMain.Panel2.ClientSize.Height -
                _authenticationForm.Height;

            _authenticationForm.Left =
                (splitMain.Panel2.ClientSize.Width -
                 _authenticationForm.Width) / 2;

            // Usa el 25 % del espacio vertical libre para mantener el login
            // centrado horizontalmente y ligeramente por debajo del borde superior.
            _authenticationForm.Top = Math.Max(0, (int)(availableHeight * 0.25));
        }

        private void SplitMainPanel2_Resize(object? sender, EventArgs e)
        {
            PositionAuthenticationForm();
        }

        private void AuthenticationForm_AuthenticationSucceeded(
            object? sender,
            EventArgs e)
        {
            if (_authenticationForm?.AuthenticatedUser is not AuthenticatedUserDto user)
            {
                return;
            }

            lblUserName.Text = user.UserName;
            SetAuthenticatedState(true);

            splitMain.Panel2.Resize -= SplitMainPanel2_Resize;
            splitMain.Panel2.Controls.Remove(_authenticationForm);
            _authenticationForm.Dispose();
            _authenticationForm = null;
        }

        private void SetAuthenticatedState(bool isAuthenticated)
        {
            foreach (Control menuControl in _menuControls)
            {
                menuControl.Visible = isAuthenticated;
                menuControl.Enabled = isAuthenticated;
            }

            panel2.Visible = isAuthenticated;
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
                    new CustomerRepository(_context, _sqliteContext);

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
                ICustomerRepository repository =
                    new CustomerRepository(_context, _sqliteContext);
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
                    new CustomerRepository(_context, _sqliteContext);

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
