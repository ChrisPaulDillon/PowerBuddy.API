using Moq;
using PowerLifting.API.Areas.Account;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.Accounts.Service;
using PowerLifting.API.Areas.Admin.Controllers;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.Account;
using Xunit;

namespace PowerLifting.API.UnitTests.Area.Admin
{
    public class AccountControllerTests
    {
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IServiceWrapper> _serviceWrapper;

        private readonly Random _random;

        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _random = new Random();
            _httpContextAccessor = new Mock<IHttpContextAccessor>(MockBehavior.Strict);
            _httpContextAccessor.Setup(a => a.HttpContext.User).Returns(new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, _random.Next().ToString())
            })));

            _serviceWrapper = new Mock<IServiceWrapper>(MockBehavior.Strict);
            _controller = new AccountController(_serviceWrapper.Object, _httpContextAccessor.Object);
        }

        #region GetAllAdminUsers

        [Fact]
        public async Task GetAllAdminUsers_UsersAreReturned_ReturnsOk()
        {
            // Arrange
            _serviceWrapper.Setup(x => x.User.GetAllAdminUsers()).ReturnsAsync(new List<AdminUserDTO>());

            // Act
            var result = await _controller.GetAllAdminUsers();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        #endregion


    }
}
