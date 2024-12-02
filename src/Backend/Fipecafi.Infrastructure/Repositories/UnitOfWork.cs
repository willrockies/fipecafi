using Fipecafi.Domain.Repositories;
using Fipecafi.Infrastructure.DataAccess;

namespace Fipecafi.Infrastructure.Repositories;

public class UnitOfWork : IUnitofWork
{
    private readonly FipecafiDBContext _dbContext;

    public UnitOfWork(FipecafiDBContext dbContext) => _dbContext = dbContext;

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
