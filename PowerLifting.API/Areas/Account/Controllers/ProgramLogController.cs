using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Areas.Account.Models;
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
using PowerLifting.MediatR.TemplatePrograms.Query.Public;
using PowerLifting.MediatR.Users.Query.Public;

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
                var programLogs = await _mediator.Send(new GetAllProgramLogStatsQuery(userId)).ConfigureAwait(false);

                var programWithTemplate = programLogs.ProgramLogStats.ToList();
                foreach (var program in programWithTemplate)
                {
                    program.TemplateName = await _mediator.Send(new GetTemplateProgramNameByIdQuery(program.TemplateProgramId)).ConfigureAwait(false);
                }

                return Ok(Responses.Success(programWithTemplate));
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
        [ProducesResponseType(typeof(ApiResponse<ProgramLogWithTemplateDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetActiveProgramLog()
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLog = await _mediator.Send(new GetActiveProgramLogByUserIdQuery(userId)).ConfigureAwait(false);

                var programLogExtended = new ProgramLogWithTemplateDTO()
                {
                    ProgramLogId = programLog.ProgramLogId,
                    TemplateProgramId = programLog.TemplateProgramId,
                    StartDate = programLog.StartDate,
                    EndDate = programLog.EndDate,
                    NoOfWeeks = programLog.NoOfWeeks,
                    Monday = programLog.Monday,
                    Tuesday = programLog.Tuesday,
                    Wednesday = programLog.Wednesday,
                    Thursday = programLog.Thursday,
                    Friday = programLog.Friday,
                    Saturday = programLog.Saturday,
                    Sunday = programLog.Sunday,
                    ProgramLogWeeks = programLog.ProgramLogWeeks,
                    LogDates = await _mediator.Send(new GetAllProgramDayDatesQuery(userId)).ConfigureAwait(false)
                };

                if (programLog.TemplateProgramId != null)
                {
                    var templateName = await _mediator
                        .Send(new GetTemplateProgramNameByIdQuery((int) programLog.TemplateProgramId)).ConfigureAwait(false);
                    programLogExtended.TemplateName = templateName;
                }

                return Ok(Responses.Success(programLogExtended));
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

        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogByUserId(string userId, [FromBody] ProgramLogDTO programLogDTO)
        {
            try
            {
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
        public async Task<IActionResult> CreateProgramLogFromScratch([FromBody] CProgramLogDTO programLog)
        {
            userId = User.Claims.First(x => x.Type == "UserID").Value;
            var createdLog = await _mediator.Send(new CreateProgramLogFromScratchCommand(programLog, userId)).ConfigureAwait(false);
            return Ok(Responses.Success(programLog));
        }

        [HttpPost("Template/{templateProgramId:int}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogFromTemplate(int templateProgramId, [FromBody] CProgramLogDTO programLogDTO)
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;

                var template = await _mediator.Send(new GetTemplateProgramByIdQuery(templateProgramId)).ConfigureAwait(false);
                if (template.NoOfDaysPerWeek != programLogDTO.DayCount) throw new ProgramDaysDoesNotMatchTemplateDaysException();

                var liftingStatsToCreate = await _mediator.Send(new DoesUserHaveExerciseCollection1RMSetQuery(templateProgramId, userId)).ConfigureAwait(false);

                var statsToCreate = liftingStatsToCreate.ToList();
                if (statsToCreate.Any()) return Ok(Responses.Success(statsToCreate));

                var programLog = await _mediator.Send(new CreateProgramLogFromTemplateCommand(programLogDTO, template, userId)).ConfigureAwait(false);
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
        public async Task<IActionResult> GetProgramLogWeekByUserId(DateTime date)
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
        }
    }
}
