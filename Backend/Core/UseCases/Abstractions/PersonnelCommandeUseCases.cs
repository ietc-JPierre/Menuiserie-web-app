using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class PersonnelCommandeUseCases
{
    private readonly IPersonnelCommandeGateway _gateway;

    public PersonnelCommandeUseCases(IPersonnelCommandeGateway gateway)
    {
        _gateway = gateway;
    }

    public Task<IEnumerable<PersonnelCommande>> GetAllAsync() => _gateway.GetAllAsync();
    public Task CreateAsync(PersonnelCommande item) => _gateway.CreateAsync(item);
    public Task<bool> DeleteAsync(string idPersonnel, int idCommande) => _gateway.DeleteAsync(idPersonnel, idCommande);
}