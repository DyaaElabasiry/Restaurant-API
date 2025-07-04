﻿using Restaurants.Application.DTOs.Restaurants;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
        Task<RestaurantDto> GetRestaurantById(int id);
        Task<int> CreateRestaurant(CreateRestaurantDto restaurantDto);
    }
}