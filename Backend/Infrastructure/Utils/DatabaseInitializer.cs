using Dapper;
using Microsoft.Data.Sqlite;

namespace Infrastructure.Utils;

public static class DatabaseInitializer
{
    public static void Initialize(string connectionString)
    {
        var dbPath = connectionString.Replace("Data Source=", "");

        if (File.Exists(dbPath))
        {
            return;
        }

        using var connection = new SqliteConnection(connectionString);

        connection.Open();

        var dbSqlPath = Path.Combine(
            AppContext.BaseDirectory,
            "..",
            "..",
            "..",
            "..",
            "Infrastructure",
            "db.sql"
        );

        if (!File.Exists(dbSqlPath))
        {
            throw new FileNotFoundException(
                $"Script SQL introuvable : {dbSqlPath}"
            );
        }

        var sql = File.ReadAllText(dbSqlPath);

        connection.Execute(sql);
    }
}