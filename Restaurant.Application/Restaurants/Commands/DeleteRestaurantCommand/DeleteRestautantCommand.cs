using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurantCommand
{
    public class DeleteRestautantCommand(int id) : IRequest<bool>
    {
        public int id { get; set; } = id;
    }
    
}
