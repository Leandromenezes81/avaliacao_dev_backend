using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

    public async Task<List<User>> GetAllAsync() => 
        await _repositoryBase.GetAllAsync();

    public async Task<User?> GetByIdAsync(int id) => await _repositoryBase.GetByIdAsync(id);

    public Task<User?> GetByPasswordAndEmailAsync(string email, string password) => 
        _repositoryBase.GetQueryAble()
                .Include(x => x.Roles)
                .SingleOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);

    public void Update(User user) => _repositoryBase.Update(user);
}
