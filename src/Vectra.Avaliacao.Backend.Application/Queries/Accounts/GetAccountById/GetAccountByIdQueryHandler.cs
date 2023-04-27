using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.ViewModels.Account;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

namespace Vectra.Avaliacao.Backend.Application.Queries.Accounts.GetAccountById;

public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountViewModel>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountByIdQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountViewModel> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetByIdAsync(request.Id);

        if (account == null)
            return default;

        return new AccountViewModel(
            account.Id.ToString(),
            account.Branch,
            account.Number,
            account.User.Email,
            account.Balance.ToString(),
            account.CreatedAt.ToString(),
            account.UpdatedAt.ToString(),
            account.IsActive.ToString());
    }
}
