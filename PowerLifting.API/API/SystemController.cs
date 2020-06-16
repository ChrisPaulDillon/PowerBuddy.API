using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Entity.System.Exercises.DTO;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Entity.System.ExerciseTypes.DTOs;
using PowerLifting.Service.SystemServices.RepSchemeTypes.Model;
using PowerLifting.Service.SystemServices.TemplateDifficultys.Model;
using PowerLifting.Systems.Service.Exceptions;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SystemController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private readonly HttpRequest _request;

        public SystemController(IServiceWrapper service, IHttpContextAccessor accessor)
        {
            _service = service;
            _request = accessor.HttpContext.Request;
        }

        private Uri GetExerciseUri()
        {
            return new Uri($"{_request.Scheme}://{_request.Host}/Api/System/Exercise");
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

        [HttpGet("Exercise/{exerciseId:int}", Name = nameof(GetExerciseById))]
        [ProducesResponseType(typeof(ApiResponse<TopLevelExerciseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExerciseById(int exerciseId)
        {
            var exercises = await _service.Exercise.GetExerciseById(exerciseId);
            if (exercises == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Exercises Found"));
            return Ok(Responses.Success(exercises));
        }

        [HttpPost("Exercise")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<TopLevelExerciseDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateExercise([FromBody] CExerciseDTO exerciseDTO)
        {
            try
            {
                var exercise = await _service.Exercise.CreateExercise(exerciseDTO);
                return CreatedAtRoute(nameof(GetExerciseById), new { exerciseId = exercise.ExerciseId }, exercise);
            }
            catch (ExerciseAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
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

        [HttpGet("RepSchemeType")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<RepSchemeType>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllRepSchemeTypes()
        {
            var repSchemeTypes = await _service.RepSchemeType.GetAllRepSchemeTypes();
            if (repSchemeTypes == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Rep Scheme Types Found"));
            return Ok(Responses.Success(repSchemeTypes));
        }
    }
}

