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
            pnlTitle = new Panel();
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
            pnlGraphics = new Panel();
            pnlBars = new Panel();
            frmBarsAppointmentStatus = new ScottPlot.WinForms.FormsPlot();
            panel3 = new Panel();
            pnlCustomer.SuspendLayout();
            pnlPacients.SuspendLayout();
            pnlMonthlyPerformance.SuspendLayout();
            pnlGraphics.SuspendLayout();
            pnlBars.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitle
            // 
            pnlTitle.BackColor = Color.FromArgb(158, 158, 158);
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Location = new Point(0, 0);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(1501, 60);
            pnlTitle.TabIndex = 0;
            // 
            // pnlCustomer
            // 
            pnlCustomer.BackColor = Color.FromArgb(30, 82, 155);
            pnlCustomer.Controls.Add(lblTotalCustomers);
            pnlCustomer.Controls.Add(label1);
            pnlCustomer.Location = new Point(76, 110);
            pnlCustomer.Name = "pnlCustomer";
            pnlCustomer.Size = new Size(253, 106);
            pnlCustomer.TabIndex = 1;
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCustomers.ForeColor = Color.FromArgb(240, 241, 242);
            lblTotalCustomers.Location = new Point(76, 28);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(88, 32);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "[####]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(52, 69);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 0;
            label1.Text = "Nuevos Clientes";
            // 
            // pnlPacients
            // 
            pnlPacients.BackColor = Color.FromArgb(30, 82, 155);
            pnlPacients.Controls.Add(label4);
            pnlPacients.Controls.Add(lblTotalPacients);
            pnlPacients.Location = new Point(382, 110);
            pnlPacients.Name = "pnlPacients";
            pnlPacients.Size = new Size(253, 106);
            pnlPacients.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(53, 69);
            label4.Name = "label4";
            label4.Size = new Size(149, 25);
            label4.TabIndex = 1;
            label4.Text = "Nuevos Pacientes";
            // 
            // lblTotalPacients
            // 
            lblTotalPacients.AutoSize = true;
            lblTotalPacients.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPacients.ForeColor = Color.FromArgb(240, 241, 242);
            lblTotalPacients.Location = new Point(85, 28);
            lblTotalPacients.Name = "lblTotalPacients";
            lblTotalPacients.Size = new Size(88, 32);
            lblTotalPacients.TabIndex = 0;
            lblTotalPacients.Text = "[####]";
            // 
            // pnlMonthlyPerformance
            // 
            pnlMonthlyPerformance.BorderStyle = BorderStyle.FixedSingle;
            pnlMonthlyPerformance.Controls.Add(lblMonthlyAppointments);
            pnlMonthlyPerformance.Controls.Add(lblMedicalappointment15);
            pnlMonthlyPerformance.Controls.Add(lblWeeklyAppointment);
            pnlMonthlyPerformance.Controls.Add(label6);
            pnlMonthlyPerformance.Controls.Add(label5);
            pnlMonthlyPerformance.Controls.Add(label3);
            pnlMonthlyPerformance.Controls.Add(label2);
            pnlMonthlyPerformance.Location = new Point(76, 266);
            pnlMonthlyPerformance.Name = "pnlMonthlyPerformance";
            pnlMonthlyPerformance.Size = new Size(634, 260);
            pnlMonthlyPerformance.TabIndex = 3;
            // 
            // lblMonthlyAppointments
            // 
            lblMonthlyAppointments.AutoSize = true;
            lblMonthlyAppointments.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMonthlyAppointments.ForeColor = SystemColors.ControlDarkDark;
            lblMonthlyAppointments.Location = new Point(554, 189);
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
            lblMedicalappointment15.Location = new Point(554, 137);
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
            lblWeeklyAppointment.Location = new Point(554, 88);
            lblWeeklyAppointment.Name = "lblWeeklyAppointment";
            lblWeeklyAppointment.Size = new Size(28, 32);
            lblWeeklyAppointment.TabIndex = 4;
            lblWeeklyAppointment.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 94);
            label6.Name = "label6";
            label6.Size = new Size(372, 25);
            label6.TabIndex = 3;
            label6.Text = "Total cita medica programadas semana actual";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 144);
            label5.Name = "label5";
            label5.Size = new Size(246, 25);
            label5.TabIndex = 2;
            label5.Text = "Total citas medicas del 1 al 15";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 196);
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
            label2.Location = new Point(181, 21);
            label2.Name = "label2";
            label2.Size = new Size(264, 32);
            label2.TabIndex = 0;
            label2.Text = "Rendimiento Mensual";
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Location = new Point(791, 266);
            panel5.Name = "panel5";
            panel5.Size = new Size(634, 260);
            panel5.TabIndex = 4;
            // 
            // pnlGraphics
            // 
            pnlGraphics.BorderStyle = BorderStyle.FixedSingle;
            pnlGraphics.Controls.Add(pnlBars);
            pnlGraphics.Location = new Point(76, 589);
            pnlGraphics.Name = "pnlGraphics";
            pnlGraphics.Padding = new Padding(8);
            pnlGraphics.Size = new Size(634, 385);
            pnlGraphics.TabIndex = 5;
            // 
            // pnlBars
            // 
            pnlBars.Controls.Add(frmBarsAppointmentStatus);
            pnlBars.Cursor = Cursors.Hand;
            pnlBars.Location = new Point(11, 11);
            pnlBars.Name = "pnlBars";
            pnlBars.Padding = new Padding(4);
            pnlBars.Size = new Size(610, 359);
            pnlBars.TabIndex = 0;
            // 
            // frmBarsAppointmentStatus
            // 
            frmBarsAppointmentStatus.Dock = DockStyle.Fill;
            frmBarsAppointmentStatus.Location = new Point(4, 4);
            frmBarsAppointmentStatus.Name = "frmBarsAppointmentStatus";
            frmBarsAppointmentStatus.Size = new Size(602, 351);
            frmBarsAppointmentStatus.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(791, 589);
            panel3.Name = "panel3";
            panel3.Size = new Size(634, 385);
            panel3.TabIndex = 6;
            // 
            // VisualizeDataForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1501, 1083);
            Controls.Add(panel3);
            Controls.Add(pnlGraphics);
            Controls.Add(panel5);
            Controls.Add(pnlMonthlyPerformance);
            Controls.Add(pnlPacients);
            Controls.Add(pnlCustomer);
            Controls.Add(pnlTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VisualizeDataForm";
            Text = "VisualizeDataForm";
            pnlCustomer.ResumeLayout(false);
            pnlCustomer.PerformLayout();
            pnlPacients.ResumeLayout(false);
            pnlPacients.PerformLayout();
            pnlMonthlyPerformance.ResumeLayout(false);
            pnlMonthlyPerformance.PerformLayout();
            pnlGraphics.ResumeLayout(false);
            pnlBars.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitle;
        private Panel pnlCustomer;
        private Label lblTotalCustomers;
        private Label label1;
        private Panel pnlPacients;
        private Label label4;
        private Label lblTotalPacients;
        private Panel pnlMonthlyPerformance;
        private Panel panel5;
        private Panel pnlGraphics;
        private Panel panel3;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label lblMonthlyAppointments;
        private Label lblMedicalappointment15;
        private Label lblWeeklyAppointment;
        private Panel pnlBars;
        private ScottPlot.WinForms.FormsPlot frmBarsAppointmentStatus;
    }
}