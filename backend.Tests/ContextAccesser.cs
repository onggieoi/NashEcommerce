using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace backend.Tests
{
    public static class ContextAccesser
    {
        public static IHttpContextAccessor mockHttpAccessor(string userId)
        {
            var mockContextAccessor = new Mock<IHttpContextAccessor>();

            mockContextAccessor
                .Setup(context =>
                    context.HttpContext.User.FindFirst(It.IsAny<string>()))
                .Returns(new Claim("sub", userId));

            return mockContextAccessor.Object;
        }
    }
}