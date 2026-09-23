namespace app_vetcare_system.View.FormUI
{
    partial class CustomerEditForm
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
            btnHome = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            btnCancel = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            panel3 = new Panel();
            cmbPayMethod = new ComboBox();
            label11 = new Label();
            label10 = new Label();
            txtAddress = new TextBox();
            label9 = new Label();
            txtEmail = new TextBox();
            label8 = new Label();
            mskAlternPhone = new MaskedTextBox();
            label7 = new Label();
            mskMainPhone = new MaskedTextBox();
            label6 = new Label();
            label5 = new Label();
            txtSurname = new TextBox();
            label4 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            mskNationalId = new MaskedTextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(158, 158, 158);
            panel1.Controls.Add(btnHome);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1074, 60);
            panel1.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            btnHome.IconColor = Color.FromArgb(13, 105, 94);
            btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHome.Location = new Point(32, 9);
            btnHome.Margin = new Padding(32, 3, 3, 3);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(4);
            btnHome.Size = new Size(48, 48);
            btnHome.TabIndex = 0;
            btnHome.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnSave);
            panel2.Location = new Point(58, 94);
            panel2.Name = "panel2";
            panel2.Size = new Size(964, 82);
            panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancel.IconColor = Color.Black;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.Location = new Point(718, 14);
            btnCancel.Margin = new Padding(3, 3, 32, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 56);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(13, 105, 64);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.WhiteSmoke;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.WhiteSmoke;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnSave.Location = new Point(491, 13);
            btnSave.Margin = new Padding(3, 3, 24, 3);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(2);
            btnSave.Size = new Size(200, 56);
            btnSave.TabIndex = 0;
            btnSave.Text = "Guardar";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(cmbPayMethod);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(txtAddress);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(txtEmail);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(mskAlternPhone);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(mskMainPhone);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(txtSurname);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(txtName);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(mskNationalId);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(58, 213);
            panel3.Name = "panel3";
            panel3.Size = new Size(964, 876);
            panel3.TabIndex = 2;
            // 
            // cmbPayMethod
            // 
            cmbPayMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPayMethod.Font = new Font("Segoe UI Variable Display", 10F);
            cmbPayMethod.FormattingEnabled = true;
            cmbPayMethod.Items.AddRange(new object[] { "Efectivo", "Transferencia", "Tarjeta de Crédito" });
            cmbPayMethod.Location = new Point(34, 807);
            cmbPayMethod.Margin = new Padding(16, 8, 3, 3);
            cmbPayMethod.Name = "cmbPayMethod";
            cmbPayMethod.Size = new Size(886, 35);
            cmbPayMethod.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F);
            label11.Location = new Point(32, 771);
            label11.Name = "label11";
            label11.Size = new Size(169, 28);
            label11.TabIndex = 17;
            label11.Text = "Método preferido";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Variable Display Semib", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(66, 66, 66);
            label10.Location = new Point(32, 715);
            label10.Name = "label10";
            label10.Size = new Size(161, 30);
            label10.TabIndex = 16;
            label10.Text = "Forma de pago";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI Variable Display", 10F);
            txtAddress.Location = new Point(32, 596);
            txtAddress.Margin = new Padding(16, 8, 3, 3);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(886, 78);
            txtAddress.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(32, 560);
            label9.Name = "label9";
            label9.Size = new Size(186, 28);
            label9.TabIndex = 14;
            label9.Text = "Dirección domiciliar";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI Variable Display", 10F);
            txtEmail.Location = new Point(32, 501);
            txtEmail.Margin = new Padding(16, 8, 3, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(886, 34);
            txtEmail.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(32, 455);
            label8.Name = "label8";
            label8.Size = new Size(174, 28);
            label8.TabIndex = 12;
            label8.Text = "Correo electrónico";
            // 
            // mskAlternPhone
            // 
            mskAlternPhone.Font = new Font("Segoe UI Variable Display", 10F);
            mskAlternPhone.Location = new Point(500, 386);
            mskAlternPhone.Margin = new Padding(16, 8, 3, 3);
            mskAlternPhone.Mask = "0000-0000";
            mskAlternPhone.Name = "mskAlternPhone";
            mskAlternPhone.Size = new Size(420, 34);
            mskAlternPhone.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(500, 350);
            label7.Name = "label7";
            label7.Size = new Size(166, 28);
            label7.TabIndex = 10;
            label7.Text = "Teléfono Principal";
            // 
            // mskMainPhone
            // 
            mskMainPhone.Font = new Font("Segoe UI Variable Display", 10F);
            mskMainPhone.Location = new Point(32, 386);
            mskMainPhone.Margin = new Padding(16, 8, 3, 3);
            mskMainPhone.Mask = "0000-0000";
            mskMainPhone.Name = "mskMainPhone";
            mskMainPhone.Size = new Size(420, 34);
            mskMainPhone.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(32, 350);
            label6.Margin = new Padding(24, 24, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(166, 28);
            label6.TabIndex = 8;
            label6.Text = "Teléfono Principal";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Display Semib", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(66, 66, 66);
            label5.Location = new Point(32, 296);
            label5.Margin = new Padding(24, 48, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(200, 30);
            label5.TabIndex = 7;
            label5.Text = "Datos de Contacto";
            // 
            // txtSurname
            // 
            txtSurname.Font = new Font("Segoe UI Variable Display", 10F);
            txtSurname.Location = new Point(500, 211);
            txtSurname.Margin = new Padding(16, 8, 3, 3);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(420, 34);
            txtSurname.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(500, 175);
            label4.Name = "label4";
            label4.Size = new Size(94, 28);
            label4.TabIndex = 5;
            label4.Text = "Apellidos";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI Variable Display", 10F);
            txtName.Location = new Point(32, 211);
            txtName.Margin = new Padding(16, 8, 3, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(420, 34);
            txtName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(32, 175);
            label3.Name = "label3";
            label3.Size = new Size(85, 28);
            label3.TabIndex = 3;
            label3.Text = "Nombre";
            // 
            // mskNationalId
            // 
            mskNationalId.Font = new Font("Segoe UI Variable Display", 10F);
            mskNationalId.Location = new Point(32, 114);
            mskNationalId.Margin = new Padding(16, 8, 3, 3);
            mskNationalId.Mask = "000-000000-0000L";
            mskNationalId.Name = "mskNationalId";
            mskNationalId.Size = new Size(420, 34);
            mskNationalId.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(32, 78);
            label2.Margin = new Padding(32, 24, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 28);
            label2.TabIndex = 1;
            label2.Text = "Cédula";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display Semib", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(66, 66, 66);
            label1.Location = new Point(24, 24);
            label1.Margin = new Padding(24, 24, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(184, 30);
            label1.TabIndex = 0;
            label1.Text = "Datos Personales";
            // 
            // CustomerEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 1124);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerEditForm";
            Text = "CustomerEditForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private MaskedTextBox mskNationalId;
        private Label label2;
        private Label label1;
        private TextBox txtSurname;
        private Label label4;
        private TextBox txtName;
        private Label label3;
        private Label label5;
        private MaskedTextBox mskAlternPhone;
        private Label label7;
        private MaskedTextBox mskMainPhone;
        private Label label6;
        private TextBox txtEmail;
        private Label label8;
        private TextBox txtAddress;
        private Label label9;
        private Label label10;
        private Label label11;
        private ComboBox cmbPayMethod;
        private FontAwesome.Sharp.IconButton btnHome;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnCancel;
    }
}