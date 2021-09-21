using System;
using System.Linq;
using System.Security.Claims;

namespace Api.Rnc.Extensions
{
    public static class UserExtensirons
    {
        public static Guid GetUserId(this ClaimsPrincipal user) =>
            Guid.Parse(user.Claims.First(x => x.Type == "UserId").Value);

        public static string GetUserName(this ClaimsPrincipal user) =>
            user.Claims.First(x => x.Type == ClaimTypes.Name).Value;
    }
}
