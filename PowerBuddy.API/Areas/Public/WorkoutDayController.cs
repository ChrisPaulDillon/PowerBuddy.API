using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Models;
using PowerBuddy.App.Queries.WorkoutDays;
using PowerBuddy.App.Services.Weights;
using PowerBuddy.Data.Dtos.Users;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.API.Areas.Public
{
	[Route("api/[area]/[controller]")]
	[ApiController]
	[Produces("application/json")]
	[Area("Public")]
	public class WorkoutDayController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IWeightOutgoingConvertorService _weightOutputService;

		public WorkoutDayController(IMediator mediator, IWeightOutgoingConvertorService weightOutputService)
		{
			_mediator = mediator;
			_weightOutputService = weightOutputService;
		}

		[HttpGet("Id")]
		[ProducesResponseType(typeof(PublicUserDto), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAllPublicWorkoutDayIds()
		{
			var result = await _mediator.Send(new GetAllPublicWorkoutDayIdsQuery());
			return Ok(result);
		}

		[HttpGet("{workoutDayId:int}")]
		[ProducesResponseType(typeof(WorkoutDayDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetWorkoutDayById(int workoutDayId)
		{
			var workoutDayOneOf = await _mediator.Send(new GetWorkoutDayByIdQuery(workoutDayId));

			if (workoutDayOneOf.IsT0)
			{
				workoutDayOneOf.AsT0.WorkoutExercises = await _weightOutputService.ConvertWorkoutExercises(workoutDayOneOf.AsT0.WorkoutExercises, workoutDayOneOf.AsT0.UserId);
			}

			return workoutDayOneOf.Match<IActionResult>(
				Result => Ok(Result),
				WorkoutDayNotFound => NotFound(Errors.Create(nameof(WorkoutDayNotFound))));
		}
	}
}
