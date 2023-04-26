using MediatR;
using System.Collections.Generic;
using Vectra.Avaliacao.Backend.Application.ViewModels;

namespace Vectra.Avaliacao.Backend.Application.Queries.Accounts.GettAllAccounts;

public record GetAllAccountsQuery(int Page, int PageSize) : IRequest<List<AccountViewModel>>
{ }
