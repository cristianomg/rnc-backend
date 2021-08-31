﻿using System;
using System.Linq;
using System.Security.Claims;

namespace Api.Rnc.Extensions
{
    public static class UserExtensirons
    {
        public static int GetUserId(this ClaimsPrincipal user) =>
            Convert.ToInt32(user.Claims.First(x => x.Type == "UserId").Value);

        public static string GetUserName(this ClaimsPrincipal user) =>
            user.Claims.First(x => x.Type == ClaimTypes.Name).Value;
    }
}
