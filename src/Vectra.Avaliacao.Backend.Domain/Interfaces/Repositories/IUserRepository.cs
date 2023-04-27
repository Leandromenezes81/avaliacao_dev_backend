using System.Collections.Generic;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<List<User>> GetAllAsync(int page, int pageSize);
    Task<User> GetByIdAsync(int id);
    Task<User> GetByNameAsync(string name);
    Task<User> GetByPasswordAndEmailAsync(string email, string password);
    Task<int> GetCountAsync();
    void Update (User user);
}
