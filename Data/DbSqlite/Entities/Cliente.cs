using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Cedula { get; set; }

    public string TelefonoPrincipal { get; set; } = null!;

    public string? TelefonoEmergencia { get; set; }

    public string? Direccion { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? MetodoPagoPreferido { get; set; }

    public string FechaCreacion { get; set; } = null!;

    public string? FechaActualizacion { get; set; }

    public int EstaActivo { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
