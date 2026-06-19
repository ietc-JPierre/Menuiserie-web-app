using Core.Models;

namespace Core.IGateways;

public interface IChantierGateway
{
    Task<IEnumerable<Chantier>> GetAllAsync();
    Task<Chantier?> GetByIdAsync(int id);
    Task<int> CreateAsync(Chantier chantier);
    Task<bool> UpdateAsync(Chantier chantier);
    Task<bool> DeleteAsync(int id);
}