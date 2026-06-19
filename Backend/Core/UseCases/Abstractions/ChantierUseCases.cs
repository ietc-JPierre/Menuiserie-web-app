using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class ChantierUseCases
{
    private readonly IChantierGateway _gateway;

    public ChantierUseCases(IChantierGateway gateway)
    {
        _gateway = gateway;
    }

    public Task<IEnumerable<Chantier>> GetAllAsync() => _gateway.GetAllAsync();
    public Task<Chantier?> GetByIdAsync(int id) => _gateway.GetByIdAsync(id);
    public Task<int> CreateAsync(Chantier chantier) => _gateway.CreateAsync(chantier);
    public Task<bool> UpdateAsync(Chantier chantier) => _gateway.UpdateAsync(chantier);
    public Task<bool> DeleteAsync(int id) => _gateway.DeleteAsync(id);
}