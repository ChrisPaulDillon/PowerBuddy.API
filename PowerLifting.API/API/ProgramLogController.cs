using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using PowerLifting.Service.TemplatePrograms.Exceptions;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.Service.ProgramLogs.Exceptions;
using PowerLifting.Common.Exceptions;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProgramLogController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public ProgramLogController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("All/{userId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProgramLogDTO>>),StatusCodes.Status200OK)]
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
        public async Task<IActionResult> UpdateProgramLogByUserId(string userId, [FromBody]ProgramLogDTO programLogDTO)
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
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>),StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProgramLog([FromBody] ProgramLogDTO programLog)
        {
            await _service.ProgramLog.CreateProgramLog(programLog);
            return Ok(Responses.Success(programLog));
        }

        [HttpPost("FromTemplate/{templateProgramId:int}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogFromTemplate(int templateProgramId, [FromBody]DaySelected daySelected)
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

                var programLogDTO =
                    _service.ProgramLog.CreateProgramLogFromTemplate(template, liftingStats, daySelected);
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
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status404NotFound)]
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

        #region ProgramLogWeek

        [HttpGet("Week/Current/{programLogId:int}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogWeekDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProgramLogWeekByUserId(int programLogId)
        {
            try
            {
                var programLogWeek = await _service.ProgramLog.GetProgramLogWeekByProgramLogId(programLogId, DateTime.UtcNow);
                return Ok(programLogWeek);
            }
            catch (ProgramLogWeekNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }

        #endregion

        #region ProgramDays

        [HttpGet("Day/{userId}")]
        [ProducesResponseType(typeof(ProgramLogDayDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByUserId(string userId, int programLogId, DateTime dateSelected)
        {
            try
            {
                //TODO Comeback to
                var programLogs = await _service.ProgramLog.GetProgramLogDayByUserId(userId, programLogId, dateSelected);
                return Ok(Responses.Success(programLogs));
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


        [HttpGet("Day/Today/{userId}")]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayToday(string userId)
        {
            try
            {
                var programLogDay = await _service.ProgramLog.GetTodaysProgramLogDayByUserId(userId);
                return Ok(Responses.Success(programLogDay));
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

        [HttpPost("Day")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProgramLogDay([FromBody] ProgramLogDayDTO programLogDayDTO)
        {
            await _service.ProgramLog.CreateProgramLogDay(programLogDayDTO);
            return Ok(Responses.Success());
        }

        #endregion

        #region ProgramExercises

        [HttpGet("Exercise/{programLogDayId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProgramLogExerciseDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProgramLogDayExercises(int programLogDayId)
        {
            var programLogExercises = await _service.ProgramLogExercise.GetProgramExercisesByProgramLogDayId(programLogDayId);
            return Ok(Responses.Success(programLogExercises));
        }

        [HttpPost("Exercise/{userId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public IActionResult CreateProgramLogExercise(string userId, [FromBody] ProgramLogExerciseDTO programLogExerciseDTO)
        {
            try
            {
                _service.ProgramLogExercise.CreateProgramLogExercise(userId, programLogExerciseDTO);
                return Ok(Responses.Success());
            }
            catch(ProgramLogDayNotWithWeekRangeException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
        }

        [HttpPut("Exercise")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogExercise([FromBody]ProgramLogExerciseDTO programLogDTO)
        {
            try
            {
                await _service.ProgramLogExercise.UpdateProgramLogExercise(programLogDTO);
                return Ok(Responses.Success());
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpDelete("Exercise")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public IActionResult DeleteProgramLogExercise(int programLogExerciseId)
        {
            try
            {
                _service.ProgramLogExercise.DeleteProgramLogExercise(programLogExerciseId);
                return Ok(Responses.Success());
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }

        #endregion

        #region ProgramLogRepSchemes

        [HttpPost("RepScheme")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public IActionResult CreateProgramLogRepScheme([FromBody] ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            try
            {
                _service.ProgramLog.CreateProgramLogRepScheme(programLogRepSchemeDTO);
                return Ok(Responses.Success());
            }
            catch (ProgramLogRepSchemeNotFoundException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPut("RepScheme")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogRepScheme([FromBody]ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            try
            {
                await _service.ProgramLog.UpdateProgramLogRepScheme(programLogRepSchemeDTO);
                return NoContent();
            }
            catch (ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
            catch (UnauthorisedUserException e)
            {
                return Unauthorized(e);
            }
        }

        [HttpDelete("RepScheme")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteProgramLogRepScheme(int programLogRepSchemeId)
        {
            try
            {
                _service.ProgramLog.DeleteProgramLogRepScheme(programLogRepSchemeId);
                return NoContent();
            }
            catch (ProgramLogDayNotWithWeekRangeException e)
            {
                return Unauthorized(e);
            }
        }

        #endregion
    }
}
