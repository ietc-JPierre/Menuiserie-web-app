using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class ClientChantierUseCases
{
    private readonly IClientChantierGateway _gateway;

    public ClientChantierUseCases(IClientChantierGateway gateway)
    {
        _gateway = gateway;
    }

    public Task<IEnumerable<ClientChantier>> GetAllAsync() => _gateway.GetAllAsync();
    public Task CreateAsync(ClientChantier item) => _gateway.CreateAsync(item);
    public Task<bool> DeleteAsync(int idClient, int idChantier) => _gateway.DeleteAsync(idClient, idChantier);
}