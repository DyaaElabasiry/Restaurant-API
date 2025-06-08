using AutoMapper;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Restaurants.Application.Restaurants.Commands.CreateRestaurantCommand;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurantCommand.Tests
{
    public class CreateRestaurantCommandHandlerTests
    {
        [Fact()]
        public async Task HandleTest_ValidCommand_ReturnsCreatedRestaurantIdAsync()
        {
            var LoggerMock = new Mock<ILogger<CreateRestaurantCommandHandler>>();
            var MapperMock = new Mock<IMapper>();
            var restaurantRepositoryMock = new Mock<IRestaurantRepository>();

            var command = new CreateRestaurantCommand
            {
                Name = "Test Restaurant",
                Description = "Test Description",
                Category = "Italian",
                HasDelivery = true,
                ContactEmail = "test@test.com",
                ContactNumber = "123456789",
                City = "Test City",
                Street = "Test Street",
                PostalCode = "12-345"
            };

            var restaurant = new Restaurant
            {
                Id = 1,
                Name = command.Name,
                Description = command.Description,
                
            };

            MapperMock.Setup(m=>m.Map<Restaurant>(command)).Returns(restaurant);
            restaurantRepositoryMock.Setup(r => r.CreateAsync(restaurant)).ReturnsAsync(1);

            var handler = new CreateRestaurantCommandHandler(restaurantRepositoryMock.Object,MapperMock.Object,LoggerMock.Object);

            // act
            var result = await handler.Handle(command, CancellationToken.None);


            // assert

            result.Should().Be(1);



        }
    }
}