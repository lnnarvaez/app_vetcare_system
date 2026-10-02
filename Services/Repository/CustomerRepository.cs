using app_vetcare_si.Data;
using app_vetcare_si.Models.Entities;
using app_vetcare_system.Models.DTOs;
using app_vetcare_system.Services.Interfaz_service;
using Microsoft.EntityFrameworkCore;

namespace app_vetcare_system.Services.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly VetCareDbSI2VContext _context;

        public CustomerRepository(VetCareDbSI2VContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtiene todos los clientes de la base de datos y los mapea a objetos CustomersDto
        /// </summary>
        /// <returns>Una lista de objetos CustomersDto</returns>
        public async Task<IReadOnlyList<CustomersDto>> GetAllCustomersAsync()
        {
            try
            {
                // Los clientes inactivos se excluyen para respetar el borrado lógico.
                return await _context.Clientes
                    .AsNoTracking()
                    .Where(cliente => cliente.EstaActivo)
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
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("No fue posible obtener los clientes.", ex);
            }
        }

        /// <summary>
        /// Crea un nuevo cliente en la base de datos a partir de un objeto CustomerCreateDto
        /// </summary>
        /// <param name="customer">El objeto CustomerCreateDto que contiene la información del cliente a crear</param>
        /// <returns>El Id del cliente creado</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el objeto CustomerCreateDto es nulo</exception>
        /// <exception cref="InvalidOperationException">Se lanza si ocurre un error al crear el cliente</exception>
        public async Task<int> CreateCustomerAsync(CustomerCreateDto customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(
                    "Información del cliente es vacía.");
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

                await _context.SaveChangesAsync();

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
        public async Task<CustomersDto?> GetCustomerByIdAsync(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Identificador del cliente no es válido.");
            }

            try
            {
                return await _context.Clientes
                    .AsNoTracking()
                    .Where(cliente =>
                        cliente.ClienteId == customerId &&
                        cliente.EstaActivo)
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
                    .SingleOrDefaultAsync();
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
        public async Task UpdateCustomerAsync(int customerId, CustomerCreateDto customer)
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
                var entity = await _context.Clientes
                    .SingleOrDefaultAsync(cliente =>
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

                await _context.SaveChangesAsync();
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

        /// <summary>
        /// Desactiva lógicamente un cliente sin eliminarlo de la base de datos.
        /// </summary>
        /// <param name="customerId">El Id del cliente a desactivar</param>
        /// <exception cref="ArgumentOutOfRangeException">El Id no es válido</exception>
        /// <exception cref="InvalidOperationException">No fue posible desactivar el cliente</exception>
        public async Task DeleteCustomerAsync(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(customerId),
                    "El Id del cliente no es válido.");
            }

            try
            {
                var entity = await _context.Clientes
                    .SingleOrDefaultAsync(cliente =>
                        cliente.ClienteId == customerId &&
                        cliente.EstaActivo);

                if (entity is null)
                {
                    throw new InvalidOperationException(
                        "El cliente no existe o ya está inactivo.");
                }

                entity.EstaActivo = false;
                entity.FechaActualizacion = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "No fue posible desactivar el cliente.",
                    ex);
            }
        }


    } //end class
} //end namespace
