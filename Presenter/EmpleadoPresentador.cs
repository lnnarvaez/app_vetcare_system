using System.Diagnostics;
using app_vetcare_si.Data;
using app_vetcare_si.Models.Entities;
using app_vetcare_system.View.Interfaz;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace app_vetcare_system.Presenter
{
    public class EmpleadoPresentador
    {
        // Variable que referencia a la interfaz que representa la vista
        private readonly IEmpleadoVista _eVista; 

        public EmpleadoPresentador(IEmpleadoVista eVista)
        {
            //Validar que no se haya pasado una referencia nula
            _eVista = eVista ?? throw new ArgumentNullException(nameof(eVista));

            //Suscribirse a los eventos de la vista
            //Cuando se clique el boton de crear que esta en la vista

            _eVista.CreateClicked += OnCreateClicked;

        }

        public void OnCreateClicked(object? sender, EventArgs e)
        {
            //1. Extraer y limpiar datos que se capturan el Formulario
            string cedula = _eVista.Cedula.Trim();
            string nombre = _eVista.Nombre.Trim();
            string apellido = _eVista.Apellido.Trim();
            string telefono = _eVista.Telefono.Trim();
            string correoElectronico = _eVista.CorreoElectronico.Trim();
            
            //2. Validación de reglas de negocio
            if (string.IsNullOrWhiteSpace(nombre) || 
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(cedula) || 
                string.IsNullOrWhiteSpace(correoElectronico))
            {
                //Mostrar mensaje de error
                _eVista.ShowMessage("Existen campos obligatorios sin completar.", "Campos Obligatorios", true);
                return;
            }

            if (!correoElectronico.Contains("@") || 
                !correoElectronico.Contains("."))
            {
                //Mostrar mensaje de error
                _eVista.ShowMessage("El correo electrónico no es válido.", "Correo incorrecto", true);
                return;
            }

            //3. Proceso y Persistencia con EF
            try
            {
                using (var db = new VetCareDbSI2VContext())
                {
                    //Verificar si la cédula ya existe
                    if (db.Empleados.Any(emp => emp.Cedula == cedula))
                    {
                        _eVista.ShowMessage("La cédula del empleado ya existe.", "Cédula duplicada", true);
                        return;
                    }
                    //Crear un nuevo objeto Empleado
                    var nuevoEmpleado = new Empleado
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        Cedula = cedula,
                        Telefono = telefono,
                        CorreoElectronico = correoElectronico,
                        FechaCreacion = DateTime.Now,
                        EstaActivo = true
                    };
                    //Agregar el nuevo empleado a la base de datos
                    db.Empleados.Add(nuevoEmpleado);
                    db.SaveChanges();
                    //Mostrar mensaje de éxito
                    _eVista.ShowMessage("Empleado creado exitosamente.", "Registro exitoso", false);
                    //Resetear los campos de la vista
                    _eVista.ResetFields();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                //Mostrar mensaje de error en caso de excepción
                _eVista.ShowMessage($"Ocurrió un error al intentar crear el empleado", "Error de operación", true);
            }
        }

    } //end class
} // end namespace
