using Core.Models;

namespace Core.IGateways;

public interface ICodePostalChantierGateway
{
    Task<IEnumerable<CodePostalChantier>> GetAllAsync();
    Task<CodePostalChantier?> GetByIdAsync(string codePostal);
    Task<string> CreateAsync(CodePostalChantier codePostalChantier);
    Task<bool> UpdateAsync(CodePostalChantier codePostalChantier);
    Task<bool> DeleteAsync(string codePostal);
}