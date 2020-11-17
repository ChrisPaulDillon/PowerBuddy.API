using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.Exceptions.Exercises;
using PowerBuddy.MediatR.Exercises.Querys.Public;

namespace PowerBuddy.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class ExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _mediator.Send(new GetAllExercisesQuery()).ConfigureAwait(false);
            return Ok(exercises);
        }

        [HttpGet("{exerciseId:int}")]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExerciseById(int exerciseId)
        {
            try
            {
                var exercise = await _mediator.Send(new GetExerciseByIdQuery(exerciseId)).ConfigureAwait(false);
                return Ok(exercise);
            }
            catch (ExerciseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("ExerciseMuscleGroup")]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExerciseMuscleGroups()
        {
            var exerciseMuscleGroups = await _mediator.Send(new GetAllExerciseMuscleGroupsQuery()).ConfigureAwait(false);
            return Ok(exerciseMuscleGroups);
        }

        [HttpGet("ExerciseType")]
        [ProducesResponseType(typeof(IEnumerable<ExerciseTypeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExerciseTypes()
        {
            var exerciseTypes = await _mediator.Send(new GetAllExerciseTypesQuery()).ConfigureAwait(false);
            return Ok(exerciseTypes);
        }
    }
}
