using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MongoData.Controllers;
using MongoData.Models.DTO;

namespace jwt.Middlewares.Classes
{
    public class IFKCustomAuthorization
    {
        private readonly RequestDelegate _next;
        private readonly AuthorizationController _authorizationController;

        public IFKCustomAuthorization(RequestDelegate next)
        {
            _authorizationController = new AuthorizationController();
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!String.IsNullOrEmpty(context.User.Identity.Name))
            {
                ClaimsPrincipal userClaims = context.User;

                Claim getHash_mongoDocumentId = userClaims.Claims.Where(r => r.Type == ClaimTypes.Hash).FirstOrDefault();

                if (getHash_mongoDocumentId != null)
                {
                    string mongoDocumentId = getHash_mongoDocumentId.Value;

                    AuthorizationDTO Authorization = _authorizationController.Read(mongoDocumentId);

                    if (Authorization != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, Authorization.Role)
                        };

                        ClaimsIdentity claimsIdentityRole = new ClaimsIdentity(claims);

                        userClaims.AddIdentity(claimsIdentityRole);
                    }
                }
            }

            await _next(context);
        }
    }
}
