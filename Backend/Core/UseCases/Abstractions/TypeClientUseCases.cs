using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class TypeClientUseCases
{
    private readonly ITypeClientGateway _typeClientGateway;

    public TypeClientUseCases(ITypeClientGateway typeClientGateway)
    {
        _typeClientGateway = typeClientGateway;
    }

    public async Task<IEnumerable<TypeClient>> GetAllAsync()
    {
        return await _typeClientGateway.GetAllAsync();
    }

    public async Task<TypeClient?> GetByIdAsync(int id)
    {
        return await _typeClientGateway.GetByIdAsync(id);
    }
}