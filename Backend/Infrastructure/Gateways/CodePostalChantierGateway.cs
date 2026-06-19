using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class CodePostalChantierGateway : ICodePostalChantierGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public CodePostalChantierGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<CodePostalChantier>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                code_postal AS Code_Postal,
                ville AS Ville
            FROM Code_postal_chantier
        """;

        return await connection.QueryAsync<CodePostalChantier>(sql);
    }

    public async Task<CodePostalChantier?> GetByIdAsync(string codePostal)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                code_postal AS Code_Postal,
                ville AS Ville
            FROM Code_postal_chantier
            WHERE code_postal = @CodePostal
        """;

        return await connection.QueryFirstOrDefaultAsync<CodePostalChantier>(sql, new { CodePostal = codePostal });
    }

    public async Task<string> CreateAsync(CodePostalChantier codePostalChantier)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            INSERT INTO Code_postal_chantier(code_postal, ville)
            VALUES(@Code_Postal, @Ville)
        """;

        await connection.ExecuteAsync(sql, codePostalChantier);

        return codePostalChantier.Code_Postal;
    }

    public async Task<bool> UpdateAsync(CodePostalChantier codePostalChantier)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            UPDATE Code_postal_chantier
            SET ville = @Ville
            WHERE code_postal = @Code_Postal
        """;

        return await connection.ExecuteAsync(sql, codePostalChantier) > 0;
    }

    public async Task<bool> DeleteAsync(string codePostal)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            DELETE FROM Code_postal_chantier
            WHERE code_postal = @CodePostal
        """;

        return await connection.ExecuteAsync(sql, new { CodePostal = codePostal }) > 0;
    }
}