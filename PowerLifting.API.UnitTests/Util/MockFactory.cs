using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Moq;

namespace PowerLifting.API.UnitTests.Util
{
    public static class MockFactory
    {
        public static Mock<IHttpContextAccessor> CreateAccessor()
        {
            var _httpContextAccessor = new Mock<IHttpContextAccessor>(MockBehavior.Strict);
            _httpContextAccessor.Setup(a => a.HttpContext.User).Returns(new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            })));
            return _httpContextAccessor;
        }

        public static DefaultHttpContext CreateNewHttpContext()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers.Add("Content-Type", "application/json");
            httpContext.Request.Scheme = "https";
            httpContext.Request.Host = new HostString("someurl.com");
            httpContext.Request.Path = "/api/test";
            return httpContext;
        }
    }
}
