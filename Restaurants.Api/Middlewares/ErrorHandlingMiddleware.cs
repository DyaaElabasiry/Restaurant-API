
using Restaurants.Application.Exceptions;

namespace Restaurants.Api.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                string responseMessage = "Internal Server Error. Please try again later.";
                if (e is NotFoundException)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    responseMessage = e.Message;
                }
                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = responseMessage
                };
                await context.Response.WriteAsJsonAsync(response);
                logger.LogError(e,"An unhandled exception occurred while processing the request.");
            }
           
        }
    }
}
