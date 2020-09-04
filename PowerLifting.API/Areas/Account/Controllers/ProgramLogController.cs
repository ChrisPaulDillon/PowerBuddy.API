using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.MediatR.ProgramLogDays.Query.Account;
using PowerLifting.MediatR.ProgramLogs.Command.Account;
using PowerLifting.MediatR.ProgramLogs.Query.Account;
using PowerLifting.MediatR.ProgramLogWeeks.Query.Account;
using PowerLifting.MediatR.TemplatePrograms.Query.Account;

namespace PowerLifting.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProgramLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        private string userId = "";

        public ProgramLogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProgramLogStatDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllUserProgramLogs()
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogStats = await _mediator.Send(new GetAllProgramLogStatsQuery(userId)).ConfigureAwait(false);

                return Ok(Responses.Success(programLogStats));
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetActiveProgramLog()
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLog = await _mediator.Send(new GetActiveProgramLogByUserIdQuery(userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLog));
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLog([FromBody] ProgramLogDTO programLogDTO)
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new UpdateProgramLogCommand(programLogDTO, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPost("Scratch")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateProgramLogFromScratch([FromBody] CProgramLogDTO programLog)
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;
                var createdLog = await _mediator.Send(new CreateProgramLogFromScratchCommand(programLog, userId))
                    .ConfigureAwait(false);
                return Ok(Responses.Success(createdLog));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (ProgramLogAlreadyActiveException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Template/WeightInput/{templateProgramId:int}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogFromTemplateWithWeightInput(int templateProgramId, [FromBody] CProgramLogWeightInputDTO programLogDTO)
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;

                var programLog = await _mediator.Send(new CreateProgramLogFromTemplateWithWeightInputCommand(programLogDTO, templateProgramId, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLog));
            }
            catch (TemplateProgramNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (TemplateExercise1RMNotSetForUserException ex)
            {
                return Conflict(Responses.Error(ex));
            }
            catch (ProgramDaysDoesNotMatchTemplateDaysException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
            catch (ProgramLogAlreadyActiveException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
        }

        [HttpPost("Template/{templateProgramId:int}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogFromTemplate(int templateProgramId, [FromBody] CProgramLogDTO programLogDTO)
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;

                var liftingStatsToCreate = await _mediator.Send(new DoesUserHaveExerciseCollection1RMSetQuery(templateProgramId, userId)).ConfigureAwait(false);
                if (liftingStatsToCreate.ToList().Any()) return Ok(Responses.Success(liftingStatsToCreate));

                var programLog = await _mediator.Send(new CreateProgramLogFromTemplateCommand(programLogDTO, templateProgramId, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLog));
            }
            catch (TemplateProgramNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (TemplateExercise1RMNotSetForUserException ex)
            {
                return Conflict(Responses.Error(ex));
            }
            catch (ProgramDaysDoesNotMatchTemplateDaysException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
            catch (ProgramLogAlreadyActiveException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
        }

        [HttpDelete("{programLogId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteProgramLog(int programLogId)
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new DeleteProgramLogCommand(programLogId, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
        }

        [HttpGet("Week/{date}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogWeekDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogWeekByDate(DateTime date)
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogWeek = await _mediator.Send(new GetProgramLogWeekBetweenDateQuery(date, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLogWeek));
            }
            catch (ProgramLogWeekNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet("Calendar")]
        [ProducesResponseType(typeof(IEnumerable<DateTime>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProgramLogCalendarStats()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var dates = await _mediator.Send(new GetAllProgramLogCalendarStatsQuery(userId)).ConfigureAwait(false);
                return Ok(Responses.Success(dates));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }
    }
}
