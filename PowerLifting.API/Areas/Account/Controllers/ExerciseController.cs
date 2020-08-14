using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Exceptions.Exercises;

namespace PowerLifting.API.Areas.Account
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class ExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
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


        [HttpGet("{exerciseId:int}", Name = nameof(GetExerciseById))]
        [ProducesResponseType(typeof(ApiResponse<TopLevelExerciseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExerciseById(int exerciseId)
        {
            try
            {
                var exercises = await _service.Exercise.GetExerciseById(exerciseId);
                return Ok(Responses.Success(exercises));
            }
            catch (ExerciseNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
