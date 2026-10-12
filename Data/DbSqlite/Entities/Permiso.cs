using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Permiso
{
    public int PermisoId { get; set; }

    public string CodigoPermiso { get; set; } = null!;

    public string NombrePermiso { get; set; } = null!;

    public int EstaActivo { get; set; }

    public virtual ICollection<PermisosRole> PermisosRoles { get; set; } = new List<PermisosRole>();
}
