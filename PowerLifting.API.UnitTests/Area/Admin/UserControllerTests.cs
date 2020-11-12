using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Areas.Admin;
using PowerLifting.API.Areas.Admin.Controllers;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.MediatR.Users.Querys.Admin;
using Xunit;
using MockFactory = PowerLifting.API.UnitTests.Util.MockFactory;

namespace PowerLifting.API.UnitTests.Area.Admin
{
    public class AccountControllerTests
    {
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IMediator> _mediator;

        private readonly Random _random;

        private readonly UserController _controller;

        public AccountControllerTests()
        {
            _random = new Random();
            _httpContextAccessor = new Mock<IHttpContextAccessor>(MockBehavior.Strict);
            _httpContextAccessor.Setup(a => a.HttpContext.User).Returns(new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "UserID"),
                new Claim("UserID", _random.Next().ToString())
            })));
            var httpContext = MockFactory.CreateNewHttpContext();
            _httpContextAccessor.Setup(x => x.HttpContext).Returns(httpContext);
            _mediator = new Mock<IMediator>(MockBehavior.Strict);
            _controller = new UserController(_mediator.Object, _httpContextAccessor.Object);
        }

        #region GetAllAdminUsers

        [Fact]
        public async Task GetAllAdminUsers_UsersAreReturned_ReturnsOk()
        {
            // Arrange
            _mediator.Setup(x => x.Send(It.IsAny<GetAllUsersByAdminQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new List<AdminUserDTO>());

            // Act
            var result = await _controller.GetAllAdminUsers();

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, viewResult.StatusCode);
        }

        #endregion


    }
}
