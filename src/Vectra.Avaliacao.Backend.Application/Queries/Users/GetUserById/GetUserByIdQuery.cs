using MediatR;
using Vectra.Avaliacao.Backend.Application.ViewModels.User;

namespace Vectra.Avaliacao.Backend.Application.Queries.Users.GetUserById;

public record GetUserByIdQuery(int Id) : IRequest<UserViewModel>;
