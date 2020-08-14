using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Exercises;

namespace PowerLifting.API.Areas.Public
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
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _service.Exercise.GetAllExercises();
            return Ok(Responses.Success(exercises));
        }

        [HttpGet("ExerciseMuscleGroup")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExerciseMuscleGroups()
        {
            var exercises = await _service.ExerciseMuscleGroup.GetAllExerciseMuscleGroups();
            return Ok(Responses.Success(exercises));
        }

        [HttpGet("ExerciseType")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseTypeDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExerciseTypes()
        {
            var exerciseTypes = await _service.ExerciseType.GetAllExerciseTypes();
            return Ok(Responses.Success(exerciseTypes));
        }
    }
}
