using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class EstadosGuarderia
{
    public int EstadoGuarderiaId { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<EstanciasGuarderium> EstanciasGuarderia { get; set; } = new List<EstanciasGuarderium>();
}
