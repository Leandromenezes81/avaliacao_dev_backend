using FluentValidation;
using Vectra.Avaliacao.Backend.Application.Commands.Accounts.CreateAccount;

namespace Vectra.Avaliacao.Backend.Application.Validators.Accounts;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty()
            .WithMessage("Id do cliente é obrigatório.");

        RuleFor(p => p.Branch)
            .NotEmpty()
            .WithMessage("O número da agência é obrigatório.");

        RuleFor(p => p.Number)
            .NotEmpty()
            .WithMessage("O número da conta é obrigatório.");

        RuleFor(p => p.Balance)
            .NotEmpty()
            .WithMessage("O saldo inicial é obrigatório.");
    }
}
