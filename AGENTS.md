# Guía para agentes

## Proyecto y comandos

- Es un único ejecutable Windows Forms .NET 8 (`app_vetcare_system.csproj`); `Program.cs` debe seguir iniciando `MainContainerForm`.
- Desde la raíz, valida cambios con `dotnet restore` y `dotnet build app_vetcare_system.slnx`; no hay proyecto de pruebas, lint, formatter ni CI.
- La ejecución (`dotnet run --project app_vetcare_system.csproj`) requiere Windows, SDK .NET 8 y SQL Server accesible.

## Flujo de la aplicación

- `MainContainerForm` mantiene el `VetCareDbSI2VContext` compartido y carga formularios hijos en `splitMain.Panel2`; no cambies ese ciclo de vida al añadir módulos.
- La autenticación se muestra dentro de `MainContainerForm`, no desde `Program.cs`: `AuthenticationLoginForm` usa `IAuthenticationView`, `AuthenticationPresenter`, `AuthenticationService`, `UsuarioRepository` y `PasswordHasher`.
- La navegación permanece oculta hasta autenticarse; el acceso actual exige que los roles reales devueltos por la base incluyan `Administrador`, sin asignarlo automáticamente. No elimines la validación previa de acceso.
- `LoadFormIntoPanel` usa `DockStyle.Fill` para módulos normales; el login tiene una carga específica que conserva su tamaño del diseñador y lo centra. No generalices ese comportamiento al resto de formularios.

## Arquitectura de clientes

- Mantén el acceso a datos en `Services/Repository`, no en formularios; los repositorios usan el namespace `app_vetcare_system.Services.Repository`.
- Crear y editar clientes usan sus presenters actuales. La eliminación lógica se dispara desde `CustomerEditForm.btnDelete_Click`, pasa por `CustomerDeletePresenter` y `CustomerDeleteDto`, y termina en `CustomerRepository.DeleteCustomer`, que establece `EstaActivo = false`.
- Al editar o eliminar, conserva el `customerId` recibido por `CustomerEditForm`; no lo derives de campos editables del formulario.

## Diseñadores, EF y configuración

- No edites manualmente `*.Designer.cs` de WinForms; conecta eventos y lógica en el archivo parcial `.cs`. Esto es especialmente importante para `AuthenticationLoginForm` y `CustomerEditForm`.
- `Data/VetCareDbSI2VContext.cs` y `Models/Entities/*` son generados por EF Core Power Tools según `efpt.config.json`; regenera desde la base en vez de cambiar mappings a mano.
- `VetCareDbSI2VContext` lee `ConnectionStrings:VetCareDbConnectionSI`; `Data/VetCareDbContext.cs` es un contexto independiente que usa `VetCareDbConnection`.
- `appsettings.json` se copia a la salida y contiene conexiones dependientes de la máquina; no añadas credenciales ni secretos.
- `PasswordHasher` usa PBKDF2-SHA256; nunca expongas `PasswordHash` en DTOs de salida ni en vistas.
