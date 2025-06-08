using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.User.Commands.LoginUserCommand;
using Restaurants.Application.User.Commands.UpdateUserCommand;
using Restaurants.Application.User.Commands.UpdateUserRoleCommand;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using System.Security.Claims;


namespace Restaurants.Api.Controllers
{
    [ApiController]
    [Route("api/Identity")]
    public class IdentityController(IMediator mediator,RoleManager<IdentityRole> roleManager) : ControllerBase
    {
        [HttpPatch("user")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPost("userRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleCommand updateUserRoleCommand)
        {
            await mediator.Send(updateUserRoleCommand);
            
            return NoContent();
        }

        [HttpPost("loginUser")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var token = await mediator.Send(command);
            return Ok(new { token });
        }



    }
}
