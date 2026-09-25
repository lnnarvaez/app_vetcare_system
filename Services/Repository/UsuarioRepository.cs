using app_vetcare_si.Data;
using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using Microsoft.EntityFrameworkCore;

namespace app_vetcare_system.Services.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VetCareDbSI2VContext _context;

        public UsuarioRepository(VetCareDbSI2VContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public UserAuthenticationDataDto? GetUserAuthenticationData(
            string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(
                    "El nombre de usuario es obligatorio.",
                    nameof(userName));
            }

            try
            {
                return _context.Usuarios
                    .AsNoTracking()
                    .Where(usuario =>
                        usuario.NombreUsuario == userName &&
                        usuario.EstaActivo)
                    .Select(usuario => new UserAuthenticationDataDto
                    {
                        UserId = usuario.UsuarioId,
                        EmployeeId = usuario.EmpleadoId,
                        UserName = usuario.NombreUsuario,
                        PasswordHash = usuario.HashContrasena,
                        EmployeeName = usuario.Empleado.Nombre + " " +
                                       usuario.Empleado.Apellido,
                        Roles = usuario.RolesUsuarios
                            .Where(rolesUsuario =>
                                rolesUsuario.Rol != null &&
                                rolesUsuario.Rol.EstaActivo)
                            .Select(rolesUsuario =>
                                rolesUsuario.Rol.NombreRol)
                            .ToList()
                    })
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "No fue posible consultar la información de autenticación.",
                    ex);
            }
        }

        public void UpdateLastLogin(int userId, DateTime lastLogin)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            try
            {
                var user = _context.Usuarios
                    .SingleOrDefault(usuario =>
                        usuario.UsuarioId == userId);

                if (user is null)
                {
                    throw new InvalidOperationException(
                        "El usuario no existe.");
                }

                user.FechaUltimaSesion = lastLogin;
                _context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "No fue posible actualizar la última sesión.",
                    ex);
            }
        }
    }
}
