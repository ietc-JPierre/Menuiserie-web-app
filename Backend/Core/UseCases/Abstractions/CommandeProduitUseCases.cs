using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class CommandeProduitUseCases
{
    private readonly ICommandeProduitGateway _gateway;

    public CommandeProduitUseCases(ICommandeProduitGateway gateway)
    {
        _gateway = gateway;
    }

    public Task<IEnumerable<CommandeProduit>> GetAllAsync() => _gateway.GetAllAsync();
    public Task CreateAsync(CommandeProduit item) => _gateway.CreateAsync(item);
    public Task<bool> DeleteAsync(int idProduit, int idDimension, int idCommande) =>
        _gateway.DeleteAsync(idProduit, idDimension, idCommande);
}