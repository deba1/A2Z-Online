using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Application.Extensions
{
    public static class UserDetailsHttpContextExtension
    {
        public static int GetUserId(this HttpContext httpContext)
        {
            try
            {
                return (httpContext.User != null) ? Convert.ToInt32(httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value) : -1;
            }
            catch(NullReferenceException)
            {
                return -1;
            }
        }
    }
}
