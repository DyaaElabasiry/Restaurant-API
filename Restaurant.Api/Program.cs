
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Application.Extensions;
using Restaurants.Api.Middlewares;

namespace Restaurants
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSwaggerGen();

            // add Error handling middleware
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            

            // Register DbContext
            builder.Services.AddInfrastructureServices();
            builder.Services.AddApplicationServices();

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

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
