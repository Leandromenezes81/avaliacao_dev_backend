using MediatR;
using System.Collections.Generic;
using Vectra.Avaliacao.Backend.Application.ViewModels;
using Vectra.Avaliacao.Backend.Application.ViewModels.Account;

namespace Vectra.Avaliacao.Backend.Application.Queries.Accounts.GettAllAccounts;

public record GetAllAccountsQuery(int Page, int PageSize) : IRequest<PaginationViewModel<List<AccountViewModel>>>;
