namespace app_vetcare_system.Services.Interfaz_service
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);

        bool VerifyPassword(string password, string passwordHash);
    }
}
