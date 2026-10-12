using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Visita
{
    public int VisitaId { get; set; }

    public int PacienteId { get; set; }

    public int TipoVisitaId { get; set; }

    public int? VeterinarioId { get; set; }

    public int? CitaId { get; set; }

    public int UsuarioCreacionId { get; set; }

    public string FechaHoraVisita { get; set; } = null!;

    public string? Motivo { get; set; }

    public decimal? PesoKg { get; set; }

    public decimal? TemperaturaC { get; set; }

    public string? Observaciones { get; set; }

    public string FechaCreacion { get; set; } = null!;

    public virtual Cita? Cita { get; set; }

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual TiposVisita TipoVisita { get; set; } = null!;

    public virtual Usuario UsuarioCreacion { get; set; } = null!;

    public virtual Empleado? Veterinario { get; set; }
}
