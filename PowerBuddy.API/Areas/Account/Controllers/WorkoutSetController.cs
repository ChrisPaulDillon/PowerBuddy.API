using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.MediatR.WorkoutSets.Commands;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [Area("Account")]
    public class WorkoutSetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public WorkoutSetController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost("Collection")]
        [ProducesResponseType(typeof(IEnumerable<WorkoutSetDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWorkoutSetCollection([FromBody] IList<WorkoutSetDTO> WorkoutSetCollection)
        {
            try
            {
                var result = await _mediator.Send(new QuickAddWorkoutSetsCommand(WorkoutSetCollection, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (WorkoutExerciseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (WorkoutDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{workoutDayId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateWorkoutSet(int workoutDayId, [FromBody] WorkoutSetDTO WorkoutSetDTO)
        {
            try
            {
                var result = await _mediator.Send(new UpdateWorkoutSetCommand(workoutDayId, WorkoutSetDTO, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{workoutSetId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteWorkoutSet(int workoutSetId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteWorkoutSetCommand(workoutSetId, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
