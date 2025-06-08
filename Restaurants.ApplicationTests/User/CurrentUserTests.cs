using FluentAssertions;
using Restaurants.Domain.Constants;
using Xunit;

namespace Restaurants.Application.User.Tests
{
    public class CurrentUserTests
    {
        [Theory]
        [InlineData(UserRoles.Owner)]
        [InlineData(UserRoles.Admin)]
        public void IsInRole_WithMatchingRole_ShouldReturnTrue(string roleName)
        {
            //Arrange
            var user = new CurrentUser("1", "Dyaa@gmail.com", [UserRoles.Owner,UserRoles.Admin]);

            //Act
            var IsInRole = user.IsInRole(roleName);

            //Assert
            IsInRole.Should().BeTrue();
        }

        [Fact()]
        public void IsInRole_WithMatchingRole_ShouldReturnFalse()
        {
            //Arrange
            var user = new CurrentUser("1", "Dyaa@gmail.com", [UserRoles.Owner, UserRoles.Admin]);

            //Act
            var IsInRole = user.IsInRole(UserRoles.Admin.ToLower());

            //Assert
            IsInRole.Should().BeFalse();
        }
    }
}