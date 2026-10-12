using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class VacunacionesPaciente
{
    public int VacunacionPacienteId { get; set; }

    public int PacienteId { get; set; }

    public int VacunaId { get; set; }

    public int? AsistenteId { get; set; }

    public int UsuarioCreacionId { get; set; }

    public string FechaHoraAplicacion { get; set; } = null!;

    public string? FechaProximaAplicacion { get; set; }

    public string? Observaciones { get; set; }

    public string FechaCreacion { get; set; } = null!;

    public virtual Empleado? Asistente { get; set; }

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual Usuario UsuarioCreacion { get; set; } = null!;

    public virtual Vacuna Vacuna { get; set; } = null!;
}
