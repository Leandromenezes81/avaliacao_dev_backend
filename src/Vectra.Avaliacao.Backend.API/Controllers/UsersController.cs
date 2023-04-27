using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.Commands.Users.CreateUser;
using Vectra.Avaliacao.Backend.Application.Commands.Users.LoginUser;
using Vectra.Avaliacao.Backend.Application.ViewModels;

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
}
