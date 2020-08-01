﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Areas.ProgramLog.Models;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Exceptions.TemplatePrograms;

namespace PowerLifting.API.Areas.ProgramLog.Controllers
{
    [Route("api/ProgramLog/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LogController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private string userId = "";

        public LogController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProgramLogStatDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllProgramLogsByUserId()
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogs = await _service.ProgramLog.GetAllProgramLogsByUserId(userId);

                var programWithTemplate = programLogs.ToList();
                foreach (var program in programWithTemplate)
                {
                    program.TemplateName = await _service.TemplateProgram.GetTemplateProgramNameById(program.TemplateProgramId);
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
                var programLog = await _service.ProgramLog.GetActiveProgramLogByUserId(userId);
                var templateName = await _service.TemplateProgram.GetTemplateProgramNameById((int)programLog.TemplateProgramId);

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
                    TemplateName = templateName,
                    ProgramLogWeeks = programLog.ProgramLogWeeks,
                    LogDates = await _service.ProgramLogDay.GetAllUserProgramLogDates(userId)
                };
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
                await _service.ProgramLog.UpdateProgramLog(programLogDTO, userId);
                return Ok(Responses.Success(programLogDTO));
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
        public async Task<IActionResult> CreateProgramLog([FromBody] CProgramLogDTO programLog)
        {
            userId = User.Claims.First(x => x.Type == "UserID").Value;
            var createdLog = await _service.ProgramLog.CreateProgramLogFromScratch(programLog, userId);
            return Ok(Responses.Success(programLog));
        }

        [HttpPost("FromTemplate/{templateProgramId:int}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogFromTemplate(int templateProgramId, [FromBody] CProgramLogDTO programLogDTO)
        {
            try
            {
                userId = User.Claims.First(x => x.Type == "UserID").Value;

                var template = await _service.TemplateProgram.GetTemplateProgramById(templateProgramId);
                if (template.MaxLiftDaysPerWeek != programLogDTO.DayCount) throw new ProgramDaysDoesNotMatchTemplateDaysException();

                var liftingStatsToCreate = await _service.TemplateExerciseCollection.DoesUserHaveExerciseCollection1RMSet(templateProgramId, userId);

                var statsToCreate = liftingStatsToCreate.ToList();
                if (statsToCreate.Any()) return Ok(Responses.Success(statsToCreate));
                 
                var programLog = await _service.ProgramLog.CreateProgramLogFromTemplate(programLogDTO, template, userId);
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
                var result = await _service.ProgramLog.DeleteProgramLog(programLogId, userId);
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
                var programLogWeek = await _service.ProgramLog.GetProgramLogWeekBetweenDate(date, userId);
                return Ok(Responses.Success(programLogWeek));
            }
            catch (ProgramLogWeekNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }
    }
}
