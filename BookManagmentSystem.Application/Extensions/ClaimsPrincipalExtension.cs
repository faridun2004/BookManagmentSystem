using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static Guid GetCurrectUserId(this ClaimsPrincipal principal)
        {
            var role = principal?.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
            if (Guid.TryParse(role, out Guid userId))
                return userId;

            return Guid.Empty;
        }
    }
}
