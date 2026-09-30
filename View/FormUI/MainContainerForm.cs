using app_vetcare_si.Data;
using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.Services;
using app_vetcare_system.Services.Repository;
using app_vetcare_system.View;
using app_vetcare_system.View.FormUI;

namespace app_vetcare_system
{
    public partial class MainContainerForm : Form
    {
        private const string FixedAdministratorRole = "Administrador";

        private readonly VetCareDbSI2VContext _context;
        private AuthenticatedUserDto? _authenticatedUser;
        private AuthenticationLoginForm? _authenticationLoginForm;
        private string? _activeRole;

        public MainContainerForm()
        {
            InitializeComponent();
            _context = new VetCareDbSI2VContext();

            SetNavigationAccess(false);
            ShowAuthenticationForm();
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

        private void ShowAuthenticationForm()
        {
            IUsuarioRepository userRepository =
                new UsuarioRepository(_context);
            IAuthenticationService authenticationService =
                new AuthenticationService(
                    userRepository,
                    new PasswordHasher());

            var loginForm =
                new AuthenticationLoginForm(authenticationService);

            loginForm.AuthenticationSucceeded +=
                AuthenticationLoginForm_AuthenticationSucceeded;

            LoadAuthenticationFormIntoPanel(loginForm);
        }

        private void LoadAuthenticationFormIntoPanel(
            AuthenticationLoginForm loginForm)
        {
            RemoveCurrentChildForm();

            loginForm.TopLevel = false;
            loginForm.FormBorderStyle = FormBorderStyle.None;
            loginForm.Dock = DockStyle.None;

            _authenticationLoginForm = loginForm;
            splitMain.Panel2.Controls.Add(loginForm);
            splitMain.Panel2.Tag = loginForm;
            splitMain.Panel2.Resize += Panel2_ResizeAuthenticationForm;

            CenterAuthenticationForm();
            loginForm.Show();
        }

        private void Panel2_ResizeAuthenticationForm(
            object? sender,
            EventArgs e)
        {
            CenterAuthenticationForm();
        }

        private void CenterAuthenticationForm()
        {
            if (_authenticationLoginForm is null ||
                _authenticationLoginForm.IsDisposed)
            {
                return;
            }

            Rectangle displayArea = splitMain.Panel2.DisplayRectangle;

            _authenticationLoginForm.Location = new Point(
                displayArea.X + Math.Max(
                    0,
                    (displayArea.Width - _authenticationLoginForm.Width) / 2),
                displayArea.Y + Math.Max(
                    0,
                    (displayArea.Height - _authenticationLoginForm.Height) / 2));
        }

        private void AuthenticationLoginForm_AuthenticationSucceeded(
            object? sender,
            EventArgs e)
        {
            if (sender is not AuthenticationLoginForm loginForm ||
                loginForm.AuthenticatedUser is null)
            {
                return;
            }

            _authenticatedUser = loginForm.AuthenticatedUser;

            // Política de autorización temporal hasta
            // que se configuren los permisos de la base de datos..
            _activeRole = FixedAdministratorRole;
            lblUserName.Text = _authenticatedUser.UserName;

            splitMain.Panel2.Resize -= Panel2_ResizeAuthenticationForm;
            _authenticationLoginForm = null;
            RemoveCurrentChildForm();
            SetNavigationAccess(_activeRole == FixedAdministratorRole);
        }

        private void RemoveCurrentChildForm()
        {
            Form? currentForm =
                splitMain.Panel2.Controls
                    .OfType<Form>()
                    .FirstOrDefault();

            if (currentForm is null)
            {
                return;
            }

            splitMain.Panel2.Controls.Remove(currentForm);
            currentForm.Dispose();
            splitMain.Panel2.Tag = null;
        }

        private void SetNavigationAccess(bool isAuthenticated)
        {
            btnHome.Visible = isAuthenticated;
            BtnClientes.Visible = isAuthenticated;
            btnPatient.Visible = isAuthenticated;
            btnService.Visible = isAuthenticated;
            btnHospital.Visible = isAuthenticated;
            btnReports.Visible = isAuthenticated;
            btnAccount.Visible = isAuthenticated;
        }

        private bool HasNavigationAccess()
        {
            return _authenticatedUser is not null &&
                   _activeRole == FixedAdministratorRole;
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            if (!HasNavigationAccess())
            {
                return;
            }

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
