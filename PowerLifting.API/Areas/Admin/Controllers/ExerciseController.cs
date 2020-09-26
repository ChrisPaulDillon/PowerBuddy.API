using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.Exercises.Command.Admin;
using PowerLifting.MediatR.Exercises.Query.Admin;

namespace PowerLifting.API.Areas.Admin.Controllers
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
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllUnapprovedExercises()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var exercises = await _mediator.Send(new GetAllUnapprovedExercisesQuery(userId)).ConfigureAwait(false);
                return Ok(Responses.Success(exercises));
            }
            catch (UnauthorisedUserException)
            {
                return Unauthorized();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateExercise([FromBody] ExerciseDTO exerciseDTO)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new UpdateExerciseCommand(exerciseDTO, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (ExerciseValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (ExerciseNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorisedUserException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPut("Approve/{exerciseId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ApproveExercise(int exerciseId)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var exercises = await _mediator.Send(new ApproveExerciseCommand(exerciseId, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(exercises));
            }
            catch(ExerciseValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch(UserValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch(ExerciseNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(UnauthorisedUserException e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
