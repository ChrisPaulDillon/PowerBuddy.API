using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;

namespace PowerLifting.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class ExerciseController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private readonly UserManager<User> _userManager;

        public ExerciseController(IServiceWrapper service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
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
