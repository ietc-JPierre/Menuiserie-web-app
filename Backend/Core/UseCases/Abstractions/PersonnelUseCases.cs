using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class PersonnelUseCases
{
    private readonly IPersonnelGateway _gateway;

    public PersonnelUseCases(IPersonnelGateway gateway)
    {
        _gateway = gateway;
    }

    public Task<IEnumerable<Personnel>> GetAllAsync() => _gateway.GetAllAsync();
    public Task<Personnel?> GetByIdAsync(string id) => _gateway.GetByIdAsync(id);
    public Task<string> CreateAsync(Personnel personnel) => _gateway.CreateAsync(personnel);
    public Task<bool> UpdateAsync(Personnel personnel) => _gateway.UpdateAsync(personnel);
    public Task<bool> DeleteAsync(string id) => _gateway.DeleteAsync(id);
}