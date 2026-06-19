using Core.Models;

namespace Core.IGateways;

public interface ICommandeGateway
{
    Task<IEnumerable<Commande>> GetAllAsync();
    Task<Commande?> GetByIdAsync(int id);
    Task<int> CreateAsync(Commande commande);
    Task<bool> UpdateAsync(Commande commande);
    Task<bool> DeleteAsync(int id);
}