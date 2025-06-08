using Xunit;
using Restaurants.Application.DTOs.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Restaurants.Domain.Entities;
using FluentAssertions;

namespace Restaurants.Application.DTOs.Restaurants.Tests
{
    public class RestaurantProfileTests
    {
        [Fact()]
        public void CreateMap_FromRestaurantToRestaurantDto_MapsCorrectly()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<RestaurantProfile>());
            var mapper = config.CreateMapper();

            var restaurant = new Restaurant()
            {
                Id = 1,
                Description = "description",
                Category = "category",
                HasDelivery = true,
                Name = "name",
                ContactEmail = "email",
                Address = new Address()
                {
                    City = "Test city",
                    Street = "Test Street",
                    PostalCode = "12345",
                }
            };

            // Act
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            //Assert

            restaurantDto.Should().NotBeNull();
            restaurantDto.Id.Should().Be(1);
            restaurantDto.Description.Should().Be("description");
            restaurantDto.Category.Should().Be("category");
            restaurantDto.HasDelivery.Should().BeTrue();
            restaurantDto.Name.Should().Be("name");
            
                

        }
    }
}