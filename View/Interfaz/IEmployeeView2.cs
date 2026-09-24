namespace app_vetcare_system.View.Interfaz
{
    public interface IEmployeeView2
    {
        // Propiedades de lectura / exctritura de los controles
        string Code { get; set; }
        string FullName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }

        //Eventos que van a ser notificados al presentador
        event EventHandler CreateClicked; //Cuando se clique el boton de crear

        //Metodos de control visual ordenados por el presentador
        void ShowMessage(string message, string title, bool isErrorMessage); //Muestra un mensaje en la vista
        void ResetFields (); //Resetea los campos de la vista
    }//end-interface
} //end -namespace
