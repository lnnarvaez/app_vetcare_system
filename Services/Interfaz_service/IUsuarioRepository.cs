using app_vetcare_system.Models.DTOs;

namespace app_vetcare_system.Services.Interfaz_service
{
    public interface IUsuarioRepository
    {
        UserAuthenticationDataDto? GetUserAuthenticationData(
            string userName);

        void UpdateLastLogin(int userId, DateTime lastLogin);
    }
}
