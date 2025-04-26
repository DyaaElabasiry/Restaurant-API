using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurantCommand;

public class DeleteRestaurantCommandHandler(IRestaurantRepository restaurantRepository, IMapper mapper, ILogger<DeleteRestaurantCommandHandler> logger) : IRequestHandler<DeleteRestautantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestautantCommand request, CancellationToken cancellationToken)
    {
        bool isDeleted =  await restaurantRepository.Delete(request.id);
        if (isDeleted)
        {
            logger.LogInformation($"Restaurant with ID {request.id} deleted successfully.");
        }
        else
        {
            logger.LogWarning($"Restaurant with ID {request.id} not found.");
        }
        return isDeleted;
    }
}
