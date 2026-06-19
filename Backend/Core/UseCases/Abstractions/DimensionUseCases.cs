using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class DimensionUseCases
{
    private readonly IDimensionGateway _gateway;

    public DimensionUseCases(IDimensionGateway gateway)
    {
        _gateway = gateway;
    }

    public Task<IEnumerable<Dimension>> GetAllAsync() => _gateway.GetAllAsync();
    public Task<Dimension?> GetByIdAsync(int id) => _gateway.GetByIdAsync(id);
    public Task<int> CreateAsync(Dimension dimension) => _gateway.CreateAsync(dimension);
    public Task<bool> UpdateAsync(Dimension dimension) => _gateway.UpdateAsync(dimension);
    public Task<bool> DeleteAsync(int id) => _gateway.DeleteAsync(id);
}