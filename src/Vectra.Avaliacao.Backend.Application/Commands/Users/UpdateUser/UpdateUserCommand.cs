using MediatR;

namespace Vectra.Avaliacao.Backend.Application.Commands.Users.UpdateUser;

public record UpdateUserCommand(int Id, string Name, string Email, bool IsActive) : IRequest<Unit>;
