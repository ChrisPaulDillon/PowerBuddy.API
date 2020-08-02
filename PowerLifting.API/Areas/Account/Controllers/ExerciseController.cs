using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.SignalR;

namespace PowerLifting.API.Areas.Account
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class ExerciseController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public ExerciseController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpPost("Exercise")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<TopLevelExerciseDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateExercise([FromBody] CExerciseDTO exerciseDTO)
        {
            try
            {
                var exercise = await _service.Exercise.CreateExercise(exerciseDTO);
                return CreatedAtRoute(nameof(GetExerciseById), new { exerciseId = exercise.ExerciseId }, exercise);
            }
            catch (ExerciseAlreadyExistsException e)
            {
                return BadRequest();
            }
        }


        [HttpGet("Exercise/{exerciseId:int}", Name = nameof(GetExerciseById))]
        [ProducesResponseType(typeof(ApiResponse<TopLevelExerciseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExerciseById(int exerciseId)
        {
            var exercises = await _service.Exercise.GetExerciseById(exerciseId);
            if (exercises == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Exercise Found"));
            return Ok(Responses.Success(exercises));
        }

    }
}
