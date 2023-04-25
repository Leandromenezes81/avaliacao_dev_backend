using MediatR;
using System;
using System.Collections.Generic;

namespace Vectra.Avaliacao.Backend.Application.Commands.Users.CreateUser;

public class CreateUserCommand : IRequest<int>
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
    public List<int> RolesId { get; set; }
}
