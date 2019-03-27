using Microsoft.AspNetCore.Builder;
using jwt.Middlewares.Classes;

namespace jwt.Middlewares.Extensions
{
    public static class IFKCustomAuthorizationExtension
    {
        public static IApplicationBuilder UseRequestIFKCustomAuthorization(this 
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IFKCustomAuthorization>();
        }
    }
}
