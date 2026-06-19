using Core.Models;

namespace Core.IGateways;

public interface IUserGateway
{
    Task<User?> GetByEmailAsync(string email);

    Task<int> CreateAsync(User user);
}