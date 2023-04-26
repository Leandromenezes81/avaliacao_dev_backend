using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.Commands.Accounts.CreateAccount;
using Vectra.Avaliacao.Backend.Application.Commands.Accounts.DeleteAccount;
using Vectra.Avaliacao.Backend.Application.Commands.Accounts.UpdateAccount;
using Vectra.Avaliacao.Backend.Application.Queries.Accounts.GetAccountById;
using Vectra.Avaliacao.Backend.Application.Queries.Accounts.GettAllAccounts;

namespace Vectra.Avaliacao.Backend.API.Controllers;

[ApiController]
[Route("v1/accounts")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{page:int}/{pageSize:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll(
        [FromRoute] int page,
        [FromRoute] int pageSize)
    {
        var query = new GetAllAccountsQuery(page, pageSize);

        var accounts = await _mediator.Send(query);

        return Ok(accounts);
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var query = new GetAccountByIdQuery(id);
        
        var account = await _mediator.Send(query);

        return Ok(account);
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateAccountCommand command)
    {        
        var account = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new {account}, command);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] UpdateAccountCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteAccountCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}
