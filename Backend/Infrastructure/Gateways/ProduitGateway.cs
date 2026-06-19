using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class ProduitGateway : IProduitGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public ProduitGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Produit>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Produit,
                nom_produit AS Nom_Produit,
                prix_unitaire_produit AS Prix_Unitaire_Produit,
                Id_Categorie
            FROM Produit
        """;

        return await connection.QueryAsync<Produit>(sql);
    }

    public async Task<Produit?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Produit,
                nom_produit AS Nom_Produit,
                prix_unitaire_produit AS Prix_Unitaire_Produit,
                Id_Categorie
            FROM Produit
            WHERE Id_Produit = @Id
        """;

        return await connection.QueryFirstOrDefaultAsync<Produit>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Produit produit)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            INSERT INTO Produit
            (
                nom_produit,
                prix_unitaire_produit,
                Id_Categorie
            )
            VALUES
            (
                @Nom_Produit,
                @Prix_Unitaire_Produit,
                @Id_Categorie
            );

            SELECT last_insert_rowid();
        """;

        return await connection.ExecuteScalarAsync<int>(sql, produit);
    }

    public async Task<bool> UpdateAsync(Produit produit)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            UPDATE Produit
            SET
                nom_produit = @Nom_Produit,
                prix_unitaire_produit = @Prix_Unitaire_Produit,
                Id_Categorie = @Id_Categorie
            WHERE Id_Produit = @Id_Produit
        """;

        var rows = await connection.ExecuteAsync(sql, produit);

        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            DELETE FROM Produit
            WHERE Id_Produit = @Id
        """;

        var rows = await connection.ExecuteAsync(sql, new { Id = id });

        return rows > 0;
    }
}