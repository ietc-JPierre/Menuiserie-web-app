using Core.IGateways;
using Core.Models;

namespace Core.UseCases.Abstractions;

public class CodePostalChantierUseCases
{
    private readonly ICodePostalChantierGateway _gateway;

    public CodePostalChantierUseCases(ICodePostalChantierGateway gateway)
    {
        _gateway = gateway;
    }

    public Task<IEnumerable<CodePostalChantier>> GetAllAsync() => _gateway.GetAllAsync();
    public Task<CodePostalChantier?> GetByIdAsync(string codePostal) => _gateway.GetByIdAsync(codePostal);
    public Task<string> CreateAsync(CodePostalChantier codePostalChantier) => _gateway.CreateAsync(codePostalChantier);
    public Task<bool> UpdateAsync(CodePostalChantier codePostalChantier) => _gateway.UpdateAsync(codePostalChantier);
    public Task<bool> DeleteAsync(string codePostal) => _gateway.DeleteAsync(codePostal);
}