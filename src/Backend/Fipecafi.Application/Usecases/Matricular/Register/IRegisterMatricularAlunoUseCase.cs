using Fipecafi.Communication.Requests;

namespace Fipecafi.Application.Usecases.Matricular.Register;

public interface IRegisterMatricularAlunoUseCase
{
    public Task<bool> Execute(int leadId, int turmaId);
}
