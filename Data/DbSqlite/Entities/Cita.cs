using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Cita
{
    public int CitaId { get; set; }

    public int PacienteId { get; set; }

    public int TipoCitaId { get; set; }

    public int EstadoCitaId { get; set; }

    public int? VeterinarioId { get; set; }

    public int UsuarioCreacionId { get; set; }

    public string FechaHoraInicioProgramada { get; set; } = null!;

    public string FechaHoraFinProgramada { get; set; } = null!;

    public string? Observaciones { get; set; }

    public string FechaCreacion { get; set; } = null!;

    public string? FechaActualizacion { get; set; }

    public virtual EstadosCita EstadoCita { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual TiposCita TipoCita { get; set; } = null!;

    public virtual Usuario UsuarioCreacion { get; set; } = null!;

    public virtual Empleado? Veterinario { get; set; }

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();
}
