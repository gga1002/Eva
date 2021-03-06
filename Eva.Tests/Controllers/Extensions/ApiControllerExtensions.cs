﻿using Moq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;

namespace Eva.Tests.Controllers.Extensions
{
    public static class ApiControllerExtensions
    {
        public static void MockCurrentUser(this ApiController controller, string userId, string username)
        {
            var claim = new Claim("test", userId);
            var mockIdentity =
                Mock.Of<ClaimsIdentity>(ci => ci.FindFirst(It.IsAny<string>()) == claim);
            controller.User = Mock.Of<IPrincipal>(ip => ip.Identity == mockIdentity);
        }
    }
}
