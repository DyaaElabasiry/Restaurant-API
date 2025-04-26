using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurantCommand
{
    public class UpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository,IMapper mapper,ILogger<UpdateRestaurantCommandHandler> logger) : IRequestHandler<UpdateRestaurantCommand, int>
    {
        public async Task<int> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling UpdateRestaurantCommand for restaurant with ID {Id}", request.Id);
            var restaurant = mapper.Map<Restaurant>(request);
            await restaurantRepository.UpdateAsync(restaurant);
            return restaurant.Id;
        }
    }
}
