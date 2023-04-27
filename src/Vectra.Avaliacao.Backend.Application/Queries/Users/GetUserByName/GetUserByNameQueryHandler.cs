using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.ViewModels.User;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;

namespace Vectra.Avaliacao.Backend.Application.Queries.Users.GetUserByName;

public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, UserViewModel>
{
    private readonly IUserRepository _userRepository;

    public GetUserByNameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserViewModel> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByNameAsync(request.Name);

        if (user == null)
            return default;

        return new UserViewModel(
            user.Id.ToString(),
            user.Name,
            user.Email,
            user.CreatedAt.ToString(),
            user.UpdatedAt.ToString(),
            user.IsActive.ToString());
    }
}
