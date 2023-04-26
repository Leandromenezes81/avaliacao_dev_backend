using MediatR;

namespace Vectra.Avaliacao.Backend.Application.Commands.Users.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<string>
{
}
