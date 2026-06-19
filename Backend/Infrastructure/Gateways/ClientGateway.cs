using Core.IGateways;
using Core.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Gateways;

public class ClientGateway : IClientGateway
{
    private readonly IClientRepository _repository;

    public ClientGateway(IClientRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Client>> GetAllAsync()
        => _repository.GetAllAsync();

    public Task<Client?> GetByIdAsync(int id)
        => _repository.GetByIdAsync(id);

    public Task<int> CreateAsync(Client client)
        => _repository.CreateAsync(client);

    public Task<bool> UpdateAsync(Client client)
        => _repository.UpdateAsync(client);

    public Task<bool> DeleteAsync(int id)
        => _repository.DeleteAsync(id);
}