namespace app_vetcare_system.View.FormUI
{
    partial class CustomerForm
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
            components = new System.ComponentModel.Container();
            pnlTop = new Panel();
            lblHeader = new Label();
            btnHome = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            mskCedula = new MaskedTextBox();
            label2 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtSurname = new TextBox();
            label4 = new Label();
            mskMainPhone = new MaskedTextBox();
            label5 = new Label();
            mskAlternPhone = new MaskedTextBox();
            label6 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            mskPreferredPay = new ComboBox();
            label8 = new Label();
            txtAddress = new TextBox();
            pnlContainer = new Panel();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            panel2 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            btnCreate = new FontAwesome.Sharp.IconButton();
            label9 = new Label();
            errorProvider1 = new ErrorProvider(components);
            pnlTop.SuspendLayout();
            pnlContainer.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(158, 158, 158);
            pnlTop.Controls.Add(lblHeader);
            pnlTop.Controls.Add(btnHome);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1074, 60);
            pnlTop.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.FromArgb(66, 66, 66);
            lblHeader.Location = new Point(108, 20);
            lblHeader.Margin = new Padding(16, 0, 3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(151, 27);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Cliente | Nuevo";
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            btnHome.IconColor = Color.FromArgb(13, 105, 94);
            btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHome.Location = new Point(41, 9);
            btnHome.Margin = new Padding(32, 3, 3, 3);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(4);
            btnHome.Size = new Size(48, 48);
            btnHome.TabIndex = 11;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 10F);
            label1.Location = new Point(32, 86);
            label1.Margin = new Padding(24, 24, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 27);
            label1.TabIndex = 1;
            label1.Text = "Cédula";
            // 
            // mskCedula
            // 
            mskCedula.Location = new Point(35, 121);
            mskCedula.Margin = new Padding(3, 8, 3, 3);
            mskCedula.Mask = "000-000000-0000L";
            mskCedula.Name = "mskCedula";
            mskCedula.Size = new Size(420, 34);
            mskCedula.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Display", 10F);
            label2.Location = new Point(32, 175);
            label2.Name = "label2";
            label2.Size = new Size(85, 27);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // txtName
            // 
            txtName.Location = new Point(32, 210);
            txtName.Margin = new Padding(3, 8, 3, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(420, 34);
            txtName.TabIndex = 2;
            txtName.Validating += txtName_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Variable Display", 10F);
            label3.Location = new Point(506, 175);
            label3.Name = "label3";
            label3.Size = new Size(95, 27);
            label3.TabIndex = 5;
            label3.Text = "Apellidos";
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(503, 210);
            txtSurname.Margin = new Padding(48, 8, 3, 3);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(420, 34);
            txtSurname.TabIndex = 3;
            txtSurname.Validating += txtSurname_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Variable Display", 10F);
            label4.Location = new Point(32, 348);
            label4.Name = "label4";
            label4.Size = new Size(167, 27);
            label4.TabIndex = 7;
            label4.Text = "Teléfono Principal";
            // 
            // mskMainPhone
            // 
            mskMainPhone.Cursor = Cursors.Hand;
            mskMainPhone.ForeColor = Color.FromArgb(66, 66, 66);
            mskMainPhone.Location = new Point(35, 387);
            mskMainPhone.Margin = new Padding(8, 8, 3, 3);
            mskMainPhone.Mask = "0000-0000";
            mskMainPhone.Name = "mskMainPhone";
            mskMainPhone.Size = new Size(420, 34);
            mskMainPhone.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Display", 10F);
            label5.Location = new Point(503, 348);
            label5.Name = "label5";
            label5.Size = new Size(156, 27);
            label5.TabIndex = 9;
            label5.Text = "Teléfono Alterno";
            // 
            // mskAlternPhone
            // 
            mskAlternPhone.Cursor = Cursors.Hand;
            mskAlternPhone.ForeColor = Color.FromArgb(66, 66, 66);
            mskAlternPhone.Location = new Point(503, 387);
            mskAlternPhone.Margin = new Padding(3, 8, 3, 3);
            mskAlternPhone.Mask = "0000-0000";
            mskAlternPhone.Name = "mskAlternPhone";
            mskAlternPhone.Size = new Size(420, 34);
            mskAlternPhone.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Variable Display", 10F);
            label6.Location = new Point(35, 446);
            label6.Name = "label6";
            label6.Size = new Size(178, 27);
            label6.TabIndex = 11;
            label6.Text = "Correo electrónico";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(36, 485);
            txtEmail.Margin = new Padding(3, 8, 3, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(886, 34);
            txtEmail.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Variable Display", 10F);
            label7.Location = new Point(36, 759);
            label7.Name = "label7";
            label7.Size = new Size(141, 27);
            label7.TabIndex = 13;
            label7.Text = "Pago Preferido";
            // 
            // mskPreferredPay
            // 
            mskPreferredPay.Cursor = Cursors.Hand;
            mskPreferredPay.DropDownStyle = ComboBoxStyle.DropDownList;
            mskPreferredPay.FormattingEnabled = true;
            mskPreferredPay.Items.AddRange(new object[] { "Efectivo", "Transferencia", "Tarjeta Crédito" });
            mskPreferredPay.Location = new Point(36, 797);
            mskPreferredPay.Margin = new Padding(3, 8, 3, 3);
            mskPreferredPay.Name = "mskPreferredPay";
            mskPreferredPay.Size = new Size(887, 35);
            mskPreferredPay.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Variable Display", 10F);
            label8.Location = new Point(35, 545);
            label8.Name = "label8";
            label8.Size = new Size(189, 27);
            label8.TabIndex = 15;
            label8.Text = "Dirección domiciliar";
            // 
            // txtAddress
            // 
            txtAddress.AcceptsReturn = true;
            txtAddress.Location = new Point(32, 583);
            txtAddress.Margin = new Padding(3, 8, 3, 3);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(891, 78);
            txtAddress.TabIndex = 7;
            txtAddress.Validating += txtAddress_Validating;
            // 
            // pnlContainer
            // 
            pnlContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContainer.Controls.Add(label12);
            pnlContainer.Controls.Add(label11);
            pnlContainer.Controls.Add(label10);
            pnlContainer.Controls.Add(label1);
            pnlContainer.Controls.Add(txtAddress);
            pnlContainer.Controls.Add(mskCedula);
            pnlContainer.Controls.Add(label8);
            pnlContainer.Controls.Add(label2);
            pnlContainer.Controls.Add(mskPreferredPay);
            pnlContainer.Controls.Add(txtName);
            pnlContainer.Controls.Add(label7);
            pnlContainer.Controls.Add(label3);
            pnlContainer.Controls.Add(txtEmail);
            pnlContainer.Controls.Add(txtSurname);
            pnlContainer.Controls.Add(label6);
            pnlContainer.Controls.Add(label4);
            pnlContainer.Controls.Add(mskAlternPhone);
            pnlContainer.Controls.Add(mskMainPhone);
            pnlContainer.Controls.Add(label5);
            pnlContainer.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlContainer.Location = new Point(57, 213);
            pnlContainer.Margin = new Padding(32, 32, 3, 3);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(8);
            pnlContainer.Size = new Size(963, 869);
            pnlContainer.TabIndex = 17;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Variable Display Semib", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(66, 66, 66);
            label12.Location = new Point(32, 703);
            label12.Name = "label12";
            label12.Size = new Size(160, 30);
            label12.TabIndex = 19;
            label12.Text = "Forma de Pago";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Variable Display Semib", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(66, 66, 66);
            label11.Location = new Point(32, 290);
            label11.Name = "label11";
            label11.Size = new Size(200, 30);
            label11.TabIndex = 18;
            label11.Text = "Datos de Contacto";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Variable Display Semib", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(66, 66, 66);
            label10.Location = new Point(32, 32);
            label10.Margin = new Padding(24, 24, 3, 0);
            label10.Name = "label10";
            label10.Size = new Size(184, 30);
            label10.TabIndex = 17;
            label10.Text = "Datos Personales";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(iconButton1);
            panel2.Controls.Add(btnCreate);
            panel2.Controls.Add(label9);
            panel2.Cursor = Cursors.Hand;
            panel2.Location = new Point(57, 95);
            panel2.Margin = new Padding(32, 32, 3, 3);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(16);
            panel2.Size = new Size(964, 82);
            panel2.TabIndex = 18;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton1.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(745, 15);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(200, 56);
            iconButton1.TabIndex = 10;
            iconButton1.Text = "Cancelar";
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreate.BackColor = Color.FromArgb(13, 105, 64);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreate.ForeColor = Color.WhiteSmoke;
            btnCreate.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnCreate.IconColor = Color.WhiteSmoke;
            btnCreate.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCreate.IconSize = 32;
            btnCreate.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreate.Location = new Point(524, 15);
            btnCreate.Margin = new Padding(16, 3, 3, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Padding = new Padding(2);
            btnCreate.Size = new Size(200, 56);
            btnCreate.TabIndex = 9;
            btnCreate.Text = "Crear Cliente";
            btnCreate.TextAlign = ContentAlignment.MiddleLeft;
            btnCreate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Variable Display Semib", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(66, 66, 66);
            label9.Location = new Point(19, 24);
            label9.Name = "label9";
            label9.Size = new Size(157, 30);
            label9.TabIndex = 0;
            label9.Text = "Cliente Nuevo";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 1124);
            Controls.Add(panel2);
            Controls.Add(pnlContainer);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerForm";
            Text = "CustomerForm";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private FontAwesome.Sharp.IconButton btnHome;
        private Label lblHeader;
        private Label label1;
        private MaskedTextBox mskCedula;
        private Label label2;
        private TextBox txtName;
        private Label label3;
        private TextBox txtSurname;
        private Label label4;
        private MaskedTextBox mskMainPhone;
        private Label label5;
        private MaskedTextBox mskAlternPhone;
        private Label label6;
        private TextBox txtEmail;
        private Label label7;
        private ComboBox mskPreferredPay;
        private Label label8;
        private TextBox txtAddress;
        private Panel pnlContainer;
        private Panel panel2;
        private Label label9;
        private FontAwesome.Sharp.IconButton btnCreate;
        private Label label10;
        private Label label11;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Label label12;
        private ErrorProvider errorProvider1;
    }
}