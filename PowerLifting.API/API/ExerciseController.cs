using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Service;
using PowerLifting.Service.Exercises.DTO;
using PowerLifting.Service.Exercises.Exceptions;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ExerciseController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public ExerciseController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<TopLevelExerciseDTO>>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExercises()
        {       
            var exercises = await _service.Exercise.GetAllExercises();
            if (exercises == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Exercises Found"));
            return Ok(Responses.Success(exercises));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<ExerciseDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            try
            {
                var exercise = await _service.Exercise.GetExerciseById(id).ConfigureAwait(true);
                return Ok(Responses.Success(exercise));
            }
            catch (ExerciseValidationException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (ExerciseNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }

        [HttpGet("ExerciseMuscleGroup")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseDTO>>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExerciseMuscleGroupsAsync()
        {
            try
            {
                var exercises = await _service.ExerciseMuscleGroup.GetAllExerciseMuscleGroups();
                return Ok(Responses.Success(exercises));
            }
            catch (ExerciseMuscleGroupNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }    
        }

        [HttpGet("ExerciseType")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseTypeDTO>>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExerciseTypesAsync()
        {
            var exerciseTypes = await _service.ExerciseType.GetAllExerciseTypes();
            if (exerciseTypes == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Exercise Types Found"));
            return Ok(Responses.Success(exerciseTypes));
        }
    }
}
