using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;
using Vectra.Avaliacao.Backend.Infra.Persistence.Data;

namespace Vectra.Avaliacao.Backend.Infra.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;

    public RepositoryBase(VectraDbContext dbContext) => 
        _dbSet = dbContext.Set<TEntity>();

    public async Task<List<TEntity>> GetAllAsync() =>
        await _dbSet.ToListAsync();

    public async Task<TEntity> GetByIdAsync(int id) => 
        await _dbSet.FindAsync(id);

    public IQueryable<TEntity> GetQueryAble() => _dbSet;

    public async Task CreateAsync(TEntity entity) => await _dbSet.AddAsync(entity);

    public void Update(TEntity entity) => _dbSet.Update(entity);

    public void Delete(TEntity entity) => _dbSet.Remove(entity);

}
