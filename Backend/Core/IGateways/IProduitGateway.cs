using Core.Models;

namespace Core.IGateways;

public interface IProduitGateway
{
    Task<IEnumerable<Produit>> GetAllAsync();
    Task<Produit?> GetByIdAsync(int id);
    Task<int> CreateAsync(Produit produit);
    Task<bool> UpdateAsync(Produit produit);
    Task<bool> DeleteAsync(int id);
}