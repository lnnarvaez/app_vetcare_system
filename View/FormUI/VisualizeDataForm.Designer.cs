namespace app_vetcare_system.View.FormUI
{
    partial class VisualizeDataForm
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
            pnlCustomer = new Panel();
            lblTotalCustomers = new Label();
            label1 = new Label();
            pnlPacients = new Panel();
            label4 = new Label();
            lblTotalPacients = new Label();
            pnlMonthlyPerformance = new Panel();
            lblMonthlyAppointments = new Label();
            lblMedicalappointment15 = new Label();
            lblWeeklyAppointment = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel5 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            pnlCustomer.SuspendLayout();
            pnlPacients.SuspendLayout();
            pnlMonthlyPerformance.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(158, 158, 158);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1199, 60);
            panel1.TabIndex = 0;
            // 
            // pnlCustomer
            // 
            pnlCustomer.BackColor = Color.Gainsboro;
            pnlCustomer.Controls.Add(lblTotalCustomers);
            pnlCustomer.Controls.Add(label1);
            pnlCustomer.Location = new Point(76, 110);
            pnlCustomer.Name = "pnlCustomer";
            pnlCustomer.Size = new Size(210, 90);
            pnlCustomer.TabIndex = 1;
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCustomers.ForeColor = Color.FromArgb(30, 82, 155);
            lblTotalCustomers.Location = new Point(62, 16);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(74, 28);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "[####]";
            lblTotalCustomers.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 54);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 0;
            label1.Text = "Nuevos Clientes";
            // 
            // pnlPacients
            // 
            pnlPacients.BackColor = Color.Gainsboro;
            pnlPacients.Controls.Add(label4);
            pnlPacients.Controls.Add(lblTotalPacients);
            pnlPacients.Location = new Point(337, 110);
            pnlPacients.Name = "pnlPacients";
            pnlPacients.Size = new Size(210, 90);
            pnlPacients.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 53);
            label4.Name = "label4";
            label4.Size = new Size(149, 25);
            label4.TabIndex = 1;
            label4.Text = "Nuevos Pacientes";
            // 
            // lblTotalPacients
            // 
            lblTotalPacients.AutoSize = true;
            lblTotalPacients.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPacients.ForeColor = Color.FromArgb(30, 82, 155);
            lblTotalPacients.Location = new Point(65, 16);
            lblTotalPacients.Name = "lblTotalPacients";
            lblTotalPacients.Size = new Size(74, 28);
            lblTotalPacients.TabIndex = 0;
            lblTotalPacients.Text = "[####]";
            // 
            // pnlMonthlyPerformance
            // 
            pnlMonthlyPerformance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlMonthlyPerformance.Controls.Add(lblMonthlyAppointments);
            pnlMonthlyPerformance.Controls.Add(lblMedicalappointment15);
            pnlMonthlyPerformance.Controls.Add(lblWeeklyAppointment);
            pnlMonthlyPerformance.Controls.Add(label6);
            pnlMonthlyPerformance.Controls.Add(label5);
            pnlMonthlyPerformance.Controls.Add(label3);
            pnlMonthlyPerformance.Controls.Add(label2);
            pnlMonthlyPerformance.Location = new Point(76, 266);
            pnlMonthlyPerformance.Name = "pnlMonthlyPerformance";
            pnlMonthlyPerformance.Size = new Size(500, 200);
            pnlMonthlyPerformance.TabIndex = 3;
            // 
            // lblMonthlyAppointments
            // 
            lblMonthlyAppointments.AutoSize = true;
            lblMonthlyAppointments.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMonthlyAppointments.ForeColor = SystemColors.ControlDarkDark;
            lblMonthlyAppointments.Location = new Point(423, 153);
            lblMonthlyAppointments.Name = "lblMonthlyAppointments";
            lblMonthlyAppointments.Size = new Size(28, 32);
            lblMonthlyAppointments.TabIndex = 6;
            lblMonthlyAppointments.Text = "0";
            // 
            // lblMedicalappointment15
            // 
            lblMedicalappointment15.AutoSize = true;
            lblMedicalappointment15.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMedicalappointment15.ForeColor = SystemColors.ControlDarkDark;
            lblMedicalappointment15.Location = new Point(423, 114);
            lblMedicalappointment15.Name = "lblMedicalappointment15";
            lblMedicalappointment15.Size = new Size(28, 32);
            lblMedicalappointment15.TabIndex = 5;
            lblMedicalappointment15.Text = "0";
            // 
            // lblWeeklyAppointment
            // 
            lblWeeklyAppointment.AutoSize = true;
            lblWeeklyAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWeeklyAppointment.ForeColor = SystemColors.ControlDarkDark;
            lblWeeklyAppointment.Location = new Point(423, 71);
            lblWeeklyAppointment.Name = "lblWeeklyAppointment";
            lblWeeklyAppointment.Size = new Size(28, 32);
            lblWeeklyAppointment.TabIndex = 4;
            lblWeeklyAppointment.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 71);
            label6.Name = "label6";
            label6.Size = new Size(372, 25);
            label6.TabIndex = 3;
            label6.Text = "Total cita medica programadas semana actual";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 114);
            label5.Name = "label5";
            label5.Size = new Size(246, 25);
            label5.TabIndex = 2;
            label5.Text = "Total citas medicas del 1 al 15";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 153);
            label3.Name = "label3";
            label3.Size = new Size(239, 25);
            label3.TabIndex = 1;
            label3.Text = "Total citas medicas en el mes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(32, 82, 155);
            label2.Location = new Point(23, 21);
            label2.Name = "label2";
            label2.Size = new Size(264, 32);
            label2.TabIndex = 0;
            label2.Text = "Rendimiento Mensual";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Location = new Point(626, 266);
            panel5.Name = "panel5";
            panel5.Size = new Size(500, 200);
            panel5.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Location = new Point(76, 519);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 200);
            panel2.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Location = new Point(626, 519);
            panel3.Name = "panel3";
            panel3.Size = new Size(500, 200);
            panel3.TabIndex = 6;
            // 
            // VisualizeDataForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1199, 801);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel5);
            Controls.Add(pnlMonthlyPerformance);
            Controls.Add(pnlPacients);
            Controls.Add(pnlCustomer);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VisualizeDataForm";
            Text = "VisualizeDataForm";
            pnlCustomer.ResumeLayout(false);
            pnlCustomer.PerformLayout();
            pnlPacients.ResumeLayout(false);
            pnlPacients.PerformLayout();
            pnlMonthlyPerformance.ResumeLayout(false);
            pnlMonthlyPerformance.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnlCustomer;
        private Label lblTotalCustomers;
        private Label label1;
        private Panel pnlPacients;
        private Label label4;
        private Label lblTotalPacients;
        private Panel pnlMonthlyPerformance;
        private Panel panel5;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label lblMonthlyAppointments;
        private Label lblMedicalappointment15;
        private Label lblWeeklyAppointment;
    }
}