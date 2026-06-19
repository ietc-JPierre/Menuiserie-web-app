using Core.Models;

namespace Core.IGateways;

public interface ICategorieGateway
{
    Task<IEnumerable<Categorie>> GetAllAsync();

    Task<Categorie?> GetByIdAsync(int id);

    Task<int> CreateAsync(Categorie categorie);

    Task<bool> UpdateAsync(Categorie categorie);

    Task<bool> DeleteAsync(int id);
}