using app_vetcare_si.Data;
using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using Microsoft.EntityFrameworkCore;

namespace app_vetcare_system.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        //Manejar el contexto de la base de datos
        private readonly VetCareDbSI2VContext _context;

        //Constructor que recibe el contexto de la base de datos
        public CustomerRepository(VetCareDbSI2VContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los clientes de la base de datos y los mapea a objetos CustomersDto
        /// </summary>
        /// <returns>Una lista de objetos CustomersDto</returns>
        public IEnumerable<CustomersDto> GetAllCustomers()
        {
            try
            {
                return _context.Clientes
                .AsNoTracking()
                .Select(c => new CustomersDto
                {
                    Id = c.ClienteId,
                    FirstName = c.Nombre,
                    LastName = c.Apellido,
                    NationalId = c.Cedula,
                    MainPhone = c.TelefonoPrincipal,
                    EmergencyPhone = c.TelefonoEmergencia,
                    Address = c.Direccion,
                    Email = c.CorreoElectronico
                })
                .ToList();
                            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new ArgumentNullException("Error en el acceso a clientes:", ex);
            }
            
        }
    } //end class
} //end namespace
