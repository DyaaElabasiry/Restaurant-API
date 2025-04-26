using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantRepository(RestaurantsDbContext dbContext) : IRestaurantRepository
    {
        public async Task<int> CreateAsync(Restaurant restaurant)
        {
            dbContext.Add(restaurant);
            await dbContext.SaveChangesAsync();
            return restaurant.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var restaurant = await dbContext.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                // Optionally, throw an exception or handle the not-found case as needed.
                return false;
            }
            dbContext.Restaurants.Remove(restaurant);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            var restaurant  = await dbContext.Restaurants.Where(r=>r.Id == id).Include(r=>r.Dishes).FirstOrDefaultAsync();
            return restaurant;
        }

        public async Task<int> UpdateAsync(Restaurant restaurant)
        {
            dbContext.Update(restaurant);
            await dbContext.SaveChangesAsync();
            return restaurant.Id;
        }

        async Task<IEnumerable<Restaurant>> IRestaurantRepository.GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants.Include(r=>r.Dishes).ToListAsync();
            return restaurants;
        }
    }
}
