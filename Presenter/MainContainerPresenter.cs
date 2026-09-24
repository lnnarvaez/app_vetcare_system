using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.Presenter
{
    public class MainContainerPresenter
    {
        private readonly IMainContainer _view; //Referencia a la vista

        public MainContainerPresenter(IMainContainer view)
        {
            //Validar que la vista no sea nula
            _view = view ?? throw new ArgumentNullException("Se ha producido un error al intentar cargar ventana principal");
            //Suscribirse a los eventos de la vista
            _view.ClosedClicked += OnClosedClicked;
        }
        private void OnClosedClicked(object? sender, EventArgs e)
        {
            
        }

    }//end class
} //end namespace
