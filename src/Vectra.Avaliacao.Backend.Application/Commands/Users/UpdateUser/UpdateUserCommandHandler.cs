using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;
using Vectra.Avaliacao.Backend.Domain.Interfaces.UnitOfWork;

namespace Vectra.Avaliacao.Backend.Application.Commands.Users.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user == null)
            return default;

        user.Name = request.Name;
        user.Email = request.Email;
        user.UpdatedAt = DateTime.Now;
        user.IsActive = request.IsActive;

        _userRepository.Update(user);
        await _unitOfWork.Commit();

        return Unit.Value;
    }
}
