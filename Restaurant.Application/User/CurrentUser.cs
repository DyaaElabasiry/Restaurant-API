using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.User
{
    public class CurrentUser(string Id,string Email,IEnumerable<string> Roles)
    {
        public string Id { get; } = Id;
        public string Email { get; } = Email;
        public IEnumerable<string> Roles { get; } = Roles;
        public bool IsInRole(string role)=> Roles.Contains(role);
    }
    
    
}
