using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.WorkoutSets;
using PowerBuddy.App.Services.Weights;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [Area("Account")]
    public class WorkoutSetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWeightInsertConvertorService _weightInsertService;
        private readonly IWeightOutgoingConvertorService _weightOutputService;
        private readonly string _userId;

        public WorkoutSetController(IMediator mediator, IWeightInsertConvertorService weightInsertService, IWeightOutgoingConvertorService weightOutgoingService, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _weightInsertService = weightInsertService;
            _weightOutputService = weightOutgoingService;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost("Collection")]
        [ProducesResponseType(typeof(IEnumerable<WorkoutSetDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWorkoutSetCollection([FromBody] IList<WorkoutSetDto> workoutSetCollection)
        {
            var convertWorkoutCollection = await _weightInsertService.ConvertWeightSetsToDbSuitable(_userId, workoutSetCollection);
            var result = await _mediator.Send(new QuickAddWorkoutSetsCommand(convertWorkoutCollection.Data.ToList(), _userId));

            return result.Match<IActionResult>(
                Result => Ok(_weightOutputService.ConvertWorkoutSets(result.AsT0, _userId, convertWorkoutCollection.IsMetric).Result),
                WorkoutExerciseNotFound => NotFound(Errors.Create(nameof(WorkoutExerciseNotFound))),
                WorkoutDayNotFound => NotFound(Errors.Create(nameof(WorkoutDayNotFound))));
        }

        [HttpPut("{workoutDayId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateWorkoutSet(int workoutDayId, [FromBody] WorkoutSetDto workoutSetDto)
        {
            var convertedWorkoutSet = await _weightInsertService.ConvertWeightSetToDbSuitable(_userId, workoutSetDto);
            var result = await _mediator.Send(new UpdateWorkoutSetCommand(workoutDayId, convertedWorkoutSet.Data, _userId));
            return Ok(result);
        }

        [HttpDelete("{workoutSetId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteWorkoutSet(int workoutSetId)
        {
            var result = await _mediator.Send(new DeleteWorkoutSetCommand(workoutSetId, _userId));
            return Ok(result);
        }
    }
}
