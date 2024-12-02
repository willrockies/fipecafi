namespace Fipecafi.Domain.Repositories.Lead;

public interface ILeadReadOnlyRepository
{
    Task<IEnumerable<Entities.Lead>> GetLeads(string? nome, string? email, int? cursoId);
    Task<bool> CursoExists(int cursoId);
    Task<Entities.Lead> GetLeadByIdAsync(int leadId);
}
