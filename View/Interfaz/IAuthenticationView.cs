using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.View.Interfaz
{
    public interface IAuthenticationView
    {
        string UserName { get; }

        string Password { get; }

        void ShowAuthenticationError(string message);

        void ShowAuthenticatedUser(AuthenticatedUserDto user);
    }
}
