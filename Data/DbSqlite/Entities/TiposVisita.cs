using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class TiposVisita
{
    public int TipoVisitaId { get; set; }

    public string NombreTipoVisita { get; set; } = null!;

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();
}
