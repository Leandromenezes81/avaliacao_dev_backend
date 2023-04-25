using MediatR;

namespace Vectra.Avaliacao.Backend.Application.Commands.Users.LoginUser;

public class LoginUserCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
