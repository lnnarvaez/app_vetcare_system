using System.Diagnostics;
using Microsoft.Data.Sqlite;

namespace app_vetcare_system.Data.DbSqlite;

/// <summary>
/// Crea únicamente la base SQLite local y su esquema; no participa todavía en los repositorios.
/// </summary>
public static class SqliteSchemaInitializer
{
    private const string SchemaFileName = "VetCareSqlite_Persistente.sql";
    private const string DatabaseFileName = "VetCareLocal.db";

    public static bool TryInitialize()
    {
        try
        {
            string directory = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                "DbSqlite");

            Directory.CreateDirectory(directory);

            string schemaPath = Path.Combine(directory, SchemaFileName);
            string databasePath = Path.Combine(directory, DatabaseFileName);

            if (!File.Exists(schemaPath))
            {
                throw new FileNotFoundException(
                    "No se encontró el esquema SQLite.",
                    schemaPath);
            }

            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = databasePath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                ForeignKeys = true
            };

            using var connection = new SqliteConnection(
                connectionStringBuilder.ToString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = File.ReadAllText(schemaPath);
            command.ExecuteNonQuery();

            return true;
        }
        catch (Exception ex)
        {
            // SQLite es auxiliar en esta etapa; su fallo no debe impedir usar SQL Server.
            Debug.WriteLine($"No fue posible crear la base SQLite local: {ex}");
            return false;
        }
    }
}
