using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class CargosPaciente
{
    public int CargoPacienteId { get; set; }

    public int PacienteId { get; set; }

    public int? ProductoId { get; set; }

    public int? ServicioId { get; set; }

    public int UsuarioCreacionId { get; set; }

    public string TipoCargo { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public string FechaHoraCargo { get; set; } = null!;

    public string FechaCreacion { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual Producto? Producto { get; set; }

    public virtual Servicio? Servicio { get; set; }

    public virtual Usuario UsuarioCreacion { get; set; } = null!;
}
