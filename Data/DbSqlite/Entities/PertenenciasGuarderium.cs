using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class PertenenciasGuarderium
{
    public int PertenenciaGuarderiaId { get; set; }

    public int EstanciaGuarderiaId { get; set; }

    public string DescripcionPertenencia { get; set; } = null!;

    public virtual EstanciasGuarderium EstanciaGuarderia { get; set; } = null!;
}
