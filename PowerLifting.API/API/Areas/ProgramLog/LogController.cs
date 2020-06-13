using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Common.Exceptions;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.Service.TemplatePrograms.Exceptions;

namespace PowerLifting.API.API.Areas.ProgramLog
{
    [Route("api/ProgramLog/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LogController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public LogController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("All/{userId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProgramLogDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllProgramLogsByUserId(string userId)
        {
            try
            {
                var programLogs = await _service.ProgramLog.GetAllProgramLogsByUserId(userId);
                return Ok(Responses.Success(programLogs));
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


        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogByUserId(string userId)
        {
            try
            {
                var programLog = await _service.ProgramLog.GetProgramLogByUserId(userId);
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

        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogByUserId(string userId, [FromBody] ProgramLogDTO programLogDTO)
        {
            try
            {
                await _service.ProgramLog.UpdateProgramLog(userId, programLogDTO);
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

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProgramLog([FromBody] ProgramLogDTO programLog)
        {
            await _service.ProgramLog.CreateProgramLog(programLog);
            return Ok(Responses.Success(programLog));
        }

        [HttpPost("FromTemplate/{templateProgramId:int}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogFromTemplate(int templateProgramId, [FromBody] DaySelected daySelected)
        {
            try
            {
                var userId = "370676cf-ed1b-420a-a1e7-cfbf43b9605d";

                var template = _service.TemplateProgram.GetTemplateProgramById(templateProgramId);
                if (template == null) throw new TemplateProgramNotFoundException();

                var tec = _service.TemplateExerciseCollection.GetTemplateExerciseCollectionByTemplateProgramId(templateProgramId);
                var liftingStats = await _service.LiftingStat.GetLiftingStatsByUserIdAndRepRange(userId, 1);

                var checkLiftingStats = liftingStats.ToList().Where(item1 => tec.Any(item2 => item1.ExerciseId == item2));

                if (tec.Count() != checkLiftingStats.Count()) throw new TemplateExercise1RMNotSetForUserException();

                var programLogDTO = _service.ProgramLog.CreateProgramLogFromTemplate(template, liftingStats, daySelected);
                return Ok(Responses.Success(programLogDTO));
            }
            catch (TemplateProgramNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (ProgramDaysDoesNotMatchTemplateDaysException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public IActionResult DeleteProgramLog(string userId, int programLogId)
        {
            try
            {
                _service.ProgramLog.DeleteProgramLog(userId, programLogId);
                return Ok(Responses.Success());
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }

        [HttpGet("Week/{userId}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogWeekDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProgramLogWeekByUserId(string userId, DateTime date)
        {
            try
            {
                var programLogWeek = await _service.ProgramLog.GetProgramLogWeekByUserIdAndDate(userId, date);
                return Ok(Responses.Success(programLogWeek));
            }
            catch (ProgramLogWeekNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }
    }
}
