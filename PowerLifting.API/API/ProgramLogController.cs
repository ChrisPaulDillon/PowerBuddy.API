using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerLifting.Service.ServiceWrappers;
using Powerlifting.Services.ProgramLogs.DTO;
using PowerLifting.Service.ProgramLogs.Exceptions;
using Microsoft.AspNetCore.Http;

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

        [HttpGet("Today/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTodaysProgramLogByUserId(string userId)
        {
            try
            {
                var programLogs = await _service.ProgramLog.GetActiveProgramLogByUserId(userId);
                return Ok(programLogs);
            }
            catch(ProgramLogNotFoundException)
            {
                return NotFound();
            }
            catch(UserDoesNotMatchProgramLogException)
            {
                return Unauthorized();
            }
        }

        [HttpGet("Week/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWeeklyProgramLogByUserId(string userId)
        {
            try
            {
                var programLogs = await _service.ProgramLog.GetWeeklyProgramLogByUserId(userId);
                return Ok(programLogs);
            }
            catch (ProgramLogNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("Active/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetActiveProgramLogByUserId(string userId)
        {
            try
            {
                var programLogs = await _service.ProgramLog.GetWeeklyProgramLogByUserId(userId);
                return Ok(programLogs);
            }
            catch (ProgramLogNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProgramLog([FromBody] ProgramLogDTO programLog)
        {
            if (programLog == null) return BadRequest("ProgramLog object is null");

            if (!ModelState.IsValid) return BadRequest("Invalid ProgramLog object");

            var programLogCheck = await _service.ProgramLog.GetProgramLogByProgramLogId(programLog.ProgramLogId);

            if (programLogCheck != null) return Conflict("ProgramLog is already been added");
          
            //await _service.ProgramLog.AddAsync(programLogEntity);
            //TODO fix
            return Ok(programLog);
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
            catch(ProgramLogNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
