using MediatR;
using System;
using Vectra.Avaliacao.Backend.Application.ViewModels;

namespace Vectra.Avaliacao.Backend.Application.Commands.Accounts.CreateAccount;

public record CreateAccountCommand(int UserId, string Branch, string Number, decimal Balance) : IRequest<Unit>;

