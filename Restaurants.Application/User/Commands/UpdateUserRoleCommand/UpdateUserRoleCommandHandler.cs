using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Application.Exceptions;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.User.Commands.UpdateUserRoleCommand
{
    public class UpdateUserRoleCommandHandler(UserManager<UserIdentity> userManager
        ,RoleManager<IdentityRole> roleManager
        ) : IRequestHandler<UpdateUserRoleCommand>
    {
        public async Task Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var role = await roleManager.FindByNameAsync(request.NewRole);
            if (role == null)
            {
                throw new NotFoundException("Role not found");
            }

            await userManager.AddToRoleAsync(user,  request.NewRole);
        }
    }
    
}
