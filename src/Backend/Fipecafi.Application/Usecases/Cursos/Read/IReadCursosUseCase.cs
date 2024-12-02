using Fipecafi.Communication.Responses;

namespace Fipecafi.Application.Usecases.Cursos.Read;

public interface IReadCursosUseCase
{
    public Task<IEnumerable<ResponseCursoJson>> Execute();
    public Task<string> GetCursoDescricaoByIdAsync(int cursoId);
}
