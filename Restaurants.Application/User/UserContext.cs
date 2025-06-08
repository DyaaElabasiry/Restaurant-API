using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.User
{
    public interface IUserContext
    {
        CurrentUser GetCurrentUser();
    }

    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUser GetCurrentUser()
        {
            var user = httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("User Context is not present");
            }
            if (user.Identities == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }
            var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = user.FindFirst(ClaimTypes.Email)?.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            return new CurrentUser(id, email, roles);
        }
    }
}
