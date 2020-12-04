using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.MediatR.ProgramLogDays.Commands.Account;
using PowerBuddy.MediatR.ProgramLogDays.Commands.Member;
using PowerBuddy.MediatR.ProgramLogDays.Querys.Account;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Area("Account")]
    public class ProgramLogDayController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ProgramLogDayController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByDate(DateTime dateSelected)
        {
            try
            {
                var programLogDay = await _mediator.Send(new GetProgramLogDayByDateQuery(dateSelected, _userId)).ConfigureAwait(false);
                return Ok(programLogDay);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("Summary")]
        [ProducesResponseType(typeof(WorkoutDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetLatestWorkoutSummaries()
        {
            try
            {
                var workoutSummaries = await _mediator.Send(new GetLatestWorkoutDaySummariesQuery(_userId)).ConfigureAwait(false);
                return Ok(workoutSummaries);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("LogSpecific/{programLogId:int}")]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByProgramLogId(int programLogId, DateTime dateSelected)
        {
            try
            {
                var programLogDay = await _mediator.Send(new GetProgramSpecificDayByDateQuery(dateSelected, programLogId, _userId)).ConfigureAwait(false);
                return Ok(programLogDay);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("{programLogDayId:int}", Name = nameof(GetProgramLogDayById))]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayById(int programLogDayId)
        {
            try
            {
                var programLogDayDTO = await _mediator.Send(new GetProgramLogDayByIdQuery(programLogDayId, _userId)).ConfigureAwait(false);
                return Ok(programLogDayDTO);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("{programLogDayId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProgramLogDay(int programLogDayId, [FromBody] ProgramLogDayDTO programLogDayDTO)
        {
            try
            {
                //var result = await _mediator.Send(new UpdateProgramLogDayCommand(programLogDayDTO, _userId)).ConfigureAwait(false);
                //return Ok(result);

                var liftingStatsThatPb = await _mediator.Send(new UpdateProgramLogDayMemberCommand(programLogDayDTO, _userId)).ConfigureAwait(false);
                return Ok(liftingStatsThatPb);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateProgramLogDay([FromBody] ProgramLogDayDTO programLogDayDTO)
        {
            try
            {
                var createdProgramLogDayDTO = await _mediator.Send(new CreateProgramLogDayCommand(programLogDayDTO, _userId)).ConfigureAwait(false);
                return CreatedAtRoute(nameof(GetProgramLogDayById), new {programLogDayId = createdProgramLogDayDTO.ProgramLogDayId}, createdProgramLogDayDTO);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogDayNotWithinWeekException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogWeekNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogDayOnDateAlreadyActiveException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpDelete("{programLogDayId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteProgramLogDay(int programLogDayId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteProgramLogDayCommand(programLogDayId, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("Note/{programLogDayId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProgramLogDayNotes(int programLogDayId, string notes)
        {
            try
            {
                var result = await _mediator.Send(new UpdateProgramLogDayNotesCommand(programLogDayId, notes, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
