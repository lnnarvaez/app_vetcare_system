namespace app_vetcare_system.View.Interfaz
{
    public interface ICreateCustomerView
    {
        #region Properties

        string FirstName { get; }
        string LastName { get; }
        string NationalId { get; }
        string MainPhone { get; }
        string? EmergencyPhone { get; }
        string? Address { get; }
        string? Email { get; }
        string? PreferredPaymentMethod { get; }

        #endregion

        void ShowMessage(string mensaje);

        void ClearCustomerForm();


    } // End interface
}   //End namespace