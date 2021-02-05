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
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Exceptions.Workouts;

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
        [ProducesResponseType(typeof(IEnumerable<WorkoutSetDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWorkoutSetCollection([FromBody] IList<WorkoutSetDTO> workoutSetCollection)
        {
            try
            {
                var convertWorkoutCollection = await _weightInsertService.ConvertWeightSetsToDbSuitable(_userId, workoutSetCollection);
                var workoutSets = await _mediator.Send(new QuickAddWorkoutSetsCommand(convertWorkoutCollection.Data.ToList(), _userId));
                workoutSets = await _weightOutputService.ConvertWorkoutSets(workoutSets, _userId, convertWorkoutCollection.IsMetric);
                return Ok(workoutSets);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (WorkoutExerciseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (WorkoutDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{workoutDayId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateWorkoutSet(int workoutDayId, [FromBody] WorkoutSetDTO workoutSetDTO)
        {
            try
            {
                var convertedWorkoutSet = await _weightInsertService.ConvertWeightSetToDbSuitable(_userId, workoutSetDTO);
                var result = await _mediator.Send(new UpdateWorkoutSetCommand(workoutDayId, convertedWorkoutSet.Data, _userId));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{workoutSetId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteWorkoutSet(int workoutSetId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteWorkoutSetCommand(workoutSetId, _userId));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
