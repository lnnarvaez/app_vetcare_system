# Guía para agentes

## Proyecto

- Es una única aplicación .NET 8 Windows Forms (`app_vetcare_system.csproj`); `Program.cs` inicia directamente `MainContainerForm`.
- `MainContainerForm` crea y conserva un `VetCareDbSI2VContext` compartido, y carga los formularios hijos en `splitMain.Panel2`; respeta ese ciclo de vida al añadir módulos.
- La arquitectura de clientes separa `View/FormUI`, `Presenter`, contratos en `View/Interfaz`, DTOs en `Models/DTOs` y acceso SQL en `Services/Repository`; los formularios no deben consultar la base directamente.
- Todas las operaciones de `ICustomerRepository` son asíncronas: `GetAllCustomersAsync`, `CreateCustomerAsync`, `GetCustomerByIdAsync`, `UpdateCustomerAsync` y `DeleteCustomerAsync`; propaga `await` hasta los eventos de los formularios cuando corresponda.
- El borrado de clientes es lógico: `CustomerRepository` pone `Cliente.EstaActivo` en `false` y actualiza `FechaActualizacion`; las consultas de clientes deben conservar el filtro `EstaActivo`.
- Los repositorios usan el namespace `app_vetcare_system.Services.Repository`, no solo `app_vetcare_system.Services`.
- La autenticación tiene presenter, servicio, repositorio y `PasswordHasher` PBKDF2-SHA256, pero no está conectada al arranque actual; `Program.cs` abre `MainContainerForm` sin pantalla de login.

## Comandos y validación

- Ejecuta desde la raíz: `dotnet restore`, después `dotnet build app_vetcare_system.slnx`.
- Ejecuta la aplicación en Windows con .NET 8 mediante `dotnet run --project app_vetcare_system.csproj`; requiere SQL Server accesible para los módulos que consultan datos.
- No hay proyecto de pruebas, lint, formatter, lockfile ni CI configurados; valida como mínimo con `dotnet build` y comprobación manual de cambios visuales.

## Base de datos y código generado

- `VetCareDbSI2VContext` lee `ConnectionStrings:VetCareDbConnectionSI` desde `appsettings.json`; ese archivo se copia al directorio de salida y contiene configuración dependiente de la máquina.
- `Data/VetCareDbSI2VContext.cs` y `Models/Entities/*` son salidas de EF Core Power Tools descritas por `efpt.config.json`; no edites manualmente sus clases ni mappings, regénéralos desde la base configurada.
- `Data/VetCareDbContext.cs` es un contexto EF independiente del contexto generado usado por clientes y autenticación.
- No añadas credenciales ni secretos a `appsettings.json` ni al repositorio.

## Formularios y OpenCode

- No modifiques `*.Designer.cs`; los cambios de comportamiento deben ir en el archivo parcial no generado.
- `opencode.json` usa `plan` como agente predeterminado y solicita aprobación para editar o ejecutar comandos; conserva ese flujo salvo instrucción explícita.
- `.gitattributes` define `* text=auto`; conserva finales de línea consistentes con la normalización de Git al modificar archivos.
