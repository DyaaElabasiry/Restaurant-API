using Xunit;
using Restaurants.Application.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moq;
using Restaurants.Domain.Constants;
using System.Security.Claims;
using FluentAssertions;

namespace Restaurants.Application.User.Tests
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            // Arrange
            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "dyaa@gmail.com"),
                new Claim(ClaimTypes.Role, UserRoles.Owner),
            };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "TestAuthType"));

            httpContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext { User = user });
            var userContext = new UserContext(httpContextAccessor.Object);

            // Act
            var currentUser = userContext.GetCurrentUser();

            // Assert
            currentUser.Should().NotBeNull();
            currentUser.Id.Should().Be("1");
            currentUser.Email.Should().Be("dyaa@gmail.com");
            currentUser.Roles.Should().Contain(UserRoles.Owner);

        }

        [Fact()]
        public void GetCurrentUser_WithUserContextNotPresent_ShouldReturnInvalidOperationException()
        {
            // Arrange
            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            

            httpContextAccessor.Setup(x => x.HttpContext).Returns((HttpContext)null);
            var userContext = new UserContext(httpContextAccessor.Object);

            // Act
            var currentUser = ()=> userContext.GetCurrentUser();

            // Assert
            currentUser.Should().Throw<InvalidOperationException>()
                .WithMessage("User Context is not present");

        }
    }
}