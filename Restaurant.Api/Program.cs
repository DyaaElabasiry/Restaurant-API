
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Application.Extensions;
using Restaurants.Api.Middlewares;
using Restaurants.Domain.Entities;
using Microsoft.OpenApi.Models;
using Restaurants.Api.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Restaurants
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();


            // register services from other layers
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.AddPresentationBuilder();


            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            //app.MapGroup("api/identity").MapIdentityApi<UserIdentity>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
