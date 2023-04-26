using MediatR;
using Vectra.Avaliacao.Backend.Application.ViewModels;

namespace Vectra.Avaliacao.Backend.Application.Commands.Accounts.UpdateAccount;

public record UpdateAccountCommand(int Id, string Branch, string Number, decimal Balance, bool IsActive) : IRequest<Unit>
{
}
