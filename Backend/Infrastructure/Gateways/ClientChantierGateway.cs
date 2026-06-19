using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class ClientChantierGateway : IClientChantierGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public ClientChantierGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<ClientChantier>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryAsync<ClientChantier>(
            "SELECT Id_Client, Id_Chantier FROM Client_chantier"
        );
    }

    public async Task CreateAsync(ClientChantier item)
    {
        using var connection = _connectionFactory.CreateConnection();

        await connection.ExecuteAsync("""
            INSERT INTO Client_chantier(Id_Client, Id_Chantier)
            VALUES(@Id_Client, @Id_Chantier)
        """, item);
    }

    public async Task<bool> DeleteAsync(int idClient, int idChantier)
    {
        using var connection = _connectionFactory.CreateConnection();

        return await connection.ExecuteAsync("""
            DELETE FROM Client_chantier
            WHERE Id_Client = @IdClient
            AND Id_Chantier = @IdChantier
        """, new { IdClient = idClient, IdChantier = idChantier }) > 0;
    }
}