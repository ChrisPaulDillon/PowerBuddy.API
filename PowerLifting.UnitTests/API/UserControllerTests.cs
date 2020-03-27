using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Powerlifting.Services.ServiceWrappers;
using Powerlifting.Services.Users.DTO;
using Powerlifting.Services.Users.Model;
using PowerLifting.API.API;
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
            _controller = new UserController(_userService.Object, _logger.Object);

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
            _controller = new UserController(_userService.Object, _logger.Object);

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
            _controller = new UserController(_userService.Object, _logger.Object);

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
            _userService.Setup(x => x.User.GetUserById(It.IsAny<int>())).Throws(new Exception());
            _controller = new UserController(_userService.Object, _logger.Object);

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
            int userId = _rand.Next();

            _userService.Setup(x => x.User.GetUserById(It.IsAny<int>())).Returns(Task.FromResult<UserDTO>(null));
            _controller = new UserController(_userService.Object, _logger.Object);

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
            int userId = _rand.Next();
            user.UserId = userId;

            _userService.Setup(x => x.User.GetUserById(It.IsAny<int>())).Returns(Task.FromResult<UserDTO>(user));
            _controller = new UserController(_userService.Object, _logger.Object);

            //Act
            var result = await _controller.GetUser(userId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task CreateUser_ExceptionIsThrown_ReturnsInternalServerError()
        {
            _userService.Setup(x => x.User.GetUserByEmail(It.IsAny<string>())).Throws(new Exception());
            _controller = new UserController(_userService.Object, _logger.Object);

            //Act
            var result = await _controller.CreateUser(new UserDTO());
            var statusCodeResult = result as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task CreateUser_UserIsNull_ReturnsBadRequest()
        {
            //Arrange
            _controller = new UserController(_userService.Object, _logger.Object);

            //Act
            var result = await _controller.CreateUser(null);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task CreateUser_ModelStateIsInvalid_ReturnsInvalidModelState()
        {
            //Arrange
            _controller = new UserController(_userService.Object, _logger.Object);
            _controller.ModelState.AddModelError("key", "error message");

            //Act
            var result = await _controller.CreateUser(new UserDTO());

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

            _controller = new UserController(_userService.Object, _logger.Object);

            //Act
            var result = await _controller.CreateUser(new UserDTO());

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

            _controller = new UserController(_userService.Object, _logger.Object);

            //_userService.Verify(x => x.Save(), Times.AtMostOnce);
            //Act
            var result = await _controller.CreateUser(user);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        [Trait("UserController", "Unit")]
        public async Task Login_UserIsNull_ReturnNotFound()
        {
            //Arrange
            string username = "test";
            string password = "password";

            _userService.Setup(x => x.User.GetUserByEmail(It.IsAny<String>())).Returns(Task.FromResult<UserDTO>(null));
            _controller = new UserController(_userService.Object, _logger.Object);

            //Act
            var result = await _controller.Login(username, password);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        [Trait("UserController", "Unit")]
        public async Task Login_PasswordIsWrong_ReturnsUnauthorized()
        {
            //Arrange
            string username = "test";
            string password = "password";

            _userService.Setup(x => x.User.GetUserByEmail(It.IsAny<String>())).Returns(Task.FromResult<UserDTO>(null));

            _controller = new UserController(_userService.Object, _logger.Object);

            //Act
            var result = await _controller.Login(username, password);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
