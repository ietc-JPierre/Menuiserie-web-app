using Core.Models;

namespace Core.IGateways;

public interface IClientChantierGateway
{
    Task<IEnumerable<ClientChantier>> GetAllAsync();
    Task CreateAsync(ClientChantier item);
    Task<bool> DeleteAsync(int idClient, int idChantier);
}