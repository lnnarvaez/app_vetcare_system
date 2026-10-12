using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class EstanciasGuarderium
{
    public int EstanciaGuarderiaId { get; set; }

    public int PacienteId { get; set; }

    public int EstadoGuarderiaId { get; set; }

    public int UsuarioCreacionId { get; set; }

    public string FechaHoraEntrada { get; set; } = null!;

    public string? FechaHoraSalida { get; set; }

    public string? InstruccionesAlimentacion { get; set; }

    public string? InstruccionesSocializacion { get; set; }

    public string FechaCreacion { get; set; } = null!;

    public virtual EstadosGuarderia EstadoGuarderia { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual ICollection<PertenenciasGuarderium> PertenenciasGuarderia { get; set; } = new List<PertenenciasGuarderium>();

    public virtual Usuario UsuarioCreacion { get; set; } = null!;
}
