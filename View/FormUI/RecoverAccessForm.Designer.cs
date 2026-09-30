namespace app_vetcare_system.View.FormUI
{
    partial class RecoverAccessForm
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
            pictureBox1 = new PictureBox();
            lblAcceso = new Label();
            txtUserName = new TextBox();
            txtRecoveryPassword = new TextBox();
            btnRecovery = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_vetcare;
            pictureBox1.Location = new Point(205, 59);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblAcceso
            // 
            lblAcceso.AutoSize = true;
            lblAcceso.Font = new Font("Segoe UI Variable Display Semib", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAcceso.ForeColor = Color.FromArgb(66, 66, 66);
            lblAcceso.Location = new Point(139, 241);
            lblAcceso.Name = "lblAcceso";
            lblAcceso.Size = new Size(248, 37);
            lblAcceso.TabIndex = 1;
            lblAcceso.Text = "Recuperar Acceso";
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Segoe UI Variable Display", 11F);
            txtUserName.Location = new Point(75, 323);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Usuario actual";
            txtUserName.Size = new Size(380, 37);
            txtUserName.TabIndex = 2;
            // 
            // txtRecoveryPassword
            // 
            txtRecoveryPassword.Font = new Font("Segoe UI Variable Display", 11F);
            txtRecoveryPassword.Location = new Point(75, 395);
            txtRecoveryPassword.Name = "txtRecoveryPassword";
            txtRecoveryPassword.PasswordChar = '*';
            txtRecoveryPassword.PlaceholderText = "Ingresar nueva constraseña";
            txtRecoveryPassword.Size = new Size(380, 37);
            txtRecoveryPassword.TabIndex = 3;
            // 
            // btnRecovery
            // 
            btnRecovery.BackColor = Color.FromArgb(19, 96, 82);
            btnRecovery.Cursor = Cursors.Hand;
            btnRecovery.FlatAppearance.BorderSize = 0;
            btnRecovery.FlatStyle = FlatStyle.Flat;
            btnRecovery.Font = new Font("Segoe UI Variable Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRecovery.ForeColor = Color.WhiteSmoke;
            btnRecovery.Location = new Point(75, 491);
            btnRecovery.Name = "btnRecovery";
            btnRecovery.Size = new Size(168, 48);
            btnRecovery.TabIndex = 4;
            btnRecovery.Text = "Recuperar";
            btnRecovery.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(190, 190, 190);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 158, 158);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Variable Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(287, 491);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(168, 48);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // RecoverAccessForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(530, 603);
            Controls.Add(btnCancel);
            Controls.Add(btnRecovery);
            Controls.Add(txtRecoveryPassword);
            Controls.Add(txtUserName);
            Controls.Add(lblAcceso);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RecoverAccessForm";
            Text = "Recuperar Acceso";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblAcceso;
        private TextBox txtUserName;
        private TextBox txtRecoveryPassword;
        private Button btnRecovery;
        private Button btnCancel;
    }
}