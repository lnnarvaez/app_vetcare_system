using app_vetcare_system.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_vetcare_system.View.Interfaz
{
    public interface ICustomerEditView
    {
        string FirstName { get; }
        string LastName { get; }
        string NationalId { get; }
        string MainPhone { get; }
        string? EmergencyPhone { get; }
        string? Address { get; }
        string? Email { get; }
        string? PreferredPaymentMethod { get; }

        // Carga la información consultada en los controles del formulario.
        void ShowCustomer(CustomersDto customer);

        void ShowMessage(string message);        
        
    } // end class
} // end namespace
