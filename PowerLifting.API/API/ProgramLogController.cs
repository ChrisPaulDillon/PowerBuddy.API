using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerLifting.Service.ServiceWrappers;
using Powerlifting.Services.ProgramLogs.DTO;

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

        public async Task<IActionResult> GetAllActiveProgramLogsByUserId(int userId)
        {

            var programLogs = await _service.ProgramLog.GetAllProgramLogsByUserId(userId);
            if (programLogs == null)
            {

                return NotFound();
            }
            else
            {
                return Ok(programLogs);
            }
        }

        [HttpGet("Active/{userId:int}")]
        public async Task<IActionResult> GetActiveProgramLogsByUserId(int userId)
        {
            var programLogs = await _service.ProgramLog.GetActiveProgramLogsByUserId(userId);
            if (programLogs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(programLogs);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramLogByUserId(int userId)
        {
            var programLog = await _service.ProgramLog.GetProgramLogById(userId);

            if (programLog == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(programLog);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgramLog([FromBody] ProgramLogDTO programLog)
        {
            if (programLog == null) return BadRequest("ProgramLog object is null");

            if (!ModelState.IsValid) return BadRequest("Invalid ProgramLog object");

            var programLogCheck = await _service.ProgramLog.GetProgramLogById(programLog.ProgramLogId);

            if (programLogCheck != null) return Conflict("ProgramLog is already been added");
          
            //await _service.ProgramLog.AddAsync(programLogEntity);
            //TODO fix
            return Ok(programLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramLog(int id)
        {
            var programLog = await _service.ProgramLog.GetProgramLogById(id);
            if (programLog == null) return NotFound();
          
            _service.ProgramLog.DeleteProgramLog(programLog);
            return NoContent();
        }
    }
}
