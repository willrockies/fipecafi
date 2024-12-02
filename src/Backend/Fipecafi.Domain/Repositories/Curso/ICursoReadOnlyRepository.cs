namespace Fipecafi.Domain.Repositories.Curso;

public interface ICursoReadOnlyRepository
{
    Task<IEnumerable<Entities.Curso>> GetCursos();
    Task<Entities.Curso> GetCursoById(int cursoId);
}
