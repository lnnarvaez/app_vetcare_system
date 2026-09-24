using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Presenter;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.View
{
    public partial class ListCustomerForm : Form, ICustomerListView
    {
        #region Variables Readonly
        private const string EditColumnName = "EditCustomerColumn";
        private readonly CustomerListPresenter _presenter;
        private readonly BindingSource _bindingSource = new();
        private bool _isClosing;
        // Notifica al formulario principal qué cliente se desea editar. Solamente se transporta el Id;
        // la vista no accede al repositorio.
        public event Action<int>? EditCustomerRequested;
        #endregion

        #region Constructors
        public ListCustomerForm(ICustomerRepository repository)
        {
            InitializeComponent();

            ConfigureDataGridView();

            _presenter = new CustomerListPresenter(this, repository);
            FormClosing += ListCustomerForm_FormClosing;
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
            if (_isClosing || IsDisposed || Disposing)
            {
                return;
            }

            _presenter.LoadCustomers();
        }

        private void ListCustomerForm_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            _isClosing = true;
            dgvCustomerList.CellContentClick -= dgvCustomerList_CellContentClick;
            _bindingSource.DataSource = null;
        }

        /// <summary>
        /// Regresa al menú anterior.
        /// </summary>
        private void btnHome_Click(object sender, EventArgs e)
        {
            Close();
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
            dgvCustomerList.RowTemplate.Height = 32;
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

            /*dgvCustomerList.Columns.Add(new DataGridViewButtonColumn
            {
                Name = EditColumnName,
                HeaderText = "Editar",
                //Text = "✎",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Width = 96,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });*/

            // La propiedad "editCustomer" debe coincidir con el nombre

            // real del recurso agregado en Properties/Resources.resx.
            var editColumn = new DataGridViewImageColumn
            {
                Name = EditColumnName,
                HeaderText = "Editar",
                Image = Properties.Resources.btn_edit,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 96,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            // Centra el icono dentro de la celda.
            editColumn.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // Texto mostrado como ayuda al pasar el mouse.
            editColumn.ToolTipText = "Editar información del cliente";

            dgvCustomerList.Columns.Add(editColumn);

            // Detecta cuando el usuario pulsa el botón de edición.
            dgvCustomerList.CellContentClick += dgvCustomerList_CellContentClick;
            dgvCustomerList.DataSource = _bindingSource;
        }

        #endregion

        #region Implementación ICustomerListView
        public void ShowCustomers(IEnumerable<CustomersDto> customers)
        {
            if (_isClosing || IsDisposed || Disposing)
            {
                return;
            }

            _bindingSource.DataSource = customers.ToList();
        }

        public void ShowNoRecords()
        {
            if (_isClosing || IsDisposed || Disposing)
            {
                return;
            }

            MessageBox.Show("No se encontraron clientes registrados en el sistema.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowErrorMessage(string mensaje)
        {
            if (_isClosing || IsDisposed || Disposing)
            {
                return;
            }

            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        private void dgvCustomerList_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_isClosing || IsDisposed || Disposing ||
                    !dgvCustomerList.IsHandleCreated)
                {
                    return;
                }

                // Ignora el encabezado de la tabla.
                if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
                    e.RowIndex >= dgvCustomerList.Rows.Count ||
                    e.ColumnIndex >= dgvCustomerList.Columns.Count)
                {
                    return;
                }

                // Ignora cualquier columna que no sea la de edición.
                if (dgvCustomerList.Columns[e.ColumnIndex].Name
                    != EditColumnName)
                {
                    return;
                }

                // Obtiene el objeto real asociado a la fila.
                // No se utiliza el índice como identificador del cliente.
                if (dgvCustomerList.Rows[e.RowIndex]
                        .DataBoundItem is not CustomersDto customer)
                {
                    ShowErrorMessage(
                        "No fue posible identificar el cliente seleccionado.");
                    return;
                }

                if (customer.Id <= 0)
                {
                    ShowErrorMessage(
                        "El cliente seleccionado no tiene un Id válido.");
                    return;
                }

                // Envía solamente el Id al formulario principal.
                EditCustomerRequested?.Invoke(customer.Id);
            }
            catch (ObjectDisposedException)
            {
                // El formulario o la cuadrícula se cerró durante el evento.
            }
            catch (ArgumentOutOfRangeException)
            {
                // La cuadrícula cambió mientras se procesaba el evento.
            }
            catch (Exception ex)
            {
                ShowErrorMessage(
                    $"No fue posible iniciar la edición: {ex.Message}");
            }
        }

    } //End class
} //end namespace
