using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Servicio
{
    public int ServicioId { get; set; }

    public string CodigoServicio { get; set; } = null!;

    public string NombreServicio { get; set; } = null!;

    public string CategoriaServicio { get; set; } = null!;

    public int EstaActivo { get; set; }

    public virtual ICollection<CargosPaciente> CargosPacientes { get; set; } = new List<CargosPaciente>();
}
