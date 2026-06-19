using Core.Models;

namespace Core.IGateways;

public interface IPersonnelCommandeGateway
{
    Task<IEnumerable<PersonnelCommande>> GetAllAsync();
    Task CreateAsync(PersonnelCommande item);
    Task<bool> DeleteAsync(string idPersonnel, int idCommande);
}