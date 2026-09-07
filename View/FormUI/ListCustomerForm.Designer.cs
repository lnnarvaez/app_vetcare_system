namespace app_vetcare_system.View
{
    partial class ListCustomerForm
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
            lblBuscar = new Label();
            btnHome = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            mskPhone = new MaskedTextBox();
            label4 = new Label();
            txtFullName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            mskNationalId = new MaskedTextBox();
            dgvCustomerList = new DataGridView();
            btnCustomerNew = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerList).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(158, 158, 158);
            panel1.Controls.Add(lblBuscar);
            panel1.Controls.Add(btnHome);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1600, 60);
            panel1.TabIndex = 0;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.ForeColor = Color.FromArgb(66, 66, 66);
            lblBuscar.Location = new Point(100, 19);
            lblBuscar.Margin = new Padding(8, 0, 3, 0);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(152, 27);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar Clientes";
            // 
            // btnHome
            // 
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.IconChar = FontAwesome.Sharp.IconChar.House;
            btnHome.IconColor = Color.FromArgb(13, 105, 94);
            btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHome.IconSize = 32;
            btnHome.Location = new Point(41, 9);
            btnHome.Margin = new Padding(32, 3, 3, 3);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(4);
            btnHome.Size = new Size(48, 48);
            btnHome.TabIndex = 0;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(mskPhone);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtFullName);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(mskNationalId);
            panel2.Location = new Point(41, 185);
            panel2.Margin = new Padding(32);
            panel2.Name = "panel2";
            panel2.Size = new Size(1518, 141);
            panel2.TabIndex = 1;
            // 
            // mskPhone
            // 
            mskPhone.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mskPhone.ForeColor = Color.FromArgb(66, 66, 66);
            mskPhone.Location = new Point(1229, 73);
            mskPhone.Mask = "0000-0000";
            mskPhone.Name = "mskPhone";
            mskPhone.Size = new Size(220, 34);
            mskPhone.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(66, 66, 66);
            label4.Location = new Point(1127, 73);
            label4.Margin = new Padding(48, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(91, 27);
            label4.TabIndex = 5;
            label4.Text = "Teléfono";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.ForeColor = Color.FromArgb(66, 66, 66);
            txtFullName.Location = new Point(541, 72);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(520, 34);
            txtFullName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(66, 66, 66);
            label3.Location = new Point(435, 73);
            label3.Margin = new Padding(48, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 27);
            label3.TabIndex = 3;
            label3.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(66, 66, 66);
            label2.Location = new Point(52, 73);
            label2.Name = "label2";
            label2.Size = new Size(74, 27);
            label2.TabIndex = 2;
            label2.Text = "Cédula";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(66, 66, 66);
            label1.Location = new Point(52, 18);
            label1.Name = "label1";
            label1.Size = new Size(143, 27);
            label1.TabIndex = 1;
            label1.Text = "Buscar Cliente";
            // 
            // mskNationalId
            // 
            mskNationalId.Location = new Point(138, 69);
            mskNationalId.Margin = new Padding(48, 24, 3, 3);
            mskNationalId.Mask = "000-000000-0000L";
            mskNationalId.Name = "mskNationalId";
            mskNationalId.Size = new Size(246, 31);
            mskNationalId.TabIndex = 0;
            // 
            // dgvCustomerList
            // 
            dgvCustomerList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerList.Cursor = Cursors.Hand;
            dgvCustomerList.Location = new Point(41, 374);
            dgvCustomerList.Margin = new Padding(3, 32, 3, 3);
            dgvCustomerList.Name = "dgvCustomerList";
            dgvCustomerList.RowHeadersWidth = 62;
            dgvCustomerList.Size = new Size(1518, 528);
            dgvCustomerList.TabIndex = 2;
            // 
            // btnCustomerNew
            // 
            btnCustomerNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCustomerNew.BackColor = Color.FromArgb(13, 105, 64);
            btnCustomerNew.Cursor = Cursors.Hand;
            btnCustomerNew.FlatAppearance.BorderSize = 0;
            btnCustomerNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 79, 70);
            btnCustomerNew.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 98, 88);
            btnCustomerNew.FlatStyle = FlatStyle.Flat;
            btnCustomerNew.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCustomerNew.ForeColor = Color.WhiteSmoke;
            btnCustomerNew.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnCustomerNew.IconColor = Color.WhiteSmoke;
            btnCustomerNew.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCustomerNew.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomerNew.Location = new Point(1333, 87);
            btnCustomerNew.Margin = new Padding(3, 24, 3, 3);
            btnCustomerNew.Name = "btnCustomerNew";
            btnCustomerNew.Padding = new Padding(4);
            btnCustomerNew.Size = new Size(226, 63);
            btnCustomerNew.TabIndex = 3;
            btnCustomerNew.Text = "Nuevo Cliente";
            btnCustomerNew.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomerNew.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomerNew.UseVisualStyleBackColor = false;
            // 
            // ListCustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(210, 210, 210);
            ClientSize = new Size(1600, 1055);
            Controls.Add(btnCustomerNew);
            Controls.Add(dgvCustomerList);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ListCustomerForm";
            Text = "CustomerForm";
            Load += ListCustomerForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnHome;
        private Label lblBuscar;
        private Panel panel2;
        private DataGridView dgvCustomerList;
        private MaskedTextBox mskNationalId;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox txtFullName;
        private Label label3;
        private MaskedTextBox mskPhone;
        private FontAwesome.Sharp.IconButton btnCustomerNew;
    }
}