using app_vetcare_system.Services.Interfaz_service;

namespace app_vetcare_system.View.FormUI
{
    public partial class RecoverAccessForm : Form
    {
        private readonly IAuthenticationService _authenticationService;

        public RecoverAccessForm(
            IAuthenticationService authenticationService,
            string userName)
        {
            InitializeComponent();

            _authenticationService = authenticationService
                ?? throw new ArgumentNullException(nameof(authenticationService));

            // Centra el modal respecto al formulario propietario sin modificar el diseñador.
            StartPosition = FormStartPosition.CenterParent;

            txtUserName.Text = userName?.Trim() ?? string.Empty;
            btnRecovery.Click += btnRecovery_Click;
            btnCancel.Click += btnCancel_Click;
            AcceptButton = btnRecovery;
            CancelButton = btnCancel;

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                txtUserName.Select();
            }
            else
            {
                txtRecoveryPassword.Select();
            }
        }

        private void btnRecovery_Click(object? sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string newPassword = txtRecoveryPassword.Text;

            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show(
                    this,
                    "El usuario y la nueva contraseña son obligatorios.",
                    "Recuperar acceso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _authenticationService.ResetPassword(userName, newPassword);

                MessageBox.Show(
                    this,
                    "La contraseña fue actualizada correctamente.",
                    "Recuperar acceso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    this,
                    "No fue posible actualizar la contraseña.",
                    "Recuperar acceso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
