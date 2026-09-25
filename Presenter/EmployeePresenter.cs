using System.Diagnostics;
using app_vetcare_system.Data;
using app_vetcare_system.Models.Entities;
using app_vetcare_system.View.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace app_vetcare_system.Presenter
{
    public class EmployeePresenter
    {
        private readonly IEmployeeView2 _view; //Referencia a la vista

        public EmployeePresenter(IEmployeeView2 view)
        {
            //Validar que la vista no sea nula
            _view = view ?? throw new ArgumentNullException(nameof(view)) ;

            //Suscribirse a los eventos de la vista
            _view.CreateClicked += OnCreateClicked;
        }

        private void OnCreateClicked (object? sender, EventArgs e)
        {
            //1. Extraer y limpiar datos de la vista
            string code = _view.Code.Trim();
            string fullname = _view.FullName.Trim();
            string email = _view.Email.Trim();
            string? phone = string.IsNullOrWhiteSpace(_view.Phone) ? null :
                _view.Phone.Trim(); 
            
            //2. Validación de reglas de negocio
            if (string.IsNullOrWhiteSpace (code) || string.IsNullOrWhiteSpace (fullname)
                || string.IsNullOrWhiteSpace (email))
            {
                //Mostrar mensaje de error
                _view.ShowMessage("Existen campos obligatorios sin completar.", "Campos Obligatorios", true);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                //Mostrar mensaje de error
                _view.ShowMessage("El correo electrónico no es válido.", "Correo incorrecto", true);
                return;
            }

            //3. Proceso y Persistencia con EF
            try
            {
                using (var db = new VetCareDbContext())
                {
                    //Verificar si el código ya existe
                    if (db.Employees.Any(emp => emp.Code == code))
                    {
                        _view.ShowMessage("El código de empleado ya existe.", "Código duplicado", true);
                        return;
                    }
                    //Crear un nuevo objeto Employee
                    var newEmployee = new Employee
                    {
                        Code = code,
                        FullName = fullname,
                        Email = email,
                        Phone = phone
                    };
                    //Agregar y guardar cambios
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                    //Mostrar mensaje de éxito
                    _view.ShowMessage("Empleado creado exitosamente.", "Registro Creado", false);
                }
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine(ex);

                //Mostrar mensaje de error
                _view.ShowMessage("Error Inesperado al procesar datos: ex.Message ", "Acceso Denegado", true);
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                //Mostrar mensaje de error
                _view.ShowMessage("Error inesperado:  { ex.Message} ", "Error Crítico", true);
            }
            finally
            {

            }
        }//end-OnCreateClicked



    }//end-class
}//end| 
