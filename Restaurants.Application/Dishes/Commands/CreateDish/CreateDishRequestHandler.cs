

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Exceptions;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishRequestHandler(IDishesRepository dishesRepository,
        IRestaurantRepository restaurantsRepository,
        IMapper mapper,
        ILogger<CreateDishRequestHandler> logger) : IRequestHandler<CreateDishCommand, int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant is null)
            {
                logger.LogWarning("Restaurant with id {RestaurantId} not found", request.RestaurantId);
                throw new NotFoundException($"Restaurant with id {request.RestaurantId} not found");
            }
            var dish = mapper.Map<Dish>(request);
            await dishesRepository.Create(dish);
            return dish.Id;
        }
    }
}
