using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Presenter;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.View
{
    public partial class ListCustomerForm : Form, ICustomerListView
    {
        #region Variables Readonly
        private readonly CustomerListPresenter _presenter;
        private readonly BindingSource _bindingSource = new();
        #endregion

        #region Constructors
        public ListCustomerForm (ICustomerRepository repository)
        {
            InitializeComponent();

            ConfigureDataGridView();

            _presenter = new CustomerListPresenter(this, repository);
        }
        
        #endregion Constructors

        #region Eventos

        /// <summary>
        /// Evento que informa al contenedor principal que el usuario desea registrar un nuevo cliente.
        /// </summary>
        public event EventHandler? NewCustomerRequested;

        #endregion

        /// <summary>
        /// Solicita al contenedor principal abrir el formulario de creación de clientes.
        /// </summary>
        
        #region Eventos del formulario

        private void ListCustomerForm_Load(object sender, EventArgs e)
        {
            _presenter.LoadCustomers();
        }

        /// <summary>
        /// Regresa al menú anterior.
        /// </summary>
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Solicita al contenedor principal abrir el formulario de creación de clientes.
        /// </summary>
        private void btnCustomerNew_Click(object sender, EventArgs e)
        {
            NewCustomerRequested?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region DataGridView

        private void ConfigureDataGridView()
        {
            dgvCustomerList.AutoGenerateColumns = false;
            dgvCustomerList.Columns.Clear();
            dgvCustomerList.ReadOnly = true;
            dgvCustomerList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerList.MultiSelect = false;

            // Mapeo manual de columnas con nombres legibles           

            dgvCustomerList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CustomersDto.NationalId),
                HeaderText = "Cédula",
                Width = 260
            });

            dgvCustomerList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CustomersDto.FullName),
                HeaderText = "Cliente",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCustomerList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CustomersDto.MainPhone),
                HeaderText = "Teléfono Principal",
                Width = 220
            });

            dgvCustomerList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CustomersDto.EmergencyPhone),
                HeaderText = "Teléfono Emergencia",
                Width = 220
            });

            dgvCustomerList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CustomersDto.Email),
                HeaderText = "Correo Electrónico",
                Width = 380
            });

            dgvCustomerList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CustomersDto.Address),
                HeaderText = "Dirección",
                Width = 320
            });

            dgvCustomerList.DataSource = _bindingSource;
        }

        #endregion

        #region Implementación ICustomerListView
        public void ShowCustomers (IEnumerable<CustomersDto> customers)
        {
            _bindingSource.DataSource = customers.ToList();
        }

        public void ShowNoRecords ()
        {
            MessageBox.Show("No se encontraron clientes registrados en el sistema.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

    } //End class
} //end namespace
