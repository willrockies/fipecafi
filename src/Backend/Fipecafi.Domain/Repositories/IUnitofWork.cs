namespace Fipecafi.Domain.Repositories;

public interface IUnitofWork
{
    public Task Commit();
}
