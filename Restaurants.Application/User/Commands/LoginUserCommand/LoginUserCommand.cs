using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.User.Commands.LoginUserCommand
{
    public class LoginUserCommand : IRequest<String>
    {
        public string Email { get; set; }
        public string Password { get; set; }
       
    }
}
