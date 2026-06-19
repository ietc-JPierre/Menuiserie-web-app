using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class PersonnelCommandeGateway : IPersonnelCommandeGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public PersonnelCommandeGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<PersonnelCommande>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryAsync<PersonnelCommande>(
            "SELECT Id_Personnel, Id_Commande FROM Personnel_commande"
        );
    }

    public async Task CreateAsync(PersonnelCommande item)
    {
        using var connection = _connectionFactory.CreateConnection();

        await connection.ExecuteAsync("""
            INSERT INTO Personnel_commande(Id_Personnel, Id_Commande)
            VALUES(@Id_Personnel, @Id_Commande)
        """, item);
    }

    public async Task<bool> DeleteAsync(string idPersonnel, int idCommande)
    {
        using var connection = _connectionFactory.CreateConnection();

        return await connection.ExecuteAsync("""
            DELETE FROM Personnel_commande
            WHERE Id_Personnel = @IdPersonnel
            AND Id_Commande = @IdCommande
        """, new { IdPersonnel = idPersonnel, IdCommande = idCommande }) > 0;
    }
}