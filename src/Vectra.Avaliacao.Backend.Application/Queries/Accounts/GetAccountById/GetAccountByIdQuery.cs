using MediatR;
using Vectra.Avaliacao.Backend.Application.ViewModels;

namespace Vectra.Avaliacao.Backend.Application.Queries.Accounts.GetAccountById;

public record GetAccountByIdQuery(int Id) : IRequest<AccountViewModel>
{ }