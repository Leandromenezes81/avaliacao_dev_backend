using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Interfaces.UnitOfWork;
using Vectra.Avaliacao.Backend.Infra.Persistence.Data;

namespace Vectra.Avaliacao.Backend.Infra.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public readonly VectraDbContext _dbContext;

    public UnitOfWork(VectraDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<bool> Commit() => (await _dbContext.SaveChangesAsync()) > 0;

    public void Dispose() => _dbContext.Dispose();

    public Task Rollback() => Task.CompletedTask;
}
