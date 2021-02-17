using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.App.Queries.WorkoutDays;
using PowerBuddy.Data.Dtos.Users;

namespace PowerBuddy.API.Areas.Public
{
	[Route("api/[area]/[controller]")]
	[ApiController]
	[Produces("application/json")]
	[Area("Public")]
	public class WorkoutDayController : ControllerBase
	{
		private readonly IMediator _mediator;

		public WorkoutDayController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("Id")]
		[ProducesResponseType(typeof(PublicUserDto), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAllPublicWorkoutDayIds()
		{
			var result = await _mediator.Send(new GetAllPublicWorkoutDayIdsQuery());
			return Ok(result);
		}
	}
}
