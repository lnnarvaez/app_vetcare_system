using System.Security.Cryptography;
using app_vetcare_system.Services.Interfaz_service;

namespace app_vetcare_system.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const string HashVersion = "PBKDF2-SHA256";
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 210000;

        public string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException(
                    "La contraseña es obligatoria.",
                    nameof(password));
            }

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256,
                HashSize);

            return string.Join(
                ".",
                HashVersion,
                Iterations,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            if (string.IsNullOrEmpty(password) ||
                string.IsNullOrWhiteSpace(passwordHash))
            {
                return false;
            }

            string[] parts = passwordHash.Split('.');

            if (parts.Length != 4 ||
                parts[0] != HashVersion ||
                !int.TryParse(parts[1], out int iterations) ||
                iterations <= 0)
            {
                return false;
            }

            try
            {
                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] expectedHash = Convert.FromBase64String(parts[3]);
                byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    iterations,
                    HashAlgorithmName.SHA256,
                    expectedHash.Length);

                return CryptographicOperations.FixedTimeEquals(
                    actualHash,
                    expectedHash);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}
