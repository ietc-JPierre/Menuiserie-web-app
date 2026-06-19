using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class ChantierGateway : IChantierGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public ChantierGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Chantier>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Chantier,
                nom_chantier AS Nom_Chantier,
                rue AS Rue,
                date_debut_chantier AS Date_Debut_Chantier,
                date_fin_chantier AS Date_Fin_Chantier,
                code_postal AS Code_Postal
            FROM Chantier
        """;

        return await connection.QueryAsync<Chantier>(sql);
    }

    public async Task<Chantier?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Chantier,
                nom_chantier AS Nom_Chantier,
                rue AS Rue,
                date_debut_chantier AS Date_Debut_Chantier,
                date_fin_chantier AS Date_Fin_Chantier,
                code_postal AS Code_Postal
            FROM Chantier
            WHERE Id_Chantier = @Id
        """;

        return await connection.QueryFirstOrDefaultAsync<Chantier>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Chantier chantier)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            INSERT INTO Chantier
            (
                nom_chantier,
                rue,
                date_debut_chantier,
                date_fin_chantier,
                code_postal
            )
            VALUES
            (
                @Nom_Chantier,
                @Rue,
                @Date_Debut_Chantier,
                @Date_Fin_Chantier,
                @Code_Postal
            );

            SELECT last_insert_rowid();
        """;

        return await connection.ExecuteScalarAsync<int>(sql, chantier);
    }

    public async Task<bool> UpdateAsync(Chantier chantier)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            UPDATE Chantier
            SET
                nom_chantier = @Nom_Chantier,
                rue = @Rue,
                date_debut_chantier = @Date_Debut_Chantier,
                date_fin_chantier = @Date_Fin_Chantier,
                code_postal = @Code_Postal
            WHERE Id_Chantier = @Id_Chantier
        """;

        return await connection.ExecuteAsync(sql, chantier) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            DELETE FROM Chantier
            WHERE Id_Chantier = @Id
        """;

        return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
    }
}