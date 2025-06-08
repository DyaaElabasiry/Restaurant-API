using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs.Restaurants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;


namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService : IRestaurantsService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILogger<RestaurantsService> _logger;
        private readonly IMapper _mapper;
        public RestaurantsService(IRestaurantRepository restaurantRepository,ILogger<RestaurantsService> logger,IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> CreateRestaurant(CreateRestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            int id = await _restaurantRepository.CreateAsync(restaurant);
            return id;
        }

        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAllAsync();
            var restaurantDtos = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return restaurantDtos;
        }

        public async Task<RestaurantDto> GetRestaurantById(int id)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null) {return null!; }
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return restaurantDto;
        }
    }
}
