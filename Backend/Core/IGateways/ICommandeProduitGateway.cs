using Core.Models;

namespace Core.IGateways;

public interface ICommandeProduitGateway
{
    Task<IEnumerable<CommandeProduit>> GetAllAsync();
    Task CreateAsync(CommandeProduit item);
    Task<bool> DeleteAsync(int idProduit, int idDimension, int idCommande);
}