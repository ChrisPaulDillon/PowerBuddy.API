using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.Exercises;
using PowerBuddy.MediatR.Exercises.Commands.Admin;
using PowerBuddy.MediatR.Exercises.Querys.Admin;

namespace PowerBuddy.API.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Admin")]
    [Authorize(Policy = "IsModerator")]
    public class ExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllUnapprovedExercises()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var exercises = await _mediator.Send(new GetAllUnapprovedExercisesQuery(userId)).ConfigureAwait(false);
                return Ok(exercises);
            }
            catch (UserNotFoundException)
            {
                return Unauthorized();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateExercise([FromBody] ExerciseDTO exerciseDTO)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new UpdateExerciseCommand(exerciseDTO, userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (ExerciseNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UserNotFoundException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPut("Approve/{exerciseId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ApproveExercise(int exerciseId)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var exercises = await _mediator.Send(new ApproveExerciseCommand(exerciseId, userId)).ConfigureAwait(false);
                return Ok(exercises);
            }
            catch(ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch(ExerciseNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(UserNotFoundException e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
