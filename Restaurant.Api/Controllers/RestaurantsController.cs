using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.DTOs.Restaurants;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurantCommand;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurantCommand;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurantCommand;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Constants;
using System.Security.Claims;

namespace Restaurants.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController(IRestaurantsService restaurantsService,IMediator mediator) : ControllerBase
    {
        
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetRestaurants()
        {
            
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());

            return Ok(restaurants);
        }
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles =UserRoles.Owner+","+UserRoles.Admin)]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            if (command == null)
            {
                return BadRequest("Restaurant data is null");
            }
            var id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, command);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRestaurant([FromBody] UpdateRestaurantCommand command)
        {
            if (command == null)
            {
                return BadRequest("Restaurant data is null");
            }
            await mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            bool isDeleted = await mediator.Send(new DeleteRestautantCommand(id));
            if (isDeleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
