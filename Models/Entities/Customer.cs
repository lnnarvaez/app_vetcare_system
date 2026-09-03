using System;
using System.Collections.Generic;

namespace app_vetcare_system.Models.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public string NationalId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
