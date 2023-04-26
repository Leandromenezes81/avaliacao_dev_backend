using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    IQueryable<TEntity> GetQueryAble();
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
