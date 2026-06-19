using Core.Models;

namespace Infrastructure.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int id);
    Task<int> CreateAsync(Client client);
    Task<bool> UpdateAsync(Client client);
    Task<bool> DeleteAsync(int id);
}