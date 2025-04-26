using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs.Restaurants;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(IRestaurantRepository restaurantRepository,IMapper mapper,ILogger<GetRestaurantByIdQueryHandler> logger) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetRestaurantByIdQuery for restaurant with id {Id}", request.id);
        var restaurant = await restaurantRepository.GetByIdAsync(request.id);
        if (restaurant == null)
        {
            logger.LogWarning("Restaurant with id {Id} not found", request.id);
            return null;
        }
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto;
    }
}
