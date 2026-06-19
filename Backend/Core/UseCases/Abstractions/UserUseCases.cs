using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class UserUseCases
{
    private readonly IUserGateway _userGateway;

    public UserUseCases(IUserGateway userGateway)
    {
        _userGateway = userGateway;
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return _userGateway.GetByEmailAsync(email);
    }

    public Task<int> CreateAsync(User user)
    {
        return _userGateway.CreateAsync(user);
    }
}