using System;
using System.Collections.Generic;

namespace app_vetcare_system.Models.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Code { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual UserAccount? UserAccount { get; set; }
}
