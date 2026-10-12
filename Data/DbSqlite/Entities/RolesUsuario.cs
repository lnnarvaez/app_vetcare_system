using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class RolesUsuario
{
    public int? UsuarioId { get; set; }

    public int RolesUsuarioId { get; set; }

    public int? RolId { get; set; }

    public string FechaAsignacion { get; set; } = null!;

    public virtual Role? Rol { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
