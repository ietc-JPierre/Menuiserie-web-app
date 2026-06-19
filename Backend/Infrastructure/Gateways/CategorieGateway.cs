using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class CategorieGateway : ICategorieGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public CategorieGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Categorie>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Categorie,
                nom_categorie AS Nom_Categorie
            FROM Categorie
        """;

        return await connection.QueryAsync<Categorie>(sql);
    }

    public async Task<Categorie?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Categorie,
                nom_categorie AS Nom_Categorie
            FROM Categorie
            WHERE Id_Categorie = @Id
        """;

        return await connection.QueryFirstOrDefaultAsync<Categorie>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Categorie categorie)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            INSERT INTO Categorie(nom_categorie)
            VALUES(@Nom_Categorie);

            SELECT last_insert_rowid();
        """;

        return await connection.ExecuteScalarAsync<int>(sql, categorie);
    }

    public async Task<bool> UpdateAsync(Categorie categorie)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            UPDATE Categorie
            SET nom_categorie = @Nom_Categorie
            WHERE Id_Categorie = @Id_Categorie
        """;

        var rows = await connection.ExecuteAsync(sql, categorie);

        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            DELETE FROM Categorie
            WHERE Id_Categorie = @Id
        """;

        var rows = await connection.ExecuteAsync(sql, new { Id = id });

        return rows > 0;
    }
}