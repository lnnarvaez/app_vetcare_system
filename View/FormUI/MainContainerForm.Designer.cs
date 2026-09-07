namespace app_vetcare_system
{
    partial class MainContainerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            lblUserName = new Label();
            iconNotify = new FontAwesome.Sharp.IconPictureBox();
            pictureBox2 = new PictureBox();
            lblHeaderTitle = new Label();
            pictureBox1 = new PictureBox();
            splitMain = new SplitContainer();
            btnAccount = new FontAwesome.Sharp.IconButton();
            btnClose = new FontAwesome.Sharp.IconButton();
            btnReports = new FontAwesome.Sharp.IconButton();
            btnHospital = new FontAwesome.Sharp.IconButton();
            btnService = new FontAwesome.Sharp.IconButton();
            btnPatient = new FontAwesome.Sharp.IconButton();
            BtnClientes = new FontAwesome.Sharp.IconButton();
            btnHome = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconNotify).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lblHeaderTitle);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1600, 120);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(lblUserName);
            panel2.Controls.Add(iconNotify);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(1215, 17);
            panel2.Margin = new Padding(3, 3, 48, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(328, 80);
            panel2.TabIndex = 4;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Cursor = Cursors.Hand;
            lblUserName.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(209, 33);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(97, 27);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "username";
            // 
            // iconNotify
            // 
            iconNotify.BackColor = Color.WhiteSmoke;
            iconNotify.ForeColor = Color.FromArgb(177, 177, 177);
            iconNotify.IconChar = FontAwesome.Sharp.IconChar.Bell;
            iconNotify.IconColor = Color.FromArgb(177, 177, 177);
            iconNotify.IconFont = FontAwesome.Sharp.IconFont.Regular;
            iconNotify.IconSize = 48;
            iconNotify.Location = new Point(27, 16);
            iconNotify.Margin = new Padding(3, 3, 32, 3);
            iconNotify.Name = "iconNotify";
            iconNotify.Size = new Size(48, 48);
            iconNotify.TabIndex = 2;
            iconNotify.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user_72;
            pictureBox2.Location = new Point(110, 0);
            pictureBox2.Margin = new Padding(3, 3, 16, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(80, 80);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Open Sans SemiBold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeaderTitle.ForeColor = Color.FromArgb(66, 66, 66);
            lblHeaderTitle.Location = new Point(169, 40);
            lblHeaderTitle.Margin = new Padding(24, 0, 3, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(432, 43);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Clinica Veterinaria VetCare";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_vetcare;
            pictureBox1.Location = new Point(57, 17);
            pictureBox1.Margin = new Padding(48, 8, 8, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.IsSplitterFixed = true;
            splitMain.Location = new Point(0, 120);
            splitMain.Margin = new Padding(4);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.BackColor = Color.FromArgb(7, 59, 53);
            splitMain.Panel1.Controls.Add(btnAccount);
            splitMain.Panel1.Controls.Add(btnClose);
            splitMain.Panel1.Controls.Add(btnReports);
            splitMain.Panel1.Controls.Add(btnHospital);
            splitMain.Panel1.Controls.Add(btnService);
            splitMain.Panel1.Controls.Add(btnPatient);
            splitMain.Panel1.Controls.Add(BtnClientes);
            splitMain.Panel1.Controls.Add(btnHome);
            splitMain.Panel1.Padding = new Padding(8, 48, 8, 64);
            splitMain.Panel1MinSize = 24;
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.BackColor = Color.FromArgb(210, 210, 210);
            splitMain.Panel2.Padding = new Padding(16);
            splitMain.Panel2MinSize = 24;
            splitMain.Size = new Size(1600, 780);
            splitMain.SplitterDistance = 260;
            splitMain.TabIndex = 1;
            // 
            // btnAccount
            // 
            btnAccount.Cursor = Cursors.Hand;
            btnAccount.Dock = DockStyle.Bottom;
            btnAccount.FlatAppearance.BorderSize = 0;
            btnAccount.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 105, 94);
            btnAccount.FlatAppearance.MouseOverBackColor = Color.FromArgb(14, 118, 105);
            btnAccount.FlatStyle = FlatStyle.Flat;
            btnAccount.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAccount.ForeColor = Color.WhiteSmoke;
            btnAccount.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            btnAccount.IconColor = Color.FromArgb(190, 190, 190);
            btnAccount.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAccount.ImageAlign = ContentAlignment.MiddleLeft;
            btnAccount.Location = new Point(8, 580);
            btnAccount.Name = "btnAccount";
            btnAccount.Size = new Size(244, 68);
            btnAccount.TabIndex = 15;
            btnAccount.Text = "Cuenta";
            btnAccount.TextAlign = ContentAlignment.MiddleLeft;
            btnAccount.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAccount.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.Dock = DockStyle.Bottom;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 105, 94);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(14, 118, 105);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(225, 225, 225);
            btnClose.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            btnClose.IconColor = Color.FromArgb(225, 225, 225);
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(8, 648);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(4);
            btnClose.Size = new Size(244, 68);
            btnClose.TabIndex = 14;
            btnClose.Text = "Salir del Sistema";
            btnClose.TextAlign = ContentAlignment.MiddleLeft;
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnReports
            // 
            btnReports.Cursor = Cursors.Hand;
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 105, 94);
            btnReports.FlatAppearance.MouseOverBackColor = Color.FromArgb(14, 118, 105);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.WhiteSmoke;
            btnReports.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            btnReports.IconColor = Color.FromArgb(190, 190, 190);
            btnReports.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.Location = new Point(8, 388);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(4);
            btnReports.Size = new Size(244, 68);
            btnReports.TabIndex = 13;
            btnReports.Text = "Informes";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = true;
            // 
            // btnHospital
            // 
            btnHospital.Cursor = Cursors.Hand;
            btnHospital.Dock = DockStyle.Top;
            btnHospital.FlatAppearance.BorderSize = 0;
            btnHospital.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 105, 94);
            btnHospital.FlatAppearance.MouseOverBackColor = Color.FromArgb(14, 118, 105);
            btnHospital.FlatStyle = FlatStyle.Flat;
            btnHospital.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHospital.ForeColor = Color.WhiteSmoke;
            btnHospital.IconChar = FontAwesome.Sharp.IconChar.Hospital;
            btnHospital.IconColor = Color.FromArgb(190, 190, 190);
            btnHospital.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnHospital.ImageAlign = ContentAlignment.MiddleLeft;
            btnHospital.Location = new Point(8, 320);
            btnHospital.Name = "btnHospital";
            btnHospital.Padding = new Padding(4);
            btnHospital.Size = new Size(244, 68);
            btnHospital.TabIndex = 12;
            btnHospital.Text = "Hospitalización";
            btnHospital.TextAlign = ContentAlignment.MiddleLeft;
            btnHospital.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHospital.UseVisualStyleBackColor = true;
            // 
            // btnService
            // 
            btnService.Cursor = Cursors.Hand;
            btnService.Dock = DockStyle.Top;
            btnService.FlatAppearance.BorderSize = 0;
            btnService.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 105, 94);
            btnService.FlatAppearance.MouseOverBackColor = Color.FromArgb(14, 118, 105);
            btnService.FlatStyle = FlatStyle.Flat;
            btnService.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnService.ForeColor = Color.WhiteSmoke;
            btnService.IconChar = FontAwesome.Sharp.IconChar.HospitalUser;
            btnService.IconColor = Color.FromArgb(190, 190, 190);
            btnService.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnService.ImageAlign = ContentAlignment.MiddleLeft;
            btnService.Location = new Point(8, 252);
            btnService.Name = "btnService";
            btnService.Padding = new Padding(4);
            btnService.Size = new Size(244, 68);
            btnService.TabIndex = 11;
            btnService.Text = "Servicios";
            btnService.TextAlign = ContentAlignment.MiddleLeft;
            btnService.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnService.UseVisualStyleBackColor = true;
            // 
            // btnPatient
            // 
            btnPatient.Cursor = Cursors.Hand;
            btnPatient.Dock = DockStyle.Top;
            btnPatient.FlatAppearance.BorderSize = 0;
            btnPatient.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 105, 94);
            btnPatient.FlatAppearance.MouseOverBackColor = Color.FromArgb(14, 118, 105);
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPatient.ForeColor = Color.WhiteSmoke;
            btnPatient.IconChar = FontAwesome.Sharp.IconChar.Paw;
            btnPatient.IconColor = Color.FromArgb(190, 190, 190);
            btnPatient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPatient.ImageAlign = ContentAlignment.MiddleLeft;
            btnPatient.Location = new Point(8, 184);
            btnPatient.Name = "btnPatient";
            btnPatient.Padding = new Padding(4);
            btnPatient.Size = new Size(244, 68);
            btnPatient.TabIndex = 10;
            btnPatient.Text = "Pacientes";
            btnPatient.TextAlign = ContentAlignment.MiddleLeft;
            btnPatient.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPatient.UseVisualStyleBackColor = true;
            // 
            // BtnClientes
            // 
            BtnClientes.Cursor = Cursors.Hand;
            BtnClientes.Dock = DockStyle.Top;
            BtnClientes.FlatAppearance.BorderSize = 0;
            BtnClientes.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 105, 94);
            BtnClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(14, 118, 105);
            BtnClientes.FlatStyle = FlatStyle.Flat;
            BtnClientes.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnClientes.ForeColor = Color.WhiteSmoke;
            BtnClientes.IconChar = FontAwesome.Sharp.IconChar.UserLarge;
            BtnClientes.IconColor = Color.FromArgb(190, 190, 190);
            BtnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            BtnClientes.Location = new Point(8, 116);
            BtnClientes.Name = "BtnClientes";
            BtnClientes.Padding = new Padding(4);
            BtnClientes.Size = new Size(244, 68);
            BtnClientes.TabIndex = 9;
            BtnClientes.Text = "Clientes";
            BtnClientes.TextAlign = ContentAlignment.MiddleLeft;
            BtnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnClientes.UseVisualStyleBackColor = true;
            BtnClientes.Click += BtnClientes_Click;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 105, 94);
            btnHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(14, 118, 105);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.WhiteSmoke;
            btnHome.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            btnHome.IconColor = Color.FromArgb(190, 190, 190);
            btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(8, 48);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(4);
            btnHome.Size = new Size(244, 68);
            btnHome.TabIndex = 8;
            btnHome.Text = "Panel de Indicadores";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = true;
            // 
            // MainContainerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 900);
            Controls.Add(splitMain);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainContainerForm";
            Text = "VetrCare";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconNotify).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private SplitContainer splitMain;
        private PictureBox pictureBox1;
        private Label lblHeaderTitle;
        private FontAwesome.Sharp.IconPictureBox iconNotify;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Label lblUserName;
        private FontAwesome.Sharp.IconButton btnHome;
        private FontAwesome.Sharp.IconButton BtnClientes;
        private FontAwesome.Sharp.IconButton btnPatient;
        private FontAwesome.Sharp.IconButton btnService;
        private FontAwesome.Sharp.IconButton btnHospital;
        private FontAwesome.Sharp.IconButton btnReports;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnAccount;
    }
}
