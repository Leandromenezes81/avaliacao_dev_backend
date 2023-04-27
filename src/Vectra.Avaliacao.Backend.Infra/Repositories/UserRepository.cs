using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Entities;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

namespace Vectra.Avaliacao.Backend.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IRepositoryBase<User> _repositoryBase;

    public UserRepository(IRepositoryBase<User> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task AddAsync(User user) =>
        await _repositoryBase.CreateAsync(user);

    public async Task<List<User>> GetAllAsync(int page, int pageSize) =>
        await _repositoryBase
                .GetAllAsync(page, pageSize);

    public async Task<User> GetByIdAsync(int id) =>
        await _repositoryBase
                .GetByIdAsync(id);

    public async Task<User> GetByNameAsync(string name) =>
        await _repositoryBase
                .GetQueryAble()
                .FirstOrDefaultAsync(x => x.Name.Contains(name));

    public async Task<User> GetByPasswordAndEmailAsync(string email, string password) =>
        await _repositoryBase
                .GetQueryAble()
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);

    public async Task<int> GetCountAsync() =>
        await _repositoryBase
                .GetCountAsync();

    public void Update(User user) => _repositoryBase.Update(user);
}
