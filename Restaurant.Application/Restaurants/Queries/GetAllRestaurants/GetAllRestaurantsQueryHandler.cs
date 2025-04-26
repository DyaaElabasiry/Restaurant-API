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

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(IRestaurantRepository restaurantRepository, IMapper mapper, ILogger<GetAllRestaurantsQueryHandler> logger) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
       
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetAllRestaurantsQuery");
            var restaurants = await restaurantRepository.GetAllAsync();
            var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantDtos;
        }
    }
}
