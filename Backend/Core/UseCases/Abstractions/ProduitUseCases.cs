using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class ProduitUseCases
{
    private readonly IProduitGateway _produitGateway;

    public ProduitUseCases(IProduitGateway produitGateway)
    {
        _produitGateway = produitGateway;
    }

    public Task<IEnumerable<Produit>> GetAllAsync()
        => _produitGateway.GetAllAsync();

    public Task<Produit?> GetByIdAsync(int id)
        => _produitGateway.GetByIdAsync(id);

    public Task<int> CreateAsync(Produit produit)
        => _produitGateway.CreateAsync(produit);

    public Task<bool> UpdateAsync(Produit produit)
        => _produitGateway.UpdateAsync(produit);

    public Task<bool> DeleteAsync(int id)
        => _produitGateway.DeleteAsync(id);
}