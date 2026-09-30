namespace app_vetcare_system.View.FormUI
{
    partial class AuthenticationLoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnRecovery = new Button();
            btnContinue = new Button();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            lblSession = new Label();
            lblWelcome = new Label();
            pctLogo = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctLogo).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(btnRecovery);
            panel1.Controls.Add(btnContinue);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(lblSession);
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(pctLogo);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(556, 670);
            panel1.TabIndex = 0;
            // 
            // btnRecovery
            // 
            btnRecovery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRecovery.BackColor = Color.WhiteSmoke;
            btnRecovery.Cursor = Cursors.Hand;
            btnRecovery.FlatAppearance.BorderSize = 0;
            btnRecovery.FlatStyle = FlatStyle.Flat;
            btnRecovery.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRecovery.ForeColor = Color.FromArgb(30, 82, 155);
            btnRecovery.Location = new Point(185, 578);
            btnRecovery.Margin = new Padding(3, 3, 3, 32);
            btnRecovery.Name = "btnRecovery";
            btnRecovery.Size = new Size(210, 40);
            btnRecovery.TabIndex = 6;
            btnRecovery.Text = "Recuperar Acceso";
            btnRecovery.UseVisualStyleBackColor = false;
            btnRecovery.Click += btnRecovery_Click;
            // 
            // btnContinue
            // 
            btnContinue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnContinue.BackColor = Color.FromArgb(19, 96, 82);
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.FlatAppearance.MouseOverBackColor = Color.FromArgb(17, 87, 75);
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnContinue.ForeColor = Color.WhiteSmoke;
            btnContinue.Location = new Point(48, 495);
            btnContinue.Margin = new Padding(3, 56, 3, 32);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(456, 48);
            btnContinue.TabIndex = 5;
            btnContinue.Text = "Continuar";
            btnContinue.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Font = new Font("Segoe UI Variable Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(48, 402);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Ingrese su passweord";
            txtPassword.Size = new Size(456, 37);
            txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUserName.Font = new Font("Segoe UI Variable Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(48, 333);
            txtUserName.Margin = new Padding(48, 40, 3, 32);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Ingrese tu usuario";
            txtUserName.Size = new Size(456, 37);
            txtUserName.TabIndex = 3;
            // 
            // lblSession
            // 
            lblSession.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSession.AutoSize = true;
            lblSession.Font = new Font("Open Sans SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSession.ForeColor = Color.FromArgb(66, 66, 66);
            lblSession.Location = new Point(185, 260);
            lblSession.Margin = new Padding(3, 24, 3, 0);
            lblSession.Name = "lblSession";
            lblSession.Size = new Size(168, 33);
            lblSession.TabIndex = 2;
            lblSession.Text = "Iniciar sesión";
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Open Sans SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.FromArgb(66, 66, 66);
            lblWelcome.Location = new Point(161, 187);
            lblWelcome.Margin = new Padding(3, 32, 3, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(217, 49);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Bienvenido";
            // 
            // pctLogo
            // 
            pctLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pctLogo.Image = Properties.Resources.logo_vetcare;
            pctLogo.Location = new Point(209, 32);
            pctLogo.Margin = new Padding(3, 32, 3, 3);
            pctLogo.Name = "pctLogo";
            pctLogo.Size = new Size(120, 120);
            pctLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pctLogo.TabIndex = 0;
            pctLogo.TabStop = false;
            // 
            // AuthenticationLoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(156, 161, 170);
            ClientSize = new Size(560, 674);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AuthenticationLoginForm";
            Padding = new Padding(2);
            Text = "AuthenticationLogin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label lblSession;
        private Label lblWelcome;
        private PictureBox pctLogo;
        private Button btnRecovery;
        private Button btnContinue;
    }
}