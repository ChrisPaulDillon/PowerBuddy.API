using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PowerBuddy.API.Areas.Public;
using PowerBuddy.API.Models;
using PowerBuddy.App.Queries.WorkoutDays;
using PowerBuddy.App.Services.Weights;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Models.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.Api.Area.Public
{
	public class WorkoutDayControllerTests
	{
		private readonly Mock<IMediator> _mediator;
		private readonly Mock<IWeightOutgoingConvertorService> _weightOutputService;

		private readonly WorkoutDayController _controller;

		public WorkoutDayControllerTests()
		{
			_mediator = new Mock<IMediator>(MockBehavior.Strict);
			_weightOutputService = new Mock<IWeightOutgoingConvertorService>(MockBehavior.Strict);
			_controller = new WorkoutDayController(_mediator.Object, _weightOutputService.Object);
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

		#region GetAllPublicWorkoutDayIds

		[Fact]
		public async Task GetWorkoutDayById_NoWorkoutFound_ReturnsNotFound()
		{
			// Arrange
			_mediator.Setup(x => x.Send(It.IsAny<GetWorkoutDayByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new WorkoutDayNotFound());

			// Act
			var result = await _controller.GetWorkoutDayById(0);

			// Assert
			var viewResult = Assert.IsType<NotFoundObjectResult>(result);
			Assert.Equal(StatusCodes.Status404NotFound, viewResult.StatusCode);
			Assert.IsType<Errors>(viewResult.Value);
		}

		[Fact]
		public async Task GetWorkoutDayById_WorkoutFound_ReturnsOk()
		{
			// Arrange
			_mediator.Setup(x => x.Send(It.IsAny<GetWorkoutDayByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new WorkoutDayDto());
			_weightOutputService.Setup(x => x.ConvertWorkoutExercises(It.IsAny<IEnumerable<WorkoutExerciseDto>>(), It.IsAny<string>(), It.IsAny<bool?>())).ReturnsAsync(new List<WorkoutExerciseDto>());

			// Act
			var result = await _controller.GetWorkoutDayById(0);

			// Assert
			var viewResult = Assert.IsType<OkObjectResult>(result);
			Assert.Equal(StatusCodes.Status200OK, viewResult.StatusCode);
			Assert.IsType<WorkoutDayDto>(viewResult.Value);
		}

		#endregion
	}
}
