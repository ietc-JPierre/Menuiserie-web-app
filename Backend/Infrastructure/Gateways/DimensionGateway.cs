using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class DimensionGateway : IDimensionGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public DimensionGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Dimension>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Dimension,
                hauteur AS Hauteur,
                section AS Section,
                largeur AS Largeur
            FROM Dimension
        """;

        return await connection.QueryAsync<Dimension>(sql);
    }

    public async Task<Dimension?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Dimension,
                hauteur AS Hauteur,
                section AS Section,
                largeur AS Largeur
            FROM Dimension
            WHERE Id_Dimension = @Id
        """;

        return await connection.QueryFirstOrDefaultAsync<Dimension>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Dimension dimension)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            INSERT INTO Dimension(hauteur, section, largeur)
            VALUES(@Hauteur, @Section, @Largeur);

            SELECT last_insert_rowid();
        """;

        return await connection.ExecuteScalarAsync<int>(sql, dimension);
    }

    public async Task<bool> UpdateAsync(Dimension dimension)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            UPDATE Dimension
            SET
                hauteur = @Hauteur,
                section = @Section,
                largeur = @Largeur
            WHERE Id_Dimension = @Id_Dimension
        """;

        return await connection.ExecuteAsync(sql, dimension) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            DELETE FROM Dimension
            WHERE Id_Dimension = @Id
        """;

        return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
    }
}