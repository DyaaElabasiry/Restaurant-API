using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurantCommand;

public class CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository,IMapper mapper,ILogger<CreateRestaurantCommandHandler> logger) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating restaurant with name: {Name}", request.Name);
        var restaurant = mapper.Map<Restaurant>(request);
        int id = await restaurantRepository.CreateAsync(restaurant);
        return id;
    }
}
