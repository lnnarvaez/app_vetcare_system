using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.Services.Interfaz_service
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultDto> AuthenticateAsync(
            AuthenticationRequestDto request);

        Task ResetPasswordAsync(string userName, string newPassword);
    }
}
