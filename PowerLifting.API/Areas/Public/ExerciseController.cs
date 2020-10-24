using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.ExerciseMuscleGroups.Query.Public;
using PowerLifting.MediatR.Exercises.Query.Public;
using PowerLifting.MediatR.ExerciseTypes.Query.Public;

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
            var exercises = await _mediator.Send(new GetAllExercisesQuery()).ConfigureAwait(false);
            return Ok(Responses.Success(exercises));
        }

        [HttpGet("{exerciseId:int}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExerciseById(int exerciseId)
        {
            try
            {
                var exercise = await _mediator.Send(new GetExerciseByIdQuery(exerciseId)).ConfigureAwait(false);
                return Ok(Responses.Success(exercise));
            }
            catch (ExerciseNotFoundException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("ExerciseMuscleGroup")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExerciseMuscleGroups()
        {
            var exerciseMuscleGroups = await _mediator.Send(new GetAllExerciseMuscleGroupsQuery()).ConfigureAwait(false);
            return Ok(Responses.Success(exerciseMuscleGroups));
        }

        [HttpGet("ExerciseType")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseTypeDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExerciseTypes()
        {
            var exerciseTypes = await _mediator.Send(new GetAllExerciseTypesQuery()).ConfigureAwait(false);
            return Ok(Responses.Success(exerciseTypes));
        }
    }
}
