using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Entities;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

namespace Vectra.Avaliacao.Backend.Infra.Repositories;

public class AccountRepository : IAccountRepository

{
    private readonly IRepositoryBase<Account> _repositoryBase;

    public AccountRepository(IRepositoryBase<Account> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task AddAsync(Account account) => 
        await _repositoryBase.CreateAsync(account);

    public async Task<List<Account>> GetAllAsync(int page, int pageSize) =>
        await _repositoryBase.GetQueryAble()
            .AsNoTracking()
            .Include(x => x.User)
            .Skip(page * pageSize)
            .Take(pageSize)
            .OrderBy(x => x.Id)
            .ToListAsync();

    public async Task<Account?> GetByIdAsync(int id) =>  
        await _repositoryBase.GetQueryAble()
            .AsNoTracking()
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<int> GetCountAsync() =>
        await _repositoryBase.GetCountAsync();

    public void Update(Account account) => 
        _repositoryBase.Update(account);
}
