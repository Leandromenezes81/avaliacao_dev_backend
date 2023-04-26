using System.Collections.Generic;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

public interface IAccountRepository
{
    Task AddAsync(Account account);
    Task<List<Account>> GetAllAsync(int page, int pageSize);
    Task<Account?> GetByIdAsync(int id);
    void Update (Account account);
}
