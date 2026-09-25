using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;

namespace app_vetcare_system.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(
            IUsuarioRepository usuarioRepository,
            IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository
                ?? throw new ArgumentNullException(
                    nameof(usuarioRepository));

            _passwordHasher = passwordHasher
                ?? throw new ArgumentNullException(
                    nameof(passwordHasher));
        }

        public AuthenticationResultDto Authenticate(
            AuthenticationRequestDto request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string userName = request.UserName.Trim();

            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrEmpty(request.Password))
            {
                return AuthenticationResultDto.Failure(
                    "El usuario y la contraseña son obligatorios.");
            }

            UserAuthenticationDataDto? user =
                _usuarioRepository.GetUserAuthenticationData(userName);

            if (user is null ||
                !_passwordHasher.VerifyPassword(
                    request.Password,
                    user.PasswordHash))
            {
                return AuthenticationResultDto.Failure(
                    "El usuario o la contraseña no son válidos.");
            }

            _usuarioRepository.UpdateLastLogin(
                user.UserId,
                DateTime.Now);

            return AuthenticationResultDto.Success(
                new AuthenticatedUserDto
                {
                    UserId = user.UserId,
                    EmployeeId = user.EmployeeId,
                    UserName = user.UserName,
                    EmployeeName = user.EmployeeName,
                    Roles = user.Roles
                });
        }
    }
}
