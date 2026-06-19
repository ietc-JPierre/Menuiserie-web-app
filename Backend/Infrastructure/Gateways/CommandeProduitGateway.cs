using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class CommandeProduitGateway : ICommandeProduitGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public CommandeProduitGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<CommandeProduit>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryAsync<CommandeProduit>("""
            SELECT
                Id_Produit,
                Id_Dimension,
                Id_Commande,
                quantite AS Quantite,
                prix_unitaire AS Prix_Unitaire
            FROM Commande_produit
        """);
    }

    public async Task CreateAsync(CommandeProduit item)
    {
        using var connection = _connectionFactory.CreateConnection();

        await connection.ExecuteAsync("""
            INSERT INTO Commande_produit(
                Id_Produit,
                Id_Dimension,
                Id_Commande,
                quantite,
                prix_unitaire
            )
            VALUES(
                @Id_Produit,
                @Id_Dimension,
                @Id_Commande,
                @Quantite,
                @Prix_Unitaire
            )
        """, item);
    }

    public async Task<bool> DeleteAsync(int idProduit, int idDimension, int idCommande)
    {
        using var connection = _connectionFactory.CreateConnection();

        return await connection.ExecuteAsync("""
            DELETE FROM Commande_produit
            WHERE Id_Produit = @IdProduit
            AND Id_Dimension = @IdDimension
            AND Id_Commande = @IdCommande
        """, new
        {
            IdProduit = idProduit,
            IdDimension = idDimension,
            IdCommande = idCommande
        }) > 0;
    }
}