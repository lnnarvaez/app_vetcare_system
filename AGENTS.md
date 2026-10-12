# Guía para agentes

## Proyecto

- Es una única aplicación .NET 8 Windows Forms (`app_vetcare_system.csproj`); `Program.cs` inicia directamente `MainContainerForm`.
- `MainContainerForm` crea y conserva un `VetCareDbSI2VContext` compartido, y carga los formularios hijos en `splitMain.Panel2`; respeta ese ciclo de vida al añadir módulos.
- La arquitectura de clientes separa `View/FormUI`, `Presenter`, contratos en `View/Interfaz`, DTOs en `Models/DTOs` y acceso SQL en `Services/Repository`; los formularios no deben consultar la base directamente.
- Todas las operaciones de `ICustomerRepository` son asíncronas: `GetAllCustomersAsync`, `CreateCustomerAsync`, `GetCustomerByIdAsync`, `UpdateCustomerAsync` y `DeleteCustomerAsync`; propaga `await` hasta los eventos de los formularios cuando corresponda.
- El borrado de clientes es lógico: `CustomerRepository` pone `Cliente.EstaActivo` en `false` y actualiza `FechaActualizacion`; las consultas de clientes deben conservar el filtro `EstaActivo`.
- Los repositorios usan el namespace `app_vetcare_system.Services.Repository`, no solo `app_vetcare_system.Services`.
- La autenticación usa `AuthenticationLoginForm`, `AuthenticationPresenter`, `AuthenticationService`, `UsuarioRepository` y `PasswordHasher` PBKDF2-SHA256; `MainContainerForm` carga el login en `splitMain.Panel2`, centra el formulario y mantiene el menú oculto hasta autenticar.
- Las operaciones de autenticación que acceden a SQL son asíncronas (`AuthenticateAsync`, `ResetPasswordAsync`, `GetUserAuthenticationDataAsync`, `UpdateLastLoginAsync`); `PasswordHasher` permanece síncrono porque solo realiza trabajo de CPU.

## Comandos y validación

- Ejecuta desde la raíz: `dotnet restore`, después `dotnet build app_vetcare_system.slnx`.
- Ejecuta la aplicación en Windows con .NET 8 mediante `dotnet run --project app_vetcare_system.csproj`; requiere SQL Server accesible para los módulos que consultan datos.
- No hay proyecto de pruebas, lint, formatter, lockfile ni CI configurados; valida como mínimo con `dotnet build` y comprobación manual de cambios visuales.

## Datos y código generado

- `VetCareDbSI2VContext` lee `ConnectionStrings:VetCareDbConnectionSI` desde `appsettings.json`; ese archivo se copia al directorio de salida y contiene configuración dependiente de la máquina.
- `Data/VetCareDbSI2VContext.cs` y `Models/Entities/*` son salidas de EF Core Power Tools descritas por `efpt.config.json`; no edites manualmente sus clases ni mappings, regénéralos desde la base configurada.
- `Data/VetCareDbContext.cs` es un contexto EF independiente del contexto generado usado por clientes y autenticación.
- `Microsoft.EntityFrameworkCore.Sqlite` 8.0.30 está referenciado para preparar SQLite, pero `VetCareDbSI2VContext` continúa siendo exclusivamente SQL Server.
- `Data/DbSqlite/SqliteSchemaInitializer.cs` crea de forma idempotente `Data/DbSqlite/VetCareLocal.db` en el directorio de salida desde `VetCareSqlite_Persistente.sql` al construir `MainContainerForm`; no elimina una base existente y captura sus fallos.
- El script SQL se copia al directorio de salida; la base y sus archivos auxiliares están excluidos mediante `.gitignore` (`Data/DbSqlite/*.db` y `*.db-*`).
- SQLite aún no es fallback ni fuente de datos de clientes o autenticación: no agregues ORM, sincronización ni colas operativas sin una solicitud explícita.
- Si se implementa ORM SQLite después, usa un `VetCareSqliteContext` y entidades/configuraciones separadas; no reutilices ni edites entidades o mappings generados para SQL Server.
- No añadas credenciales ni secretos a `appsettings.json` ni al repositorio.

## Formularios y OpenCode

- No modifiques `*.Designer.cs`; los cambios de comportamiento deben ir en el archivo parcial no generado.
- No cambies `Program.cs` para insertar el login: el arranque debe continuar en `MainContainerForm`; integra la autenticación desde su código parcial y configura un formulario embebido con `TopLevel = false` antes de añadirlo a `Panel2`.
- `RecoverAccessForm` depende de `ResetPasswordAsync`; si se cambia ese flujo, propaga la firma por `IAuthenticationService`, `AuthenticationService`, `IUsuarioRepository` y `UsuarioRepository`.
- `opencode.json` usa `plan` como agente predeterminado y solicita aprobación para editar o ejecutar comandos; conserva ese flujo salvo instrucción explícita.
- `.gitattributes` define `* text=auto`; conserva finales de línea consistentes con la normalización de Git al modificar archivos.
