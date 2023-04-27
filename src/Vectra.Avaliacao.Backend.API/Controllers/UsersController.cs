using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.Commands.Users.CreateUser;
using Vectra.Avaliacao.Backend.Application.Commands.Users.DeleteUser;
using Vectra.Avaliacao.Backend.Application.Commands.Users.LoginUser;
using Vectra.Avaliacao.Backend.Application.Commands.Users.UpdateUser;
using Vectra.Avaliacao.Backend.Application.Queries.Users.GetAllUsers;
using Vectra.Avaliacao.Backend.Application.Queries.Users.GetUserById;
using Vectra.Avaliacao.Backend.Application.Queries.Users.GetUserByName;
using Vectra.Avaliacao.Backend.Application.ViewModels;
using Vectra.Avaliacao.Backend.Application.ViewModels.User;

namespace Vectra.Avaliacao.Backend.API.Controllers;

[ApiController]
[Route("v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IMediator mediator, ILogger<UsersController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{page:int}/{pageSize:int}")]
    [Authorize(Roles = "Admin, Client")]
    public async Task<IActionResult> GetAll(
        [FromRoute] int page,
        [FromRoute] int pageSize)
    {
        var query = new GetAllUsersQuery(page, pageSize);

        try
        {
            var accounts = await _mediator.Send(query);
            return Ok(new ResultViewModel<PaginationViewModel<List<UserViewModel>>>(accounts));
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<UserViewModel>("Internal Server Error."));
        }
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var query = new GetUserByIdQuery(id);

        try
        {
            var user = await _mediator.Send(query);

            if (user == null)
                return NotFound(new ResultViewModel<UserViewModel>("User not found."));

            return Ok(new ResultViewModel<UserViewModel>(user));
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<UserViewModel>("Internal Server Error."));
        }
    }

    [HttpGet("{name}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByName([FromRoute] string name)
    {
        var query = new GetUserByNameQuery(name);

        try
        {
            var user = await _mediator.Send(query);

            if (user == null)
                return NotFound(new ResultViewModel<UserViewModel>("User not found."));

            return Ok(new ResultViewModel<UserViewModel>(user));
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<UserViewModel>("Internal Server Error."));
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        try
        {
            var idUser = await _mediator.Send(command);
            return Ok(new ResultViewModel<dynamic>(new
            {
                idUser
            }));
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(400, new ResultViewModel<string>("User alredy exists."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Internal Server Error."));
        }
    }

    [HttpPut("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand login)
    {
        try
        {
            var token = await _mediator.Send(login);

            if (token == string.Empty)
                return StatusCode(401, new ResultViewModel<string>("User or password is not valid."));

            return Ok(new ResultViewModel<dynamic>(new
            {
                token
            }));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Internal Server Error."));
        }
    }

    [HttpPut]
    [AllowAnonymous]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
    {
        try
        {
            await _mediator.Send(command);

            return NoContent();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<UserViewModel>("Could not update user."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<UserViewModel>("Internal Server Error."));
        }
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand(id);

        try
        {
            await _mediator.Send(command);
            return NoContent();

        }
        catch (DbUpdateException ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<UserViewModel>("Could not delete user."));
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has occurred: {ex.Message}");
            return StatusCode(500, new ResultViewModel<UserViewModel>("Internal Server Error."));
        }
    }
}
