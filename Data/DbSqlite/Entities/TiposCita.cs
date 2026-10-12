using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class TiposCita
{
    public int TipoCitaId { get; set; }

    public string NombreTipoCita { get; set; } = null!;

    public int EstaActivo { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
