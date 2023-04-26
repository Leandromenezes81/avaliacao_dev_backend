using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain.Entities;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Services;
using Vectra.Avaliacao.Backend.Domain.Interfaces.UnitOfWork;

namespace Vectra.Avaliacao.Backend.Application.Commands.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, IUnitOfWork unitOfWork, IAuthService authService)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.GeneratePasswordHash(request.Password);

        var roles = new List<Role>();

        foreach (var role in request.RolesId)
        {
            var actualRole = await _roleRepository.GetByIdAsync(role);
            if (actualRole != null)
                roles.Add(actualRole);

        }

        var user = new User(
            request.Email,
            passwordHash,
            roles,
            DateTime.Now,
            DateTime.Now,
            true);

        await _userRepository.AddAsync(user);
        await _unitOfWork.Commit();

        return user.Id;
    }
}
