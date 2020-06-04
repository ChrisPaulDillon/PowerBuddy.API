using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Entity.System.ExerciseTypes.DTOs;
using PowerLifting.Service;
using PowerLifting.Service.Exercises.Exceptions;
using PowerLifting.Service.SystemServices.TemplateDifficultys.Model;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SystemController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public SystemController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("Exercise")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<TopLevelExerciseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _service.Exercise.GetAllExercises();
            if (exercises == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Exercises Found"));
            return Ok(Responses.Success(exercises));
        }

        [HttpGet("ExerciseMuscleGroup")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExerciseMuscleGroups()
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
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseTypeDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExerciseTypes()
        {
            var exerciseTypes = await _service.ExerciseType.GetAllExerciseTypes();
            if (exerciseTypes == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Exercise Types Found"));
            return Ok(Responses.Success(exerciseTypes));
        }

        [HttpGet("TemplateDifficulty")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<TemplateDifficulty>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTemplateDifficulties()
        {
            var exerciseTypes = await _service.ExerciseType.GetAllExerciseTypes();
            if (exerciseTypes == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Exercise Types Found"));
            return Ok(Responses.Success(exerciseTypes));
        }
    }
}

