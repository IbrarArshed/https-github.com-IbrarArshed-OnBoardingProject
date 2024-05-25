using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pearl.SystemExtensions
{
    public static class HttpExtensions
    {
        public static string GetControllerName(this HttpContext httpContext) => httpContext?.Request?.RouteValues["controller"]!.ToString()!;

        public static string GetActionName(this HttpContext httpContext) => httpContext.Request?.RouteValues["action"]!.ToString()!;

        public static Guid GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            var value = httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(claim => string.Equals(claim.Type, JwtRegisteredClaimNames.Sid.ToString(), StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (Guid.TryParse(value, out Guid userId))
            {
                return userId;
            }

            return Guid.Empty;
        }

        public static IFormFileCollection GetImagePath(this HttpContext httpContext) => httpContext?.Request?.Form.Files!;
    }
}
