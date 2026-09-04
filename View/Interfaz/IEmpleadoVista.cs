namespace app_vetcare_system.View.Interfaz
{
    public interface IEmpleadoVista
    {
        #region Properties
        //Propiedades de lectura / escritura de los controles de la vista        
        public int EmpleadoId { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }        
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        #endregion

        #region Behaviors
        //Eventos que van a ser notificados al presentador
        event EventHandler CreateClicked; //Cuando se clique el boton de crear

        //Métodos para presentar mensajes
        void ShowMessage(string message, string title, bool isErrorMessage); //Muestra un mensaje en la vista

        // Método para resetear los campos de la vista
        void ResetFields(); //Resetea los campos de la vista

        #endregion Behaviors

    }//End class
} //End namespace
