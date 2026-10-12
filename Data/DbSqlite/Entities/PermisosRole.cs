using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class PermisosRole
{
    public int? RolId { get; set; }

    public int PermisosRolesId { get; set; }

    public int? PermisoId { get; set; }

    public string FechaAsignacion { get; set; } = null!;

    public virtual Permiso? Permiso { get; set; }

    public virtual Role? Rol { get; set; }
}
