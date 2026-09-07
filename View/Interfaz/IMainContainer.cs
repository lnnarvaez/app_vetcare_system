namespace app_vetcare_system.View.Interfaz
{
    public interface IMainContainer
    {
        //Eventos que van a ser notificados al presentador
        event EventHandler ClosedClicked; //Cuando se clique el boton de cerrar sesión

        //Metodos de control visual ordenados por el presentador
        void ShowMessage(string message, string title);
    } //End interface
} //end namespace
