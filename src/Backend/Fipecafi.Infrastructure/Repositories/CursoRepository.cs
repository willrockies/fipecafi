using Fipecafi.Domain.Entities;
using Fipecafi.Domain.Repositories.Curso;
using Fipecafi.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Fipecafi.Infrastructure.Repositories;

public class CursoRepository : ICursoReadOnlyRepository
{
    private readonly FipecafiDBContext _dbContext;
    public CursoRepository(FipecafiDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Curso>> GetCursos()
    {
        return await _dbContext.Cursos.ToListAsync(); 
    }

    public async Task<Curso> GetCursoById(int cursoId)
    {
        var query = _dbContext.Leads.Include(lead => lead.Curso).AsQueryable();


        return await _dbContext.Cursos
          .FirstOrDefaultAsync(c => c.Id == cursoId);
    }

   
}
