using System;
using System.Collections.Generic;

namespace app_vetcare_system.Data.DbSqlite.Entities;

public partial class RegistrosAuditorium
{
    public int RegistroAuditoriaId { get; set; }

    public int? UsuarioId { get; set; }

    public string NombreEntidad { get; set; } = null!;

    public string IdentificadorEntidad { get; set; } = null!;

    public string TipoAccion { get; set; } = null!;

    public string FechaHoraEvento { get; set; } = null!;

    public string? ValoresAnteriores { get; set; }

    public string? ValoresNuevos { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
