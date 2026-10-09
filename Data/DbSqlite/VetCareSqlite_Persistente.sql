PRAGMA foreign_keys = ON;
PRAGMA journal_mode = WAL;
PRAGMA synchronous = FULL;
PRAGMA busy_timeout = 5000;

BEGIN;

CREATE TABLE IF NOT EXISTS Clientes (
    ClienteId INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL,
    Apellido TEXT NOT NULL,
    Cedula TEXT,
    TelefonoPrincipal TEXT NOT NULL,
    TelefonoEmergencia TEXT,
    Direccion TEXT,
    CorreoElectronico TEXT,
    MetodoPagoPreferido TEXT,
    FechaCreacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FechaActualizacion TEXT,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Empleados (
    EmpleadoId INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL,
    Apellido TEXT NOT NULL,
    Cedula TEXT,
    Telefono TEXT,
    CorreoElectronico TEXT,
    FechaCreacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FechaActualizacion TEXT,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Especies (
    EspecieId INTEGER PRIMARY KEY AUTOINCREMENT,
    NombreEspecie TEXT NOT NULL,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Razas (
    RazaId INTEGER PRIMARY KEY AUTOINCREMENT,
    EspecieId INTEGER NOT NULL,
    NombreRaza TEXT NOT NULL,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1)),
    FOREIGN KEY (EspecieId) REFERENCES Especies(EspecieId)
);

CREATE TABLE IF NOT EXISTS EstadosCitas (
    EstadoCitaId INTEGER PRIMARY KEY AUTOINCREMENT,
    NombreEstado TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS EstadosGuarderias (
    EstadoGuarderiaId INTEGER PRIMARY KEY AUTOINCREMENT,
    NombreEstado TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Permisos (
    PermisoId INTEGER PRIMARY KEY AUTOINCREMENT,
    CodigoPermiso TEXT NOT NULL,
    NombrePermiso TEXT NOT NULL,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Roles (
    RolId INTEGER PRIMARY KEY AUTOINCREMENT,
    NombreRol TEXT NOT NULL,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1)),
    FechaCreacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now'))
);

CREATE TABLE IF NOT EXISTS Usuarios (
    UsuarioId INTEGER PRIMARY KEY AUTOINCREMENT,
    EmpleadoId INTEGER NOT NULL,
    NombreUsuario TEXT NOT NULL,
    HashContrasena TEXT NOT NULL,
    FechaUltimaSesion TEXT,
    FechaCreacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FechaActualizacion TEXT,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1)),
    FOREIGN KEY (EmpleadoId) REFERENCES Empleados(EmpleadoId)
);

CREATE TABLE IF NOT EXISTS Productos (
    ProductoId INTEGER PRIMARY KEY AUTOINCREMENT,
    CodigoProducto TEXT NOT NULL,
    NombreProducto TEXT NOT NULL,
    TipoProducto TEXT NOT NULL CHECK (TipoProducto IN ('Otro','Material','Medicamento')),
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Servicios (
    ServicioId INTEGER PRIMARY KEY AUTOINCREMENT,
    CodigoServicio TEXT NOT NULL,
    NombreServicio TEXT NOT NULL,
    CategoriaServicio TEXT NOT NULL,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1))
);

CREATE TABLE IF NOT EXISTS TiposCitas (
    TipoCitaId INTEGER PRIMARY KEY AUTOINCREMENT,
    NombreTipoCita TEXT NOT NULL,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1))
);

