using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Common.Exceptions;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.ProgramLogs.Service.Exceptions;

namespace PowerLifting.API.API.Areas.ProgramLog
{
    [Route("api/ProgramLog/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DayController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public DayController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByUserId(string userId, int programLogId, DateTime dateSelected)
        {
            try
            {
                //TODO Comeback to
                var programLogs = await _service.ProgramLogDay.GetProgramLogDayByUserId(userId, programLogId, dateSelected);
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


        [HttpGet("Today/{userId}")]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayToday(string userId)
        {
            try
            {
                var programLogDay = await _service.ProgramLogDay.GetTodaysProgramLogDayByUserId(userId);
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

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProgramLogDay([FromBody] ProgramLogDayDTO programLogDayDTO)
        {
            await _service.ProgramLogDay.CreateProgramLogDay(programLogDayDTO);
            return Ok(Responses.Success());
        }


        [HttpGet("All/Date/{userId}")]
        [ProducesResponseType(typeof(IEnumerable<DateTime>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProgramLogDates(string userId)
        {
            try
            {
                var programLogDates = await _service.ProgramLogDay.GetAllUserProgramLogDates(userId);
                return Ok(Responses.Success(programLogDates));
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
