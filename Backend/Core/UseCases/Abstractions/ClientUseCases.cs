using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class ClientUseCases
{
    private readonly IClientGateway _clientGateway;

    public ClientUseCases(IClientGateway clientGateway)
    {
        _clientGateway = clientGateway;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _clientGateway.GetAllAsync();
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _clientGateway.GetByIdAsync(id);
    }

    public async Task<int> CreateAsync(Client client)
    {
        return await _clientGateway.CreateAsync(client);
    }

    public async Task<bool> UpdateAsync(Client client)
    {
        return await _clientGateway.UpdateAsync(client);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _clientGateway.DeleteAsync(id);
    }
}