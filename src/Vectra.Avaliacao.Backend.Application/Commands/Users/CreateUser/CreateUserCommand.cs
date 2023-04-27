using MediatR;
using System.Collections.Generic;

namespace Vectra.Avaliacao.Backend.Application.Commands.Users.CreateUser;

public record CreateUserCommand(string Email, string Password, List<int> RolesId) : IRequest<string>;

