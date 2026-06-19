using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class CommandeUseCases
{
    private readonly ICommandeGateway _gateway;

    public CommandeUseCases(ICommandeGateway gateway)
    {
        _gateway = gateway;
    }

    public Task<IEnumerable<Commande>> GetAllAsync() => _gateway.GetAllAsync();
    public Task<Commande?> GetByIdAsync(int id) => _gateway.GetByIdAsync(id);
    public Task<int> CreateAsync(Commande commande) => _gateway.CreateAsync(commande);
    public Task<bool> UpdateAsync(Commande commande) => _gateway.UpdateAsync(commande);
    public Task<bool> DeleteAsync(int id) => _gateway.DeleteAsync(id);
}