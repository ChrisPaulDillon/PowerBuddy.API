using System;
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
using PowerBuddy.MediatR.WorkoutDays.Commands;
using PowerBuddy.MediatR.WorkoutDays.Models;
using PowerBuddy.MediatR.WorkoutDays.Querys;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class WorkoutDayController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public WorkoutDayController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            if (accessor.HttpContext != null) _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("{workoutDayId:int}")]
        [ProducesResponseType(typeof(WorkoutDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWorkoutDayById(int workoutDayId)
        {
            try
            {
                var workoutDay = await _mediator.Send(new GetWorkoutDayByIdQuery(workoutDayId, _userId))
                    .ConfigureAwait(false);

                return Ok(workoutDay);
            }
            catch (WorkoutDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(WorkoutDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateWorkoutDay([FromBody] CreateWorkoutDayOptions createWorkoutOptions)
        {
            try
            {
                var workoutDay = await _mediator.Send(new CreateWorkoutDayCommand(createWorkoutOptions, _userId));

                return Ok(workoutDay);
            }
            catch (WorkoutDayAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Today")]
        [ProducesResponseType(typeof(WorkoutDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWorkoutDayIdByDate()
        {
            try
            {
                var workoutDay = await _mediator.Send(new GetWorkoutDayIdByDateQuery(DateTime.UtcNow, _userId));
                return Ok(workoutDay);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{workoutDayId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateWorkoutDay(int workoutDayId, [FromBody] WorkoutDayDTO workoutDayDTO)
        {
            try
            {
                var liftingStatsThatPb = await _mediator.Send(new CompleteWorkoutCommand(workoutDayDTO, _userId)).ConfigureAwait(false);
                return Ok(liftingStatsThatPb);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (WorkoutDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}