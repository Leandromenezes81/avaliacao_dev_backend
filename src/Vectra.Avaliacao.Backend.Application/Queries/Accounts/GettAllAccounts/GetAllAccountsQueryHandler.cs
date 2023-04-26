﻿using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.ViewModels;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

namespace Vectra.Avaliacao.Backend.Application.Queries.Accounts.GettAllAccounts;

public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, List<AccountViewModel>>
{
    private readonly IAccountRepository _accountRepository;

    public GetAllAccountsQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<List<AccountViewModel>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
    {
        var accounts = await _accountRepository.GetAllAsync(request.Page, request.PageSize);

        return accounts
            .Select(x => new AccountViewModel(
                x.Id.ToString(),
                x.Branch,
                x.Number,
                x.User.Email,
                x.Balance.ToString(),
                x.CreatedAt.ToString(),
                x.UpdatedAt.ToString(),
                x.IsActive.ToString()))
            .ToList();
    }
}
