﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.ProgramLogs.Exceptions;
using Microsoft.AspNetCore.Http;
using PowerLifting.Service.ProgramLogs.DTO;
using System;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramLogController : ControllerBase
    {
        private IServiceWrapper _service;

        public ProgramLogController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllProgramLogsByUserId(string userId)
        {
            try
            {
                var programLogs = await _service.ProgramLog.GetAllProgramLogsByUserId(userId);
                return Ok(programLogs);
            }
            catch (ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
            catch (UserDoesNotMatchProgramLogException e)
            {
                return Unauthorized(e);
            }
        }


        [HttpGet("Active/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetActiveProgramLogByUserId(string userId)
        {
            try
            {
                //var programLogs = await _service.ProgramLog.GetActiveProgramLogByUserId(userId);
                return Ok();
            }
            catch (ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogByUserId(string userId, [FromBody]ProgramLogDTO programLogDTO)
        {
            try
            {
                await _service.ProgramLog.UpdateProgramLog(userId, programLogDTO);
                return Ok(programLogDTO);
            }
            catch (ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
            catch (UserDoesNotMatchProgramLogException e)
            {
                return Unauthorized(e);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateProgramLog([FromBody] ProgramLogDTO programLog)
        {
            if (programLog == null) return BadRequest("ProgramLog object is null");

            if (!ModelState.IsValid) return BadRequest("Invalid ProgramLog object");

            _service.ProgramLog.CreateProgramLog(programLog);
            return Ok(programLog);
        }

        [HttpGet("Day/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByUserId(string userId, int programLogId, DateTime dateSelected)
        {
            try
            {
                //TODO Comeback to
                var programLogs = await _service.ProgramLog.GetProgramLogDayByUserId(userId, programLogId, dateSelected);
                return Ok(programLogs);
            }
            catch (ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
            catch (UserDoesNotMatchProgramLogException e)
            {
                return Unauthorized(e);
            }
        }


        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteProgramLog(string userId, [FromBody] ProgramLogDTO programLog)
        {
            try
            {
                _service.ProgramLog.DeleteProgramLog(userId, programLog);
                return NoContent();
            }
            catch (ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
        }

        #region ProgramDays

        [HttpGet("Day/Today/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTodaysProgramLogByUserId(string userId, int programLogId)
        {
            try
            {
                var programLogs = await _service.ProgramLog.GetTodaysProgramLogDayByUserId(userId, programLogId);
                return Ok(programLogs);
            }
            catch(ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
            catch(UserDoesNotMatchProgramLogException e)
            {
                return Unauthorized(e);
            }
        }

        [HttpPost("Day")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProgramLogDay([FromBody] ProgramLogDayDTO programLogDayDTO)
        {
            await _service.ProgramLog.CreateProgramLogDay(programLogDayDTO);
            return Ok();
        }

        #endregion

        [HttpGet("Week/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentProgramLogWeekByUserId(string userId, int programLogId)
        {
            try
            {
                var programLogs = await _service.ProgramLog.GetCurrentProgramLogWeekByUserId(userId, programLogId);
                return Ok(programLogs);
            }
            catch (ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
        }

        #region ProgramDays

        [HttpPost("Exercise")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateProgramLogExercise([FromBody] ProgramLogExerciseDTO programLogExerciseDTO)
        {
            try
            {
                _service.ProgramLog.CreateProgramLogExercise(programLogExerciseDTO);
                return Ok();
            }
            catch(ProgramLogDayNotWithWeekRangeException e)
            {
                return Unauthorized(e);
            }
        }

        [HttpPut("Exercise")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogExercise([FromBody]ProgramLogExerciseDTO programLogDTO)
        {
            try
            {
                await _service.ProgramLog.UpdateProgramLogExercise(programLogDTO);
                return NoContent();
            }
            catch (ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
            catch (UserDoesNotMatchProgramLogException e)
            {
                return Unauthorized(e);
            }
        }

        [HttpDelete("Exercise")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteProgramLogExercise(int programLogExerciseId)
        {
            try
            {
                _service.ProgramLog.DeleteProgramLogExercise(programLogExerciseId);
                return NoContent();
            }
            catch (ProgramLogExerciseNotFoundException e)
            {
                return NotFound(e);
            }
        }

        #endregion
    }
}
