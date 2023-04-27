using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.ViewModels;
using Vectra.Avaliacao.Backend.Application.ViewModels.User;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

namespace Vectra.Avaliacao.Backend.Application.Queries.Users.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PaginationViewModel<List<UserViewModel>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<PaginationViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var count = await _userRepository.GetCountAsync();

        var users = await _userRepository.GetAllAsync(request.Page, request.PageSize);

        var list = users
            .Select(x => new UserViewModel(
                x.Id.ToString(),
                x.Name,
                x.Email.ToLower(),
                x.CreatedAt.ToString(),
                x.UpdatedAt.ToString(),
                x.IsActive.ToString()))
            .ToList();

        return new PaginationViewModel<List<UserViewModel>>
        {
            Total = count.ToString(),
            Page = request.Page.ToString(),
            PageSize = list.Count.ToString(),
            List = list
        };
    }
}
