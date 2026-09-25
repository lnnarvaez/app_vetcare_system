# Guía para agentes

## Proyecto

- Es un único ejecutable .NET 8 Windows Forms (`app_vetcare_system.csproj`); `Program.cs` inicia `View/FormUI/MainContainerForm`.
- La UI usa formularios, interfaces, presenters y servicios. `MainContainerForm` posee el `VetCareDbSI2VContext` compartido y carga formularios hijos en su panel derecho; conserva ese ciclo de vida al añadir módulos.
- Los flujos de clientes usan `View/FormUI`, `Presenter`, `Services` y `Models/DTOs`; el acceso a datos debe permanecer en repositorios, no en formularios.
- Los DTOs de autenticación están en `Models/DTOs`; sus contratos de vista están en `View/Interfaz/IAuthenticationView.cs`, el presenter en `Presenter/AuthenticationPresenter.cs` y la lógica en `Services/AuthenticationService.cs`.
- Los repositorios se almacenan en `Services/Repository`; `CustomerRepository` y `UsuarioRepository` usan el namespace `app_vetcare_system.Services.Repository`.
- Al consumir `CustomerRepository` desde una vista o formulario, importa `app_vetcare_system.Services.Repository`; el proyecto actualmente no compila si se usa solo `app_vetcare_system.Services`.

## Comandos

- Ejecuta desde la raíz `dotnet restore` y `dotnet build app_vetcare_system.slnx`.
- Ejecuta la aplicación con `dotnet run --project app_vetcare_system.csproj` en Windows con el SDK .NET 8 y soporte Windows Forms.
- No hay proyecto de pruebas, lint, formatter ni CI; valida como mínimo con `dotnet build` y comprobaciones manuales cuando el cambio sea visual.

## Flujo de OpenCode

- `opencode.json` inicia con el agente `plan` y solicita aprobación antes de editar o ejecutar comandos; conserva este flujo de revisión salvo solicitud explícita.

## Base de datos y código generado

- Al iniciar se construye `VetCareDbSI2VContext`, que lee `ConnectionStrings:VetCareDbConnectionSI` desde `appsettings.json`; los módulos actuales requieren una base SQL Server accesible.
- Hay dos contextos EF: los clientes y la autenticación usan el generado `app_vetcare_si.Data.VetCareDbSI2VContext`; `Data/VetCareDbContext.cs` es independiente y corresponde al modelo inglés de clientes/empleados.
- `Data/VetCareDbSI2VContext.cs` y `Models/Entities/*` son generados por EF Core Power Tools según `efpt.config.json` (`UseNullableReferences` está en `false`); no edites manualmente sus mappings, regenera desde la base configurada.
- La autenticación consulta `Usuario` mediante `UsuarioRepository`; `PasswordHasher` usa PBKDF2-SHA256 y el hash no debe exponerse en DTOs de salida ni en la vista.
- `appsettings.json` se copia al directorio de salida y contiene cadenas SQL dependientes de la máquina; no añadas credenciales ni secretos al repositorio y modifica la configuración local con cuidado.
