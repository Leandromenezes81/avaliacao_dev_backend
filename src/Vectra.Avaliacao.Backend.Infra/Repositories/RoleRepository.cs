using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Entities;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

namespace Vectra.Avaliacao.Backend.Infra.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IRepositoryBase<Role> _repositoryBase;

    public RoleRepository(IRepositoryBase<Role> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<Role?> GetByIdAsync(int id) => 
        await _repositoryBase.GetByIdAsync(id);
}
