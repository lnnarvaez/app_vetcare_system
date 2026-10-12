using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Especy
{
    public int EspecieId { get; set; }

    public string NombreEspecie { get; set; } = null!;

    public int EstaActivo { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual ICollection<Raza> Razas { get; set; } = new List<Raza>();
}
