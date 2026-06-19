using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class CommandeGateway : ICommandeGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public CommandeGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Commande>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Commande,
                date_commande AS Date_Commande,
                montant_paye AS Montant_Paye,
                reste_a_payer AS Reste_A_Payer,
                statut_commande AS Statut_Commande,
                total_commande AS Total_Commande,
                Id_Client
            FROM Commande
        """;

        return await connection.QueryAsync<Commande>(sql);
    }

    public async Task<Commande?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Commande,
                date_commande AS Date_Commande,
                montant_paye AS Montant_Paye,
                reste_a_payer AS Reste_A_Payer,
                statut_commande AS Statut_Commande,
                total_commande AS Total_Commande,
                Id_Client
            FROM Commande
            WHERE Id_Commande = @Id
        """;

        return await connection.QueryFirstOrDefaultAsync<Commande>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Commande commande)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            INSERT INTO Commande
            (
                date_commande,
                montant_paye,
                reste_a_payer,
                statut_commande,
                total_commande,
                Id_Client
            )
            VALUES
            (
                @Date_Commande,
                @Montant_Paye,
                @Reste_A_Payer,
                @Statut_Commande,
                @Total_Commande,
                @Id_Client
            );

            SELECT last_insert_rowid();
        """;

        return await connection.ExecuteScalarAsync<int>(sql, commande);
    }

    public async Task<bool> UpdateAsync(Commande commande)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            UPDATE Commande
            SET
                date_commande = @Date_Commande,
                montant_paye = @Montant_Paye,
                reste_a_payer = @Reste_A_Payer,
                statut_commande = @Statut_Commande,
                total_commande = @Total_Commande,
                Id_Client = @Id_Client
            WHERE Id_Commande = @Id_Commande
        """;

        return await connection.ExecuteAsync(sql, commande) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            DELETE FROM Commande
            WHERE Id_Commande = @Id
        """;

        return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
    }
}