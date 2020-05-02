using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PowerLifting.API.API;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Model;
using Xunit;

namespace PowerLifting.UnitTests.API
{
    public class UserControllerTests
    {
        private readonly Mock<ILogger<UserController>> _logger;
        private readonly Mock<IServiceWrapper> _userService;

        private readonly Random _rand;

        private UserController _controller;

        public UserControllerTests()
        {
            _logger = new Mock<ILogger<UserController>>();
            _userService = new Mock<IServiceWrapper>(MockBehavior.Strict);
            _rand = new Random();
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task GetAllUsers_ExceptionIsThrown_ReturnsInternalServerError()
        {
            //Arrange
            var userList = new List<User>();
            //userList.Add(new User());

            _userService.Setup(x => x.User.GetAllUsers()).Throws(new Exception());
            _controller = new UserController(_userService.Object);

            //Act
            var result = await _controller.GetAllUsers();
            var statusCodeResult = result as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task GetAllUsers_NoUsersFound_ReturnsNotFound()
        {
            _userService.Setup(x => x.User.GetAllUsers()).Returns(Task.FromResult<IEnumerable<UserDTO>>(null));
            _controller = new UserController(_userService.Object);

            //Act
            var result = await _controller.GetAllUsers();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task GetAllUsers_UsersAreFound_ReturnsOK()
        {
            //Arrange
            var userList = new List<UserDTO>();
            userList.Add(new UserDTO());

            _userService.Setup(x => x.User.GetAllUsers()).Returns(Task.FromResult<IEnumerable<UserDTO>>(userList));
            _controller = new UserController(_userService.Object);

            //Act
            var result = await _controller.GetAllUsers();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task GetUserById_ExceptionIsThrown_ReturnsInternalServerError()
        {
            _userService.Setup(x => x.User.GetUserById(It.IsAny<string>())).Throws(new Exception());
            _controller = new UserController(_userService.Object);

            //Act
            var result = await _controller.GetAllUsers();
            var statusCodeResult = result as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task GetUserbyId_NoUsersFound_ReturnsNotFound()
        {
            //Arrange
            string userId = Guid.NewGuid().ToString();

            _userService.Setup(x => x.User.GetUserById(It.IsAny<string>())).Returns(Task.FromResult<UserDTO>(null));
            _controller = new UserController(_userService.Object);

            //Act
            var result = await _controller.GetUser(userId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task GetUserById_UserIsFound_ReturnsOK()
        {
            //Arrange
            var user = new UserDTO();
            string userId = Guid.NewGuid().ToString();
            user.Id = userId;

            _userService.Setup(x => x.User.GetUserById(It.IsAny<string>())).Returns(Task.FromResult<UserDTO>(user));
            _controller = new UserController(_userService.Object);

            //Act
            var result = await _controller.GetUser(userId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task CreateUser_UserIsNull_ReturnsBadRequest()
        {
            //Arrange
            _controller = new UserController(_userService.Object);

            //Act
            //var result = await _controller.CreateUser(null);
            var result = "";
            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task CreateUser_ModelStateIsInvalid_ReturnsInvalidModelState()
        {
            //Arrange
            _controller = new UserController(_userService.Object);
            _controller.ModelState.AddModelError("key", "error message");

            //Act
            //var result = await _controller.CreateUser(new UserDTO());
            var result = "";
            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task CreateUser_EmailIsTaken_ReturnsConflict()
        {
            //Arrange
            var user = new UserDTO();
            int userId = _rand.Next();
            user.UserId = userId;

            _userService.Setup(x => x.User.GetUserByEmail(It.IsAny<string>())).Returns(Task.FromResult<UserDTO>(user));

            _controller = new UserController(_userService.Object);

            //Act
            //var result = await _controller.CreateUser(new UserDTO());
            var result = "";
            //Assert
            Assert.NotNull(result);
            Assert.IsType<ConflictObjectResult>(result);
        }
 
        [Fact]
        [Trait("UserController", "Unit")]
        public async Task CreateUser_UserIsAvailable_ReturnsCreatedAtRoute()
        {
            //Arrange
            var user = new UserDTO();
            int userId = _rand.Next();
            user.UserId = userId;
            user.Password = "test";

            _userService.Setup(x => x.User.GetUserByEmail(It.IsAny<string>())).Returns(Task.FromResult<UserDTO>(null));
            //_userService.Setup(x => x.User.AddAsync(It.IsAny<User>())).Returns(Task.FromResult<UserDTO>(user));

            _controller = new UserController(_userService.Object);

            //_userService.Verify(x => x.Save(), Times.AtMostOnce);
            //Act
           // var result = await _controller.CreateUser(user);
            var result = "";
            //Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtRouteResult>(result);
        }
    }
}
