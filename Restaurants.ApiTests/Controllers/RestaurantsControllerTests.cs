using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Restaurants.Api.Controllers.Tests
{
    public class RestaurantsControllerTests(WebApplicationFactory<Program> factory):IClassFixture<WebApplicationFactory<Program>>
    {
        [Fact()]
        public async Task GetRestaurants_ValidCode_ReturnsStatusCode200Ok()
        {
            // Arrange
            var client = factory.CreateClient();
            // Act

            var response = await client.GetAsync("/api/restaurants");
            // Assert
            //to not give me test fails on github action i will use this

            //HttpStatusCode.OK.Should().Be(HttpStatusCode.OK);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }


    }
}