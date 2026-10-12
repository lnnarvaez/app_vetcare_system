using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Cedula { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string FechaCreacion { get; set; } = null!;

    public string? FechaActualizacion { get; set; }

    public int EstaActivo { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public virtual ICollection<VacunacionesPaciente> VacunacionesPacientes { get; set; } = new List<VacunacionesPaciente>();

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();
}
