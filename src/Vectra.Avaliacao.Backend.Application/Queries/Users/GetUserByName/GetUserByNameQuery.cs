using MediatR;
using Vectra.Avaliacao.Backend.Application.ViewModels.User;

namespace Vectra.Avaliacao.Backend.Application.Queries.Users.GetUserByName;

public record GetUserByNameQuery(string Name) : IRequest<UserViewModel>;
