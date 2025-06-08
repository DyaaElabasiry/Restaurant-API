using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.User.Commands.UpdateUserRoleCommand
{
    public class UpdateUserRoleCommand : IRequest
    {
        public string Email { get; set; }
        
        public string NewRole { get; set; }
        
    }
}
