using Microsoft.OpenApi.Models;
using Restaurants.Api.Middlewares;

namespace Restaurants.Api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentationBuilder(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
     
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurants API", Version = "v1" });
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearerAuth"
                            }
                        }, new string[] { } }
                });
            });
            // add Error handling middleware
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            // add authorization
            builder.Services.AddAuthentication();

        }
    }
}
