using MediatR;
using System.Collections.Generic;
using Vectra.Avaliacao.Backend.Application.ViewModels;
using Vectra.Avaliacao.Backend.Application.ViewModels.User;

namespace Vectra.Avaliacao.Backend.Application.Queries.Users.GetAllUsers;

public record GetAllUsersQuery(int Page, int PageSize) : IRequest<PaginationViewModel<List<UserViewModel>>>;