CREATE TABLE IF NOT EXISTS TiposVisitas (
    TipoVisitaId INTEGER PRIMARY KEY AUTOINCREMENT,
    NombreTipoVisita TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Vacunas (
    VacunaId INTEGER PRIMARY KEY AUTOINCREMENT,
    NombreVacuna TEXT NOT NULL,
    Fabricante TEXT,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Pacientes (
    PacienteId INTEGER PRIMARY KEY AUTOINCREMENT,
    ClienteId INTEGER NOT NULL,
    EspecieId INTEGER NOT NULL,
    RazaId INTEGER,
    NombrePaciente TEXT NOT NULL,
    FechaNacimiento TEXT,
    Sexo TEXT CHECK (Sexo IS NULL OR Sexo IN ('H','M')),
    ColorPelaje TEXT,
    FechaCreacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FechaActualizacion TEXT,
    EstaActivo INTEGER NOT NULL DEFAULT 1 CHECK (EstaActivo IN (0,1)),
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId),
    FOREIGN KEY (EspecieId) REFERENCES Especies(EspecieId),
    FOREIGN KEY (RazaId) REFERENCES Razas(RazaId)
);

CREATE TABLE IF NOT EXISTS PermisosRoles (
    RolId INTEGER,
    PermisosRolesId INTEGER PRIMARY KEY AUTOINCREMENT,
    PermisoId INTEGER,
    FechaAsignacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FOREIGN KEY (RolId) REFERENCES Roles(RolId),
    FOREIGN KEY (PermisoId) REFERENCES Permisos(PermisoId)
);

CREATE TABLE IF NOT EXISTS RolesUsuarios (
    UsuarioId INTEGER,
    RolesUsuarioId INTEGER PRIMARY KEY AUTOINCREMENT,
    RolId INTEGER,
    FechaAsignacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (RolId) REFERENCES Roles(RolId)
);

CREATE TABLE IF NOT EXISTS Citas (
    CitaId INTEGER NOT NULL PRIMARY KEY,
    PacienteId INTEGER NOT NULL,
    TipoCitaId INTEGER NOT NULL,
    EstadoCitaId INTEGER NOT NULL,
    VeterinarioId INTEGER,
    UsuarioCreacionId INTEGER NOT NULL,
    FechaHoraInicioProgramada TEXT NOT NULL,
    FechaHoraFinProgramada TEXT NOT NULL,
    Observaciones TEXT,
    FechaCreacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FechaActualizacion TEXT,
    FOREIGN KEY (EstadoCitaId) REFERENCES EstadosCitas(EstadoCitaId),
    FOREIGN KEY (PacienteId) REFERENCES Pacientes(PacienteId),
    FOREIGN KEY (TipoCitaId) REFERENCES TiposCitas(TipoCitaId),
    FOREIGN KEY (UsuarioCreacionId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (VeterinarioId) REFERENCES Empleados(EmpleadoId),
    CHECK (FechaHoraFinProgramada >= FechaHoraInicioProgramada)
);

CREATE TABLE IF NOT EXISTS EstanciasGuarderia (
    EstanciaGuarderiaId INTEGER NOT NULL PRIMARY KEY,
    PacienteId INTEGER NOT NULL,
    EstadoGuarderiaId INTEGER NOT NULL,
    UsuarioCreacionId INTEGER NOT NULL,
    FechaHoraEntrada TEXT NOT NULL,
    FechaHoraSalida TEXT,
    InstruccionesAlimentacion TEXT,
    InstruccionesSocializacion TEXT,
    FechaCreacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FOREIGN KEY (EstadoGuarderiaId) REFERENCES EstadosGuarderias(EstadoGuarderiaId),
    FOREIGN KEY (PacienteId) REFERENCES Pacientes(PacienteId),
    FOREIGN KEY (UsuarioCreacionId) REFERENCES Usuarios(UsuarioId),
    CHECK (FechaHoraSalida IS NULL OR FechaHoraSalida >= FechaHoraEntrada)
);

CREATE TABLE IF NOT EXISTS PertenenciasGuarderia (
    PertenenciaGuarderiaId INTEGER NOT NULL PRIMARY KEY,
    EstanciaGuarderiaId INTEGER NOT NULL,
    DescripcionPertenencia TEXT NOT NULL,
    FOREIGN KEY (EstanciaGuarderiaId) REFERENCES EstanciasGuarderia(EstanciaGuarderiaId)
);

CREATE TABLE IF NOT EXISTS CargosPacientes (
    CargoPacienteId INTEGER NOT NULL PRIMARY KEY,
    PacienteId INTEGER NOT NULL,
    ProductoId INTEGER,
    ServicioId INTEGER,
    UsuarioCreacionId INTEGER NOT NULL,
    TipoCargo TEXT NOT NULL CHECK (TipoCargo IN ('Servicio','Producto')),
    Cantidad NUMERIC NOT NULL DEFAULT 1 CHECK (Cantidad > 0),
    PrecioUnitario NUMERIC NOT NULL CHECK (PrecioUnitario >= 0),
    FechaHoraCargo TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FechaCreacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FOREIGN KEY (PacienteId) REFERENCES Pacientes(PacienteId),
    FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId),
    FOREIGN KEY (ServicioId) REFERENCES Servicios(ServicioId),
    FOREIGN KEY (UsuarioCreacionId) REFERENCES Usuarios(UsuarioId),
    CHECK ((TipoCargo = 'Producto' AND ProductoId IS NOT NULL AND ServicioId IS NULL)
        OR (TipoCargo = 'Servicio' AND ServicioId IS NOT NULL AND ProductoId IS NULL))
);

CREATE TABLE IF NOT EXISTS VacunacionesPacientes (
    VacunacionPacienteId INTEGER NOT NULL PRIMARY KEY,
    PacienteId INTEGER NOT NULL,
    VacunaId INTEGER NOT NULL,
    AsistenteId INTEGER,
    UsuarioCreacionId INTEGER NOT NULL,
    FechaHoraAplicacion TEXT NOT NULL,
    FechaProximaAplicacion TEXT,
    Observaciones TEXT,
    FechaCreacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FOREIGN KEY (AsistenteId) REFERENCES Empleados(EmpleadoId),
    FOREIGN KEY (PacienteId) REFERENCES Pacientes(PacienteId),
    FOREIGN KEY (UsuarioCreacionId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (VacunaId) REFERENCES Vacunas(VacunaId)
);

CREATE TABLE IF NOT EXISTS Visitas (
    VisitaId INTEGER NOT NULL PRIMARY KEY,
    PacienteId INTEGER NOT NULL,
    TipoVisitaId INTEGER NOT NULL,
    VeterinarioId INTEGER,
    CitaId INTEGER,
    UsuarioCreacionId INTEGER NOT NULL,
    FechaHoraVisita TEXT NOT NULL,
    Motivo TEXT,
    PesoKg NUMERIC CHECK (PesoKg IS NULL OR PesoKg > 0),
    TemperaturaC NUMERIC CHECK (TemperaturaC IS NULL OR TemperaturaC > 0),
    Observaciones TEXT,
    FechaCreacion TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    FOREIGN KEY (CitaId) REFERENCES Citas(CitaId),
    FOREIGN KEY (PacienteId) REFERENCES Pacientes(PacienteId),
    FOREIGN KEY (TipoVisitaId) REFERENCES TiposVisitas(TipoVisitaId),
    FOREIGN KEY (UsuarioCreacionId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (VeterinarioId) REFERENCES Empleados(EmpleadoId)
);

CREATE TABLE IF NOT EXISTS RegistrosAuditoria (
    RegistroAuditoriaId INTEGER NOT NULL PRIMARY KEY,
    UsuarioId INTEGER,
    NombreEntidad TEXT NOT NULL,
    IdentificadorEntidad TEXT NOT NULL,
    TipoAccion TEXT NOT NULL CHECK (TipoAccion IN ('ELIMINAR','ACTUALIZAR','INSERTAR')),
    FechaHoraEvento TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%f','now')),
    ValoresAnteriores TEXT,
    ValoresNuevos TEXT,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId)
);

CREATE TABLE IF NOT EXISTS ColaOperaciones (
    Secuencia INTEGER PRIMARY KEY AUTOINCREMENT,
    OperacionId TEXT NOT NULL UNIQUE,
    ClaveIdempotencia TEXT NOT NULL UNIQUE,
    NombreEntidad TEXT NOT NULL,
    Accion TEXT NOT NULL CHECK (Accion IN ('INSERTAR','ACTUALIZAR','ELIMINAR')),
    IdentificadorEntidad TEXT NOT NULL,
    PayloadJson TEXT NOT NULL,
    Estado TEXT NOT NULL DEFAULT 'PENDIENTE'
        CHECK (Estado IN ('PENDIENTE','EN_PROCESO','CONFIRMADA','REINTENTAR','ERROR_PERMANENTE','CANCELADA')),
    Intentos INTEGER NOT NULL DEFAULT 0 CHECK (Intentos >= 0),
    CreadaUtc TEXT NOT NULL DEFAULT (strftime('%Y-%m-%dT%H:%M:%fZ','now')),
    UltimoIntentoUtc TEXT,
    ConfirmadaUtc TEXT,
    ProximoIntentoUtc TEXT,
    UltimoError TEXT,
    DependenciaSecuencia INTEGER,
    FOREIGN KEY (DependenciaSecuencia) REFERENCES ColaOperaciones(Secuencia),
    CHECK (length(OperacionId) > 0),
    CHECK (length(ClaveIdempotencia) > 0),
    CHECK (length(NombreEntidad) > 0),
    CHECK (length(IdentificadorEntidad) > 0)
);

CREATE TABLE IF NOT EXISTS MapeoClavesSincronizacion (
    NombreEntidad TEXT NOT NULL,
    ClaveLocal TEXT NOT NULL,
    ClaveServidor TEXT,
    OperacionId TEXT NOT NULL,
    Estado TEXT NOT NULL DEFAULT 'PENDIENTE'
        CHECK (Estado IN ('PENDIENTE','CONFIRMADA','CONFLICTO')),
    CreadaUtc TEXT NOT NULL DEFAULT (strftime('%Y-%m-%dT%H:%M:%fZ','now')),
    ConfirmadaUtc TEXT,
    PRIMARY KEY (NombreEntidad, ClaveLocal),
    UNIQUE (OperacionId),
    FOREIGN KEY (OperacionId) REFERENCES ColaOperaciones(OperacionId)
);

CREATE TABLE IF NOT EXISTS ConfiguracionSincronizacion (
    Clave TEXT PRIMARY KEY,
    Valor TEXT NOT NULL,
    ActualizadaUtc TEXT NOT NULL DEFAULT (strftime('%Y-%m-%dT%H:%M:%fZ','now'))
);

CREATE INDEX IF NOT EXISTS IX_Pacientes_ClienteId ON Pacientes(ClienteId);
CREATE INDEX IF NOT EXISTS IX_Pacientes_EspecieId ON Pacientes(EspecieId);
CREATE INDEX IF NOT EXISTS IX_Pacientes_RazaId ON Pacientes(RazaId);
CREATE INDEX IF NOT EXISTS IX_Razas_EspecieId ON Razas(EspecieId);
CREATE INDEX IF NOT EXISTS IX_Usuarios_EmpleadoId ON Usuarios(EmpleadoId);
CREATE INDEX IF NOT EXISTS IX_Citas_Paciente_Fecha ON Citas(PacienteId, FechaHoraInicioProgramada);
CREATE INDEX IF NOT EXISTS IX_Citas_Estado ON Citas(EstadoCitaId);
CREATE INDEX IF NOT EXISTS IX_Estancias_Paciente_Entrada ON EstanciasGuarderia(PacienteId, FechaHoraEntrada);
CREATE INDEX IF NOT EXISTS IX_Pertenencias_Estancia ON PertenenciasGuarderia(EstanciaGuarderiaId);
CREATE INDEX IF NOT EXISTS IX_Cargos_Paciente_Fecha ON CargosPacientes(PacienteId, FechaHoraCargo);
CREATE INDEX IF NOT EXISTS IX_Vacunaciones_Paciente_Fecha ON VacunacionesPacientes(PacienteId, FechaHoraAplicacion);
CREATE INDEX IF NOT EXISTS IX_Visitas_Paciente_Fecha ON Visitas(PacienteId, FechaHoraVisita);
CREATE INDEX IF NOT EXISTS IX_Auditoria_Entidad_Fecha ON RegistrosAuditoria(NombreEntidad, IdentificadorEntidad, FechaHoraEvento);
CREATE UNIQUE INDEX IF NOT EXISTS UX_Clientes_Cedula ON Clientes(Cedula) WHERE Cedula IS NOT NULL;
CREATE UNIQUE INDEX IF NOT EXISTS UX_Usuarios_NombreUsuario ON Usuarios(NombreUsuario);
CREATE UNIQUE INDEX IF NOT EXISTS UX_Productos_Codigo ON Productos(CodigoProducto);
CREATE UNIQUE INDEX IF NOT EXISTS UX_Servicios_Codigo ON Servicios(CodigoServicio);
CREATE UNIQUE INDEX IF NOT EXISTS UX_Permisos_Codigo ON Permisos(CodigoPermiso);
CREATE INDEX IF NOT EXISTS IX_Cola_Pendiente ON ColaOperaciones(Estado, Secuencia);
CREATE INDEX IF NOT EXISTS IX_Cola_ProximoIntento ON ColaOperaciones(Estado, ProximoIntentoUtc, Secuencia);
CREATE INDEX IF NOT EXISTS IX_Cola_Entidad ON ColaOperaciones(NombreEntidad, IdentificadorEntidad, Secuencia);
CREATE INDEX IF NOT EXISTS IX_Mapeo_Estado ON MapeoClavesSincronizacion(Estado, NombreEntidad);

INSERT OR IGNORE INTO ConfiguracionSincronizacion (Clave, Valor)
VALUES ('EsquemaVersion', '1'), ('UltimaSecuenciaConfirmada', '0');

COMMIT;
