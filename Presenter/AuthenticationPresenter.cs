using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using app_vetcare_system.View.Interfaz;

namespace app_vetcare_system.Presenter
{
    public class AuthenticationPresenter
    {
        private readonly IAuthenticationView _view;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationPresenter(
            IAuthenticationView view,
            IAuthenticationService authenticationService)
        {
            _view = view
                ?? throw new ArgumentNullException(nameof(view));

            _authenticationService = authenticationService
                ?? throw new ArgumentNullException(
                    nameof(authenticationService));
        }

        public void Authenticate()
        {
            try
            {
                var request = new AuthenticationRequestDto
                {
                    UserName = _view.UserName,
                    Password = _view.Password
                };

                AuthenticationResultDto result =
                    _authenticationService.Authenticate(request);

                if (!result.IsAuthenticated || result.User is null)
                {
                    _view.ShowAuthenticationError(result.Message);
                    return;
                }

                _view.ShowAuthenticatedUser(result.User);
            }
            catch (Exception)
            {
                _view.ShowAuthenticationError(
                    "No fue posible procesar la autenticación.");
            }
        }
    }
}
