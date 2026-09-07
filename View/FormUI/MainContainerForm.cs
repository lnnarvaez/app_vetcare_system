using app_vetcare_si.Data;
using app_vetcare_system.Services;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View;

namespace app_vetcare_system
{
    public partial class MainContainerForm : Form
    {
        private readonly VetCareDbSI2VContext _context;

        public MainContainerForm()
        {
            InitializeComponent();
            _context = new VetCareDbSI2VContext();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Cargar un formulario hijo en el panel derecho del contenedor principal
        /// </summary>
        /// <param name="ChildForm">El formulario hijo a cargar</param>
        private void LoadFormIntoPanel(Form ChildForm)
        {
            if (splitMain.Panel2.Controls.Count > 0)
            {
                splitMain.Panel2.Controls[0].Dispose();
                var currentForm = splitMain.Panel2.Controls[0] as Form;

                currentForm?.Close();
            }
            splitMain.Panel2.Controls.Clear();

            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;

            splitMain.Panel2.Controls.Add(ChildForm);
            splitMain.Panel2.Tag = ChildForm;
            ChildForm.Show();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            ICustomerRepository repository = new CustomerRepository(_context);

            var customerForm = new ListCustomerForm(repository);

            //Cargar el formulario de clientes en el panel derecho
            LoadFormIntoPanel(customerForm);
        }
    } //End class   
} //End namespace
