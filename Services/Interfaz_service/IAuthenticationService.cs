using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.Services.Interfaz_service
{
    public interface IAuthenticationService
    {
        AuthenticationResultDto Authenticate(
            AuthenticationRequestDto request);

        void ResetPassword(string userName, string newPassword);
    }
}
