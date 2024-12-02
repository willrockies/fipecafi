using Fipecafi.Communication.Requests;
using Fipecafi.Communication.Responses;

namespace Fipecafi.Application.Usecases.Leads.Register;

public interface IRegisterLeadUseCase
{
    public Task<ResponseRegisteredLeadsJson> Execute(RequestRegisterLeadsJson request);
}
