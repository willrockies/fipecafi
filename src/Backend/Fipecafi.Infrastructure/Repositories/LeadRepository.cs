using Fipecafi.Domain.Entities;
using Fipecafi.Domain.Repositories.Lead;
using Fipecafi.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Fipecafi.Infrastructure.Repositories;

public class LeadRepository : ILeadWriteOnlyRepository, ILeadReadOnlyRepository
{
    private readonly FipecafiDBContext _dbContext;

    public LeadRepository(FipecafiDBContext dbContext) => _dbContext = dbContext;

    public async Task Add(Lead lead) => await _dbContext.Leads.AddAsync(lead);
    public async Task<bool> CursoExists(int cursoId)
    {
        return await _dbContext.Cursos.AnyAsync(curso => curso.Id == cursoId);
    }
    public async Task<IEnumerable<Lead>> GetLeads(string? nome, string? email, int? cursoId)
    {
        var query = _dbContext.Leads.Include(lead => lead.Curso).AsQueryable();

        if (!string.IsNullOrWhiteSpace(nome))
            query = query.Where(lead => lead.Nome.Contains(nome));

        if (!string.IsNullOrWhiteSpace(email))
            query = query.Where(lead => lead.Email.Contains(email));

        if (cursoId.HasValue)
            query = query.Where(lead => lead.CursoId == cursoId);

        return await query.ToListAsync();
    }

    public async Task<Lead> GetLeadByIdAsync(int leadId)
    {
        return await _dbContext.Leads.FindAsync(leadId);
    }
}
