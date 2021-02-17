using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PowerBuddy.API.Areas.Public;
using PowerBuddy.App.Queries.WorkoutDays;
using Xunit;

namespace PowerBuddy.UnitTests.Api.Area.Public
{
	public class WorkoutDayControllerTests
	{
		private readonly Mock<IMediator> _mediator;

		private readonly WorkoutDayController _controller;

		public WorkoutDayControllerTests()
		{
			_mediator = new Mock<IMediator>(MockBehavior.Strict);
			_controller = new WorkoutDayController(_mediator.Object);
		}

        #region GetAllPublicWorkoutDayIds

        [Fact]
        public async Task GetAllPublicWorkoutDayIds_EmptyCollection_ReturnsOkResult()
        {
	        // Arrange
	        _mediator.Setup(x => x.Send(It.IsAny<GetAllPublicWorkoutDayIdsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new List<int>());

	        // Act
	        var result = await _controller.GetAllPublicWorkoutDayIds();

	        // Assert
	        var viewResult = Assert.IsType<OkObjectResult>(result);
	        Assert.Equal(StatusCodes.Status200OK, viewResult.StatusCode);
	        var list = Assert.IsType<List<int>>(viewResult.Value);
	        Assert.Empty(list);
        }

        #endregion
    }
}
