using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.Commands.Users.CreateUser;
using Vectra.Avaliacao.Backend.Application.Commands.Users.LoginUser;

namespace Vectra.Avaliacao.Backend.API.Controllers;

[ApiController]
[Route("v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command) => 
        Ok(new { idUser = await _mediator.Send(command) });

    [HttpPut("login")]
    [AllowAnonymous]

    public async Task<IActionResult> Login([FromBody] LoginUserCommand login) => 
        Ok(new { token = await _mediator.Send(login) });
}
