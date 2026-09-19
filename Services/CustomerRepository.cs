using app_vetcare_si.Data;
using app_vetcare_si.Models.Entities;
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
                throw new InvalidOperationException("No fue posible obtener los clientes.", ex);
            }
            
        }

        public int CreateCustomer(CustomerCreateDto customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(
                    "Información del cliente es nula.");
            }

            try
            {
                var entity = new Cliente
                {
                    Nombre = customer.FirstName,
                    Apellido = customer.LastName,
                    Cedula = customer.NationalId,
                    TelefonoPrincipal = customer.MainPhone,
                    TelefonoEmergencia = customer.EmergencyPhone,
                    Direccion = customer.Address,
                    CorreoElectronico = customer.Email,
                    MetodoPagoPreferido =
                        customer.PreferredPaymentMethod,
                    //EstaActivo = true
                };

                _context.Clientes.Add(entity);

                _context.SaveChanges();

                return entity.ClienteId;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Error al crear el cliente.",
                    ex);
            } //End try-catch
        } //end CreateCustomer
   

    } //end class
} //end namespace
