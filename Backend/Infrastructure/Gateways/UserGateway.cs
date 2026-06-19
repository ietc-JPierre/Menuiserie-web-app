using Core.IGateways;
using Core.Models;
using Dapper;
using Infrastructure.Utils;

namespace Infrastructure.Gateways;

public class UserGateway : IUserGateway
{
    private readonly SqliteConnectionFactory _connectionFactory;

    public UserGateway(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                Id_User,
                username AS Username,
                email AS Email,
                password_hash AS Password_Hash,
                role AS Role
            FROM User
            WHERE email = @Email
        """;

        return await connection.QueryFirstOrDefaultAsync<User>(
            sql,
            new { Email = email }
        );
    }

    public async Task<int> CreateAsync(User user)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            INSERT INTO User
            (
                username,
                email,
                password_hash,
                role
            )
            VALUES
            (
                @Username,
                @Email,
                @Password_Hash,
                @Role
            );

            SELECT last_insert_rowid();
        """;

        return await connection.ExecuteScalarAsync<int>(sql, user);
    }
}