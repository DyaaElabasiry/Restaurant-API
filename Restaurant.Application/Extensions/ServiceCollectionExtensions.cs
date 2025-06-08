using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Restaurants.Application.Restaurants;
using Restaurants.Application.User;
using System.Text;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddScoped<IRestaurantsService, RestaurantsService>();
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
            services.AddLogging();
            services.AddScoped<IUserContext, UserContext>();
            services.AddHttpContextAccessor();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

        }
    }
}
