using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class TypeClientGateway : ITypeClientGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public TypeClientGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<TypeClient>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Type_client AS Id_Type_Client,
                nom_type AS Nom_Type
            FROM Type_client
        """;

        return await connection.QueryAsync<TypeClient>(sql);
    }

    public async Task<TypeClient?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_Type_client AS Id_Type_Client,
                nom_type AS Nom_Type
            FROM Type_client
            WHERE Id_Type_client = @Id
        """;

        return await connection.QueryFirstOrDefaultAsync<TypeClient>(sql, new { Id = id });
    }
}