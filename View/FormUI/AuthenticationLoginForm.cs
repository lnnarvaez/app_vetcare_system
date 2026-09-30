using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Presenter;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.View.FormUI
{
    public partial class AuthenticationLoginForm : Form, IAuthenticationView
    {
        private readonly AuthenticationPresenter _presenter;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationLoginForm(IAuthenticationService authenticationService)
        {
            InitializeComponent();

            _authenticationService = authenticationService
                ?? throw new ArgumentNullException(nameof(authenticationService));

            _presenter = new AuthenticationPresenter(this, authenticationService);
            btnContinue.Click += ButtonContinue_Click;

            AcceptButton = btnContinue;
            txtUserName.Select();
        }

        public string UserName => txtUserName.Text;

        public string Password => txtPassword.Text;

        public AuthenticatedUserDto? AuthenticatedUser { get; private set; }

        public event EventHandler? AuthenticationSucceeded;

        private void ButtonContinue_Click(object? sender, EventArgs e)
        {
            _presenter.Authenticate();
        }

        public void ShowAuthenticationError(string message)
        {
            MessageBox.Show(this, message, "Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txtPassword.SelectAll();
            txtPassword.Select();
        }

        public void ShowAuthenticatedUser(AuthenticatedUserDto user)
        {
            AuthenticatedUser = user
                ?? throw new ArgumentNullException(nameof(user));

            AuthenticationSucceeded?.Invoke(this, EventArgs.Empty);
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            using var recoverAccessForm = new RecoverAccessForm(
                _authenticationService,
                UserName);

            recoverAccessForm.ShowDialog(this);
        }
    }
}
