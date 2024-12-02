using Fipecafi.Communication.Responses;

namespace Fipecafi.Application.Usecases.Leads.Read;

public interface IReadLeadsUseCase
{
    Task<IEnumerable<ResponseReadLeadJson>> Execute(string? nome, string? email, int? cursoId);

}
