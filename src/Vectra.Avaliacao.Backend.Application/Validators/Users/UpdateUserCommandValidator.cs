using FluentValidation;
using Vectra.Avaliacao.Backend.Application.Commands.Users.UpdateUser;

namespace Vectra.Avaliacao.Backend.Application.Validators.Users;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(p => p.Id)
           .NotEmpty()
           .WithMessage("Id da conta é obrigatório.");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("O campo de nome é origatório");

        RuleFor(p => p.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email inválido ou não preenchido.");

        RuleFor(p => p.IsActive)
            .NotEmpty()
            .WithMessage("O status da usuário é obrigatório.");
    }
}
