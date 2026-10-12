using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public string NombreProducto { get; set; } = null!;

    public string TipoProducto { get; set; } = null!;

    public int EstaActivo { get; set; }

    public virtual ICollection<CargosPaciente> CargosPacientes { get; set; } = new List<CargosPaciente>();
}
