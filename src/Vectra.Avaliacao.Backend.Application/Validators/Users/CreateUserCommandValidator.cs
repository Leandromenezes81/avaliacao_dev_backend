using FluentValidation;
using System.Text.RegularExpressions;
using Vectra.Avaliacao.Backend.Application.Commands.Users.CreateUser;

namespace Vectra.Avaliacao.Backend.Application.Validators.Users;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("O campo de nome é origatório");

        RuleFor(p => p.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email inválido ou não preenchido.");

        RuleFor(p => p.Password)
            .NotEmpty()
            .Must(ValidPassword)
            .WithMessage("Senha é obrigatória e deve conter 8 caracteres(mínimo um número, uma letra minúscula, uma letra maiúscula e uma caracter especial.");
    }

    public bool ValidPassword(string password) =>
        Regex.IsMatch(password,
                      @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%&+=]).*$");
}
