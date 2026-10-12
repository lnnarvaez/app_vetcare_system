using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using app_vetcare_system.Data.DbSqlite.Entities;

namespace app_vetcare_system.Data.DbSqlite;

public partial class VetCareSqliteContext : DbContext
{
    public VetCareSqliteContext(DbContextOptions<VetCareSqliteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CargosPaciente> CargosPacientes { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ColaOperacione> ColaOperaciones { get; set; }

    public virtual DbSet<ConfiguracionSincronizacion> ConfiguracionSincronizacions { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Especy> Especies { get; set; }

    public virtual DbSet<EstadosCita> EstadosCitas { get; set; }

    public virtual DbSet<EstadosGuarderia> EstadosGuarderias { get; set; }

    public virtual DbSet<EstanciasGuarderium> EstanciasGuarderia { get; set; }

    public virtual DbSet<MapeoClavesSincronizacion> MapeoClavesSincronizacions { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisosRole> PermisosRoles { get; set; }

    public virtual DbSet<PertenenciasGuarderium> PertenenciasGuarderia { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    public virtual DbSet<RegistrosAuditorium> RegistrosAuditoria { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesUsuario> RolesUsuarios { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TiposCita> TiposCitas { get; set; }

    public virtual DbSet<TiposVisita> TiposVisitas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vacuna> Vacunas { get; set; }

    public virtual DbSet<VacunacionesPaciente> VacunacionesPacientes { get; set; }

    public virtual DbSet<Visita> Visitas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CargosPaciente>(entity =>
        {
            entity.HasKey(e => e.CargoPacienteId);

            entity.HasIndex(e => new { e.PacienteId, e.FechaHoraCargo }, "IX_Cargos_Paciente_Fecha");

            entity.Property(e => e.CargoPacienteId).ValueGeneratedNever();
            entity.Property(e => e.Cantidad)
                .HasDefaultValueSql("1")
                .HasColumnType("NUMERIC");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");
            entity.Property(e => e.FechaHoraCargo).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");
            entity.Property(e => e.PrecioUnitario).HasColumnType("NUMERIC");

            entity.HasOne(d => d.Paciente).WithMany(p => p.CargosPacientes)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Producto).WithMany(p => p.CargosPacientes).HasForeignKey(d => d.ProductoId);

            entity.HasOne(d => d.Servicio).WithMany(p => p.CargosPacientes).HasForeignKey(d => d.ServicioId);

            entity.HasOne(d => d.UsuarioCreacion).WithMany(p => p.CargosPacientes)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasIndex(e => e.EstadoCitaId, "IX_Citas_Estado");

            entity.HasIndex(e => new { e.PacienteId, e.FechaHoraInicioProgramada }, "IX_Citas_Paciente_Fecha");

            entity.Property(e => e.CitaId).ValueGeneratedNever();
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");

            entity.HasOne(d => d.EstadoCita).WithMany(p => p.Cita)
                .HasForeignKey(d => d.EstadoCitaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.TipoCita).WithMany(p => p.Cita)
                .HasForeignKey(d => d.TipoCitaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UsuarioCreacion).WithMany(p => p.Cita)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Veterinario).WithMany(p => p.Cita).HasForeignKey(d => d.VeterinarioId);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasIndex(e => e.Cedula, "UX_Clientes_Cedula").IsUnique();

            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");
        });

        modelBuilder.Entity<ColaOperacione>(entity =>
        {
            entity.HasKey(e => e.Secuencia);

            entity.HasIndex(e => e.ClaveIdempotencia, "IX_ColaOperaciones_ClaveIdempotencia").IsUnique();

            entity.HasIndex(e => e.OperacionId, "IX_ColaOperaciones_OperacionId").IsUnique();

            entity.HasIndex(e => new { e.NombreEntidad, e.IdentificadorEntidad, e.Secuencia }, "IX_Cola_Entidad");

            entity.HasIndex(e => new { e.Estado, e.Secuencia }, "IX_Cola_Pendiente");

            entity.HasIndex(e => new { e.Estado, e.ProximoIntentoUtc, e.Secuencia }, "IX_Cola_ProximoIntento");

            entity.Property(e => e.CreadaUtc).HasDefaultValueSql("strftime('%Y-%m-%dT%H:%M:%fZ','now')");
            entity.Property(e => e.Estado).HasDefaultValue("PENDIENTE");

            entity.HasOne(d => d.DependenciaSecuenciaNavigation).WithMany(p => p.InverseDependenciaSecuenciaNavigation).HasForeignKey(d => d.DependenciaSecuencia);
        });

        modelBuilder.Entity<ConfiguracionSincronizacion>(entity =>
        {
            entity.HasKey(e => e.Clave);

            entity.ToTable("ConfiguracionSincronizacion");

            entity.Property(e => e.ActualizadaUtc).HasDefaultValueSql("strftime('%Y-%m-%dT%H:%M:%fZ','now')");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");
        });

        modelBuilder.Entity<Especy>(entity =>
        {
            entity.HasKey(e => e.EspecieId);

            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
        });

        modelBuilder.Entity<EstadosCita>(entity =>
        {
            entity.HasKey(e => e.EstadoCitaId);
        });

        modelBuilder.Entity<EstadosGuarderia>(entity =>
        {
            entity.HasKey(e => e.EstadoGuarderiaId);
        });

        modelBuilder.Entity<EstanciasGuarderium>(entity =>
        {
            entity.HasKey(e => e.EstanciaGuarderiaId);

            entity.HasIndex(e => new { e.PacienteId, e.FechaHoraEntrada }, "IX_Estancias_Paciente_Entrada");

            entity.Property(e => e.EstanciaGuarderiaId).ValueGeneratedNever();
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");

            entity.HasOne(d => d.EstadoGuarderia).WithMany(p => p.EstanciasGuarderia)
                .HasForeignKey(d => d.EstadoGuarderiaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Paciente).WithMany(p => p.EstanciasGuarderia)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UsuarioCreacion).WithMany(p => p.EstanciasGuarderia)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<MapeoClavesSincronizacion>(entity =>
        {
            entity.HasKey(e => new { e.NombreEntidad, e.ClaveLocal });

            entity.ToTable("MapeoClavesSincronizacion");

            entity.HasIndex(e => e.OperacionId, "IX_MapeoClavesSincronizacion_OperacionId").IsUnique();

            entity.HasIndex(e => new { e.Estado, e.NombreEntidad }, "IX_Mapeo_Estado");

            entity.Property(e => e.CreadaUtc).HasDefaultValueSql("strftime('%Y-%m-%dT%H:%M:%fZ','now')");
            entity.Property(e => e.Estado).HasDefaultValue("PENDIENTE");

            entity.HasOne(d => d.Operacion).WithOne(p => p.MapeoClavesSincronizacion)
                .HasPrincipalKey<ColaOperacione>(p => p.OperacionId)
                .HasForeignKey<MapeoClavesSincronizacion>(d => d.OperacionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasIndex(e => e.ClienteId, "IX_Pacientes_ClienteId");

            entity.HasIndex(e => e.EspecieId, "IX_Pacientes_EspecieId");

            entity.HasIndex(e => e.RazaId, "IX_Pacientes_RazaId");

            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Especie).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Raza).WithMany(p => p.Pacientes).HasForeignKey(d => d.RazaId);
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasIndex(e => e.CodigoPermiso, "UX_Permisos_Codigo").IsUnique();

            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
        });

        modelBuilder.Entity<PermisosRole>(entity =>
        {
            entity.HasKey(e => e.PermisosRolesId);

            entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");

            entity.HasOne(d => d.Permiso).WithMany(p => p.PermisosRoles).HasForeignKey(d => d.PermisoId);

            entity.HasOne(d => d.Rol).WithMany(p => p.PermisosRoles).HasForeignKey(d => d.RolId);
        });

        modelBuilder.Entity<PertenenciasGuarderium>(entity =>
        {
            entity.HasKey(e => e.PertenenciaGuarderiaId);

            entity.HasIndex(e => e.EstanciaGuarderiaId, "IX_Pertenencias_Estancia");

            entity.Property(e => e.PertenenciaGuarderiaId).ValueGeneratedNever();

            entity.HasOne(d => d.EstanciaGuarderia).WithMany(p => p.PertenenciasGuarderia)
                .HasForeignKey(d => d.EstanciaGuarderiaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasIndex(e => e.CodigoProducto, "UX_Productos_Codigo").IsUnique();

            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasIndex(e => e.EspecieId, "IX_Razas_EspecieId");

            entity.Property(e => e.EstaActivo).HasDefaultValue(1);

            entity.HasOne(d => d.Especie).WithMany(p => p.Razas)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RegistrosAuditorium>(entity =>
        {
            entity.HasKey(e => e.RegistroAuditoriaId);

            entity.HasIndex(e => new { e.NombreEntidad, e.IdentificadorEntidad, e.FechaHoraEvento }, "IX_Auditoria_Entidad_Fecha");

            entity.Property(e => e.RegistroAuditoriaId).ValueGeneratedNever();
            entity.Property(e => e.FechaHoraEvento).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");

            entity.HasOne(d => d.Usuario).WithMany(p => p.RegistrosAuditoria).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId);

            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");
        });

        modelBuilder.Entity<RolesUsuario>(entity =>
        {
            entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolesUsuarios).HasForeignKey(d => d.RolId);

            entity.HasOne(d => d.Usuario).WithMany(p => p.RolesUsuarios).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasIndex(e => e.CodigoServicio, "UX_Servicios_Codigo").IsUnique();

            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
        });

        modelBuilder.Entity<TiposCita>(entity =>
        {
            entity.HasKey(e => e.TipoCitaId);

            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
        });

        modelBuilder.Entity<TiposVisita>(entity =>
        {
            entity.HasKey(e => e.TipoVisitaId);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasIndex(e => e.EmpleadoId, "IX_Usuarios_EmpleadoId");

            entity.HasIndex(e => e.NombreUsuario, "UX_Usuarios_NombreUsuario").IsUnique();

            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Vacuna>(entity =>
        {
            entity.Property(e => e.EstaActivo).HasDefaultValue(1);
        });

        modelBuilder.Entity<VacunacionesPaciente>(entity =>
        {
            entity.HasKey(e => e.VacunacionPacienteId);

            entity.HasIndex(e => new { e.PacienteId, e.FechaHoraAplicacion }, "IX_Vacunaciones_Paciente_Fecha");

            entity.Property(e => e.VacunacionPacienteId).ValueGeneratedNever();
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");

            entity.HasOne(d => d.Asistente).WithMany(p => p.VacunacionesPacientes).HasForeignKey(d => d.AsistenteId);

            entity.HasOne(d => d.Paciente).WithMany(p => p.VacunacionesPacientes)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UsuarioCreacion).WithMany(p => p.VacunacionesPacientes)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Vacuna).WithMany(p => p.VacunacionesPacientes)
                .HasForeignKey(d => d.VacunaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Visita>(entity =>
        {
            entity.HasIndex(e => new { e.PacienteId, e.FechaHoraVisita }, "IX_Visitas_Paciente_Fecha");

            entity.Property(e => e.VisitaId).ValueGeneratedNever();
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%f','now')");
            entity.Property(e => e.PesoKg).HasColumnType("NUMERIC");
            entity.Property(e => e.TemperaturaC).HasColumnType("NUMERIC");

            entity.HasOne(d => d.Cita).WithMany(p => p.Visita).HasForeignKey(d => d.CitaId);

            entity.HasOne(d => d.Paciente).WithMany(p => p.Visita)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.TipoVisita).WithMany(p => p.Visita)
                .HasForeignKey(d => d.TipoVisitaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UsuarioCreacion).WithMany(p => p.Visita)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Veterinario).WithMany(p => p.Visita).HasForeignKey(d => d.VeterinarioId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
