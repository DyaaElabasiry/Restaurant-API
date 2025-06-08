using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.User.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest
    {
        public string Nationality { get; set; } 
        public DateTime BirthDate { get; set; }
    }
}
