using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Role
{
    public int RolId { get; set; }

    public string NombreRol { get; set; } = null!;

    public int EstaActivo { get; set; }

    public string FechaCreacion { get; set; } = null!;

    public virtual ICollection<PermisosRole> PermisosRoles { get; set; } = new List<PermisosRole>();

    public virtual ICollection<RolesUsuario> RolesUsuarios { get; set; } = new List<RolesUsuario>();
}
