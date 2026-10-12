using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class EstadosCita
{
    public int EstadoCitaId { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
