using System.Collections.Generic;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByPasswordAndEmailAsync(string email, string password);
    void Update (User user);
}
