using Core.Models;

namespace Core.IGateways;

public interface IDimensionGateway
{
    Task<IEnumerable<Dimension>> GetAllAsync();
    Task<Dimension?> GetByIdAsync(int id);
    Task<int> CreateAsync(Dimension dimension);
    Task<bool> UpdateAsync(Dimension dimension);
    Task<bool> DeleteAsync(int id);
}