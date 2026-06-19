using Core.Models;

namespace Core.IGateways;

public interface ITypeClientGateway
{
    Task<IEnumerable<TypeClient>> GetAllAsync();

    Task<TypeClient?> GetByIdAsync(int id);
}