using MediatR;

namespace Vectra.Avaliacao.Backend.Application.Commands.Users.DeleteUser;

public record DeleteUserCommand(int Id) : IRequest<Unit>;