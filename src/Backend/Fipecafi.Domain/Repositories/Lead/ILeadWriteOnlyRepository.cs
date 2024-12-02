

namespace Fipecafi.Domain.Repositories.Lead;

public interface ILeadWriteOnlyRepository
{
    public Task Add(Entities.Lead lead);
}
