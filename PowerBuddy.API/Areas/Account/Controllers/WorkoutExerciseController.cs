using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.Exercises;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.MediatR.Commands.WorkoutExercises;
using PowerBuddy.Services.Weights;
using PowerBuddy.Services.Workouts.Models;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [Area("Account")]
    public class WorkoutExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWeightInsertConvertorService _weightInsertService;
        private readonly IWeightOutgoingConvertorService _weightOutputService;
        private readonly string _userId;

        public WorkoutExerciseController(IMediator mediator, IWeightInsertConvertorService weightInsertService, IWeightOutgoingConvertorService weightOutgoingService, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _weightInsertService = weightInsertService;
            _weightOutputService = weightOutgoingService;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateWorkoutExercise([FromBody] CreateWorkoutExerciseDTO createWorkoutExerciseDTO)
        {
            try
            {
                var convertedWorkoutWeight = await _weightInsertService.ConvertGenericWeightToDbSuitable(_userId, createWorkoutExerciseDTO.Weight);
                createWorkoutExerciseDTO.Weight = convertedWorkoutWeight.Data;

                var workoutExercise = await _mediator.Send(new CreateWorkoutExerciseCommand(createWorkoutExerciseDTO, _userId));
                workoutExercise.WorkoutSets = await _weightOutputService.ConvertWorkoutSets(workoutExercise.WorkoutSets, _userId, convertedWorkoutWeight.IsMetric);

                return Ok(workoutExercise);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (WorkoutDayNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExerciseNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ReachedMaxSetsOnExerciseException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{workoutExerciseId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteWorkoutExercise(int workoutExerciseId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteWorkoutExerciseCommand(workoutExerciseId, _userId));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (WorkoutExerciseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("Note/{workoutExerciseId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateWorkoutExerciseNotes(int workoutExerciseId, string notes)
        {
            try
            {
                var result = await _mediator.Send(new UpdateWorkoutExerciseNoteCommand(workoutExerciseId, notes, _userId));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (WorkoutExerciseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
