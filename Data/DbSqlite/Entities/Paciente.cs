using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Paciente
{
    public int PacienteId { get; set; }

    public int ClienteId { get; set; }

    public int EspecieId { get; set; }

    public int? RazaId { get; set; }

    public string NombrePaciente { get; set; } = null!;

    public string? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public string? ColorPelaje { get; set; }

    public string FechaCreacion { get; set; } = null!;

    public string? FechaActualizacion { get; set; }

    public int EstaActivo { get; set; }

    public virtual ICollection<CargosPaciente> CargosPacientes { get; set; } = new List<CargosPaciente>();

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Especy Especie { get; set; } = null!;

    public virtual ICollection<EstanciasGuarderium> EstanciasGuarderia { get; set; } = new List<EstanciasGuarderium>();

    public virtual Raza? Raza { get; set; }

    public virtual ICollection<VacunacionesPaciente> VacunacionesPacientes { get; set; } = new List<VacunacionesPaciente>();

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();
}
