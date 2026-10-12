using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public int EmpleadoId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string HashContrasena { get; set; } = null!;

    public string? FechaUltimaSesion { get; set; }

    public string FechaCreacion { get; set; } = null!;

    public string? FechaActualizacion { get; set; }

    public int EstaActivo { get; set; }

    public virtual ICollection<CargosPaciente> CargosPacientes { get; set; } = new List<CargosPaciente>();

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual ICollection<EstanciasGuarderium> EstanciasGuarderia { get; set; } = new List<EstanciasGuarderium>();

    public virtual ICollection<RegistrosAuditorium> RegistrosAuditoria { get; set; } = new List<RegistrosAuditorium>();

    public virtual ICollection<RolesUsuario> RolesUsuarios { get; set; } = new List<RolesUsuario>();

    public virtual ICollection<VacunacionesPaciente> VacunacionesPacientes { get; set; } = new List<VacunacionesPaciente>();

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();
}
