using System;
using System.Collections.Generic;
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
using PowerBuddy.Data.Exceptions.TemplatePrograms;
using PowerBuddy.MediatR.ProgramLogs.Commands.Account;
using PowerBuddy.MediatR.ProgramLogs.Querys.Account;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProgramLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ProgramLogController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("Stat")]
        [ProducesResponseType(typeof(IEnumerable<ProgramLogStatDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogStats()
        {
            try
            {
                var ProgramLogStats = await _mediator.Send(new GetAllProgramLogStatsQuery(_userId)).ConfigureAwait(false);
                return Ok(ProgramLogStats);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProgramLogDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetActiveProgramLog()
        {
            try
            {
                var ProgramLog = await _mediator.Send(new GetActiveProgramLogByUserIdQuery(_userId)).ConfigureAwait(false);
                return Ok(ProgramLog);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("{ProgramLogId:int}")]
        [ProducesResponseType(typeof(ProgramLogDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogById(int ProgramLogId)
        {
            try
            {
                var ProgramLog = await _mediator.Send(new GetProgramLogByIdQuery(ProgramLogId, _userId)).ConfigureAwait(false);
                return Ok(ProgramLog);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserProfileNotPublicException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLog([FromBody] ProgramLogDTO ProgramLogDTO)
        {
            try
            {
                var result = await _mediator.Send(new UpdateProgramLogCommand(ProgramLogDTO, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("Scratch")]
        [ProducesResponseType(typeof(ProgramLogDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateProgramLogFromScratch([FromBody] ProgramLogInputScratchDTO ProgramLog)
        {
            try
            {
                var createdLog = await _mediator.Send(new CreateProgramLogFromScratchCommand(ProgramLog, _userId)).ConfigureAwait(false);
                return Ok(createdLog);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (ProgramLogAlreadyActiveException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Template/{templateProgramId:int}")]
        [ProducesResponseType(typeof(ProgramLogDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogFromTemplate(int templateProgramId, [FromBody] ProgramLogTemplateInputDTO ProgramLogDTO)
        {
            try
            {
                var ProgramLog = await _mediator.Send(new CreateProgramLogFromTemplateCommand(ProgramLogDTO, templateProgramId, _userId)).ConfigureAwait(false);
                return Ok(ProgramLog);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (TemplateProgramNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (TemplateExercise1RMNotSetForUserException ex)
            {
                return Conflict(ex.Message);
            }
            catch (ProgramDaysDoesNotMatchTemplateDaysException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogAlreadyActiveException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{ProgramLogId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteProgramLog(int ProgramLogId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteProgramLogCommand(ProgramLogId, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Calendar")]
        [ProducesResponseType(typeof(IEnumerable<DateTime>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProgramLogCalendarStats()
        {
            try
            {
                var dates = await _mediator.Send(new GetAllProgramLogCalendarStatsQuery(_userId)).ConfigureAwait(false);
                return Ok(dates);
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
    }
}
