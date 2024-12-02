using Fipecafi.Domain.Entities;
using Fipecafi.Domain.Repositories.Aluno;
using Fipecafi.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Fipecafi.Infrastructure.Repositories;

public class AlunoRepository : IMatricularAlunoWriteRepository
{
    private readonly FipecafiDBContext _dbContext;
    public AlunoRepository(FipecafiDBContext dbContext) => _dbContext = dbContext;
    
    public async Task<int> GetNextCodigoMatricula()
    {
        var ultimoCodigo = await _dbContext.Alunos.MaxAsync(a => (int?)a.CodigoMatricula) ?? 0;
        return ultimoCodigo + 1;
    }


    public async Task<IEnumerable<Turma>> GetTurmasByCursoId(int cursoId)
    {
        return await _dbContext.Turmas.Where(t => t.CursoId == cursoId).ToListAsync();
    }

    public async Task<bool> Add(Aluno aluno)
    {
        await _dbContext.Alunos.AddAsync(aluno);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
