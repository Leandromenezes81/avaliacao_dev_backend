using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;
using Vectra.Avaliacao.Backend.Domain.Interfaces.UnitOfWork;

namespace Vectra.Avaliacao.Backend.Application.Commands.Accounts.UpdateAccount;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
{
    private readonly IAccountRepository _accountRepository;    
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAccountCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = _accountRepository.GetByIdAsync(request.Id).Result;

        if (account == null)
            return default;

        account.Branch = request.Branch;
        account.Number = request.Number;
        account.Balance = request.Balance;
        account.UpdatedAt = DateTime.Now;
        account.IsActive = request.IsActive;

        _accountRepository.Update(account);
        await _unitOfWork.Commit();

        return Unit.Value;
    }
}
