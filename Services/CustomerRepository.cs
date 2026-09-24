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

        /// <summary>
        /// Obtiene un cliente por su Id y lo mapea a un objeto CustomersDto
        /// </summary>
        /// <param name="customerId">El Id del cliente a obtener</param>
        /// <returns>Un objeto CustomersDto si se encuentra el cliente, de lo contrario null</returns>
        /// <exception cref="ArgumentOutOfRangeException"> El Id del cliente no es válido </exception>
        /// <exception cref="InvalidOperationException"> No fue posible consultar el cliente </exception>
        public CustomersDto? GetCustomerById(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Identificador del cliente no es válido.");
            }

            try
            {
                return _context.Clientes
                    .AsNoTracking()
                    .Where(cliente =>
                        cliente.ClienteId == customerId)
                    .Select(cliente => new CustomersDto
                    {
                        Id = cliente.ClienteId,
                        FirstName = cliente.Nombre,
                        LastName = cliente.Apellido,
                        NationalId = cliente.Cedula,
                        MainPhone = cliente.TelefonoPrincipal,
                        EmergencyPhone = cliente.TelefonoEmergencia,
                        Address = cliente.Direccion,
                        Email = cliente.CorreoElectronico,
                        PreferredPaymentMethod = cliente.MetodoPagoPreferido
                    })
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("No fue posible consultar el cliente.",
                    ex);
            }//end try-catch
        }

        /// <summary>
        /// Actualiza la información de un cliente existente en la base de datos
        /// </summary>
        /// <param name="customerId">El Id del cliente a actualizar</param>
        /// <param name="customer">Los datos del cliente a actualizar</param>
        /// <exception cref="ArgumentOutOfRangeException"> El Id del cliente no es válido </exception>
        /// <exception cref="ArgumentNullException"> Los datos del cliente son nulos </exception>
        /// <exception cref="InvalidOperationException"> No fue posible actualizar el cliente </exception>
        public void UpdateCustomer(int customerId, CustomerCreateDto customer)
        {
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Identificador del cliente no es válido.");
            }

            if (customer is null)
            {
                throw new ArgumentNullException("El cliente no existe.");
            }

            try
            {
                var entity = _context.Clientes
                    .SingleOrDefault(cliente =>
                        cliente.ClienteId == customerId);

                if (entity is null)
                {
                    throw new InvalidOperationException("El cliente no se coincide con el especificado.");
                }

                entity.Nombre = customer.FirstName;
                entity.Apellido = customer.LastName;
                entity.Cedula = customer.NationalId;
                entity.TelefonoPrincipal = customer.MainPhone;
                entity.TelefonoEmergencia =
                    customer.EmergencyPhone;
                entity.Direccion = customer.Address;
                entity.CorreoElectronico =
                    customer.Email;
                entity.MetodoPagoPreferido =
                    customer.PreferredPaymentMethod;
                entity.FechaActualizacion = DateTime.Now;

                _context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("No fue posible actualizar el cliente.",
                    ex);
            }
        }


    } //end class
} //end namespace
