using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace jwt.Middlewares.Classes
{
    public class IFKCustomAuthorization
    {
        private readonly RequestDelegate _next;

        public IFKCustomAuthorization(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!String.IsNullOrEmpty(context.User.Identity.Name))
            {
                ClaimsPrincipal userClaims = context.User;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Usuario")
                };

                ClaimsIdentity claimsIdentityRole = new ClaimsIdentity(claims);

                userClaims.AddIdentity(claimsIdentityRole);
            }

            await _next(context);
        }
    }
}
