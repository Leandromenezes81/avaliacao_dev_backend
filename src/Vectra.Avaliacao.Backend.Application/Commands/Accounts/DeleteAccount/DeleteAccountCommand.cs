using MediatR;

namespace Vectra.Avaliacao.Backend.Application.Commands.Accounts.DeleteAccount;

public record DeleteAccountCommand(int Id) : IRequest<Unit>;
