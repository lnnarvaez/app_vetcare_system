using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Vacuna
{
    public int VacunaId { get; set; }

    public string NombreVacuna { get; set; } = null!;

    public string? Fabricante { get; set; }

    public int EstaActivo { get; set; }

    public virtual ICollection<VacunacionesPaciente> VacunacionesPacientes { get; set; } = new List<VacunacionesPaciente>();
}
