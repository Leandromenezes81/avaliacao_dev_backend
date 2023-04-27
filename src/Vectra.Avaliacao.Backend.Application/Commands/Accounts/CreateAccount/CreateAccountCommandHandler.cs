using MediatR;
using System;
using System.Data.SqlTypes;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Entities;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;
using Vectra.Avaliacao.Backend.Domain.Interfaces.UnitOfWork;

namespace Vectra.Avaliacao.Backend.Application.Commands.Accounts.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, string>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAccountCommandHandler(IAccountRepository accountRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetByIdAsync(request.UserId).Result;

        if (user == null)
            return string.Empty;

        var account = new Account(
            request.UserId,
            request.Branch,
            request.Number,
            request.Balance,
            DateTime.Now,
            DateTime.Now,
            true,
            user);


        await _accountRepository.AddAsync(account);
        await _unitOfWork.Commit();

        return account.Id.ToString();
    }
}
