using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.Services.Interfaz_service
{
    public interface IUsuarioRepository
    {
        Task<UserAuthenticationDataDto?> GetUserAuthenticationDataAsync(
            string userName);

        Task UpdateLastLoginAsync(int userId, DateTime lastLogin);

        Task ResetPasswordAsync(string userName, string passwordHash);
    }
}
