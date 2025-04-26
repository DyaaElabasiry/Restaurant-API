

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;

namespace Restaurants.Api.Controllers
{
    [ApiController]
    [Route("api/Restaurants/{RestaurantId}/Dishes")]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int RestaurantId, [FromBody] CreateDishCommand command)
        {
            command.RestaurantId = RestaurantId;
            var result = await mediator.Send(command);
            return Created();
        }
    }
}
