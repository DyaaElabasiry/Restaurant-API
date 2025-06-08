using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Application.Exceptions;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.User.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler(IUserContext userContext,UserManager<UserIdentity> userManager) : IRequestHandler<UpdateUserCommand>
    {
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            
            var dbUser = await userManager.FindByIdAsync(user.Id);

            if (dbUser == null)
            {
                throw new NotFoundException("User not found");
            }

            dbUser.BirthDate = request.BirthDate;
            dbUser.Nationality = request.Nationality;

            var result = await userManager.UpdateAsync(dbUser);
        }
    }


}
