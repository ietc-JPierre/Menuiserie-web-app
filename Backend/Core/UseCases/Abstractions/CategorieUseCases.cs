using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class CategorieUseCases
{
    private readonly ICategorieGateway _categorieGateway;

    public CategorieUseCases(ICategorieGateway categorieGateway)
    {
        _categorieGateway = categorieGateway;
    }

    public Task<IEnumerable<Categorie>> GetAllAsync()
        => _categorieGateway.GetAllAsync();

    public Task<Categorie?> GetByIdAsync(int id)
        => _categorieGateway.GetByIdAsync(id);

    public Task<int> CreateAsync(Categorie categorie)
        => _categorieGateway.CreateAsync(categorie);

    public Task<bool> UpdateAsync(Categorie categorie)
        => _categorieGateway.UpdateAsync(categorie);

    public Task<bool> DeleteAsync(int id)
        => _categorieGateway.DeleteAsync(id);
}