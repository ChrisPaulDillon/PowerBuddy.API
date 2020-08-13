using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PowerLifting.API.Areas.Admin.Controllers;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PowerLifting.API.UnitTests.Area.Admin
{
    public class ExerciseControllerUnitTests
    {
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IServiceWrapper> _serviceWrapper;

        private readonly Random _random;

        private readonly ExerciseController _controller;

        public ExerciseControllerUnitTests()
        {
            _random = new Random();
            _httpContextAccessor = new Mock<IHttpContextAccessor>(MockBehavior.Strict);
            _httpContextAccessor.Setup(a => a.HttpContext.User).Returns(new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, _random.Next().ToString())
            })));

            _serviceWrapper = new Mock<IServiceWrapper>(MockBehavior.Strict);
            _controller = new ExerciseController(_serviceWrapper.Object, _httpContextAccessor.Object);
        }

        //#region ApproveExercise

        //[Fact]
        //public async Task ApproveExercise_ThrowsExerciseValidationException_ReturnsBadRequest()
        //{
        //    // Arrange
        //    _serviceWrapper.Setup(x => x.Exercise.ApproveExercise(It.IsAny<int>(), It.IsAny<string>())).ThrowsAsync(new ExerciseValidationException());

        //    // Act
        //    var result = await _controller.ApproveExercise(555);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}

        //[Fact]
        //public async Task ApproveExercise_ThrowsUserValidationException_ReturnsBadRequest()
        //{
        //    // Arrange
        //    _serviceWrapper.Setup(x => x.Exercise.ApproveExercise(It.IsAny<int>(), It.IsAny<string>())).ThrowsAsync(new UserValidationException());

        //    // Act
        //    var result = await _controller.ApproveExercise(555);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}

        //[Fact]
        //public async Task ApproveExercise_ThrowsExerciseNotFoundException_ReturnsNotFound()
        //{
        //    // Arrange
        //    _serviceWrapper.Setup(x => x.Exercise.ApproveExercise(It.IsAny<int>(), It.IsAny<string>())).ThrowsAsync(new ExerciseNotFoundException());

        //    // Act
        //    var result = await _controller.ApproveExercise(555);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsType<NotFoundObjectResult>(result);
        //}

        //[Fact]
        //public async Task ApproveExercise_ThrowsUserNotFoundException_ReturnsNotFound()
        //{
        //    // Arrange
        //    _serviceWrapper.Setup(x => x.Exercise.ApproveExercise(It.IsAny<int>(), It.IsAny<string>())).ThrowsAsync(new UserNotFoundException());

        //    // Act
        //    var result = await _controller.ApproveExercise(555);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsType<NotFoundObjectResult>(result);
        //}

        //[Fact]
        //public async Task ApproveExercise_ExerciseIsApproved_ReturnsOk()
        //{
        //    // Arrange
        //    _serviceWrapper.Setup(x => x.Exercise.ApproveExercise(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(true);

        //    // Act
        //    var result = await _controller.ApproveExercise(555);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsType<OkObjectResult>(result);
        //}

        //#endregion
    }
}
