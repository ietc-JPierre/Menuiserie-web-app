using Core.Models;

namespace Core.IGateways;

public interface IPersonnelGateway
{
    Task<IEnumerable<Personnel>> GetAllAsync();
    Task<Personnel?> GetByIdAsync(string id);
    Task<string> CreateAsync(Personnel personnel);
    Task<bool> UpdateAsync(Personnel personnel);
    Task<bool> DeleteAsync(string id);
}