using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.Commands.Accounts.CreateAccount;
using Vectra.Avaliacao.Backend.Application.Commands.Accounts.DeleteAccount;
using Vectra.Avaliacao.Backend.Application.Commands.Accounts.UpdateAccount;
using Vectra.Avaliacao.Backend.Application.Queries.Accounts.GetAccountById;
using Vectra.Avaliacao.Backend.Application.Queries.Accounts.GettAllAccounts;
using Vectra.Avaliacao.Backend.Application.ViewModels;
using Vectra.Avaliacao.Backend.Application.ViewModels.Account;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.API.Controllers;

[ApiController]
[Route("v1/accounts")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AccountController> _logger;    

    public AccountController(IMediator mediator, ILogger<AccountController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{page:int}/{pageSize:int}")]
    //[Authorize(Roles = "Admin, Client")]
    public async Task<IActionResult> GetAll(
        [FromRoute] int page,
        [FromRoute] int pageSize)
    {
        var query = new GetAllAccountsQuery(page, pageSize);

        try
        {
            var accounts = await _mediator.Send(query);
            return Ok(new ResultViewModel<PaginationViewModel<List<AccountViewModel>>>(accounts));
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<AccountViewModel>("Internal Server Error."));
        }
    }

    [HttpGet("{id:int}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var query = new GetAccountByIdQuery(id);

        try
        {
            var account = await _mediator.Send(query);

            if (account == null)
                return NotFound(new ResultViewModel<AccountViewModel>("Account not found."));

            return Ok(new ResultViewModel<AccountViewModel>(account));
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<AccountViewModel>("Internal Server Error."));
        }
    }


    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateAccountCommand command)
    {
        try
        {
            var account = await _mediator.Send(command);
            return Ok(new ResultViewModel<dynamic>(new
            {
                account
            }));

        }
        catch (DbUpdateException ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(400, new ResultViewModel<string>("Account alredy exists."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<AccountViewModel>("Internal Server Error."));
        }
    }

    [HttpPut]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] UpdateAccountCommand command)
    {
        try
        {
            await _mediator.Send(command);

            return NoContent();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<AccountViewModel>("Could not update account."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<AccountViewModel>("Internal Server Error."));
        }

    }

    [HttpDelete("{id:int}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var command = new DeleteAccountCommand(id);

        try
        {
            await _mediator.Send(command);
            return NoContent();

        }
        catch (DbUpdateException ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<AccountViewModel>("Could not delete account."));
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<AccountViewModel>("Internal Server Error."));
        }

    }
}
