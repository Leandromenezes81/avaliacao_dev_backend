using System;
using System.Threading.Tasks;

namespace Vectra.Avaliacao.Backend.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit();
    Task Rollback();
}
