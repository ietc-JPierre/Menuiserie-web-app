using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public ClientRepository(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryAsync<Client>("""
            SELECT
                Id_Client,
                nom_client AS Nom_Client,
                adresse_client AS Adresse_Client,
                tel_client AS Tel_Client,
                Id_Type_client AS Id_Type_Client
            FROM Client
        """);
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Client>("""
            SELECT
                Id_Client,
                nom_client AS Nom_Client,
                adresse_client AS Adresse_Client,
                tel_client AS Tel_Client,
                Id_Type_client AS Id_Type_Client
            FROM Client
            WHERE Id_Client = @Id
        """, new { Id = id });
    }

    public async Task<int> CreateAsync(Client client)
    {
        using var connection = _connectionFactory.CreateConnection();

        return await connection.ExecuteScalarAsync<int>("""
            INSERT INTO Client
            (
                nom_client,
                adresse_client,
                tel_client,
                Id_Type_client
            )
            VALUES
            (
                @Nom_Client,
                @Adresse_Client,
                @Tel_Client,
                @Id_Type_Client
            );

            SELECT last_insert_rowid();
        """, client);
    }

    public async Task<bool> UpdateAsync(Client client)
    {
        using var connection = _connectionFactory.CreateConnection();

        var rows = await connection.ExecuteAsync("""
            UPDATE Client
            SET
                nom_client = @Nom_Client,
                adresse_client = @Adresse_Client,
                tel_client = @Tel_Client,
                Id_Type_client = @Id_Type_Client
            WHERE Id_Client = @Id_Client
        """, client);

        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        var rows = await connection.ExecuteAsync("""
            DELETE FROM Client
            WHERE Id_Client = @Id
        """, new { Id = id });

        return rows > 0;
    }
}