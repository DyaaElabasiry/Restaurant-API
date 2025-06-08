using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Restaurants.Domain.Entities
{
    public class UserIdentity : IdentityUser
    {
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
