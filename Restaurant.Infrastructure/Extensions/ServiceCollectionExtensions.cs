using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantsDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();
            services.AddIdentityApiEndpoints<UserIdentity>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<RestaurantsDbContext>();
        }
    }
}
