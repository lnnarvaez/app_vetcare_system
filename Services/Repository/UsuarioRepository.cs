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

        public async Task<UserAuthenticationDataDto?> GetUserAuthenticationDataAsync(
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
                return await _context.Usuarios
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
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "No fue posible consultar la información de autenticación.",
                    ex);
            }
        }

        public async Task UpdateLastLoginAsync(int userId, DateTime lastLogin)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            try
            {
                var user = await _context.Usuarios
                    .SingleOrDefaultAsync(usuario =>
                        usuario.UsuarioId == userId);

                if (user is null)
                {
                    throw new InvalidOperationException(
                        "El usuario no existe.");
                }

                user.FechaUltimaSesion = lastLogin;
                await _context.SaveChangesAsync();
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

        public async Task ResetPasswordAsync(string userName, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(
                    "El nombre de usuario es obligatorio.",
                    nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException(
                    "El hash de la contraseña es obligatorio.",
                    nameof(passwordHash));
            }

            try
            {
                var user = await _context.Usuarios
                    .SingleOrDefaultAsync(usuario =>
                        usuario.NombreUsuario == userName &&
                        usuario.EstaActivo);

                if (user is null)
                {
                    throw new InvalidOperationException(
                        "El usuario no existe o está inactivo.");
                }

                user.HashContrasena = passwordHash;
                user.FechaActualizacion = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "No fue posible actualizar la contraseña.",
                    ex);
            }
        }
    }
}
