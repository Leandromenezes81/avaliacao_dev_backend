using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

public interface IRoleRepository
{
    Task<Role?> GetByIdAsync(int id);
}
