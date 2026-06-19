using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class PersonnelGateway : IPersonnelGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public PersonnelGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Personnel>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Personnel,
                nom AS Nom,
                role AS Role
            FROM Personnel
        """;

        return await connection.QueryAsync<Personnel>(sql);
    }

    public async Task<Personnel?> GetByIdAsync(string id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Personnel,
                nom AS Nom,
                role AS Role
            FROM Personnel
            WHERE Id_Personnel = @Id
        """;

        return await connection.QueryFirstOrDefaultAsync<Personnel>(sql, new { Id = id });
    }

    public async Task<string> CreateAsync(Personnel personnel)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            INSERT INTO Personnel(Id_Personnel, nom, role)
            VALUES(@Id_Personnel, @Nom, @Role)
        """;

        await connection.ExecuteAsync(sql, personnel);

        return personnel.Id_Personnel;
    }

    public async Task<bool> UpdateAsync(Personnel personnel)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            UPDATE Personnel
            SET
                nom = @Nom,
                role = @Role
            WHERE Id_Personnel = @Id_Personnel
        """;

        return await connection.ExecuteAsync(sql, personnel) > 0;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            DELETE FROM Personnel
            WHERE Id_Personnel = @Id
        """;

        return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
    }
}