using FluentValidation;
using Vectra.Avaliacao.Backend.Application.Commands.Accounts.UpdateAccount;

namespace Vectra.Avaliacao.Backend.Application.Validators.Accounts;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(p => p.Id)
           .NotEmpty()
           .WithMessage("Id da conta é obrigatório.");

        RuleFor(p => p.Branch)
            .NotEmpty()
            .WithMessage("O número da agência é obrigatório.");

        RuleFor(p => p.Number)
            .NotEmpty()
            .WithMessage("O número da conta é obrigatório.");

        RuleFor(p => p.Balance)
            .NotEmpty()
            .WithMessage("O saldo inicial é obrigatório.");

        RuleFor(p => p.IsActive)
            .NotEmpty()
            .WithMessage("O status da conta é obrigatório.");
    }
}
