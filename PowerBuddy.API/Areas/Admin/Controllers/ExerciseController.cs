using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.Exercises;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.DTOs.System;

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

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<TopLevelExerciseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateExercise([FromBody] CExerciseDTO exerciseDTO)
        {
            try
            {
                var result = await _mediator.Send(new CreateExerciseCommand(exerciseDTO));

                return result.Match<IActionResult>(Ok,
                    ExerciseAlreadyExists => BadRequest(Errors.Create(nameof(ExerciseAlreadyExists))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
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
                var result = await _mediator.Send(new UpdateExerciseCommand(exerciseDTO, userId));

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    ExerciseNotFound => BadRequest(Errors.Create(nameof(ExerciseNotFound))));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
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
                var result = await _mediator.Send(new ApproveExerciseCommand(exerciseId, userId));

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    ExerciseNotFound => NotFound(Errors.Create(nameof(ExerciseNotFound))),
                    UserNotFound => NotFound(Errors.Create(nameof(UserNotFound))));
            }
            catch(ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
