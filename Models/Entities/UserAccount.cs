using System;
using System.Collections.Generic;

namespace app_vetcare_system.Models.Entities;

public partial class UserAccount
{
    public int UserAccountId { get; set; }

    public int EmployeeId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? LastLoginAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
