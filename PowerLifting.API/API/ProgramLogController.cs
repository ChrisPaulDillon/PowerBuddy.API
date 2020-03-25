using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerlifting.Contracts;
using PowerLifting.Entities.DTOs;
using PowerLifting.Entities.DTOs.Lookups;
using PowerLifting.Entities.Model;

namespace PowerLifting.API.API
{
    [Route("api/ProgramLog")]
    [ApiController]
    public class ProgramLogController : ControllerBase
    {
        private ILogger<ProgramLogController> _logger;
        private IServiceWrapper _service;
        public ProgramLogController(IServiceWrapper service, ILogger<ProgramLogController> logger)
        {
            _logger = logger;
            _service = service;
         
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProgramLogs()
        {

            var programLogs = await _service.ProgramLog.GetAllProgramLogs();
            if (programLogs == null)
            {

                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned all Program Logs");
                return Ok(programLogs);
            }
        }

        [HttpGet("Active")]
        public async Task<IActionResult> GetActiveProgramLogs()
        {

            var programLogs = await _service.ProgramLog.GetAllProgramLogs();
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
        public async Task<IActionResult> GetProgramLog(int id)
        {

            var programLog = await _service.ProgramLog.GetProgramLogById(id);

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
            if (programLog == null)
            {
                _logger.LogError("ProgramLog object sent from client is null.");
                return BadRequest("ProgramLog object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid ProgramLog object sent from client.");
                return BadRequest("Invalid ProgramLog object");
            }

            //var programLogCheck = await _service.ProgramLog.GetProgramLog(programLog.ProgramLogName);
            var programLogCheck = programLog;

            if (programLogCheck != null)
            {
                _logger.LogError("ProgramLog is already been added");
                return Conflict("ProgramLog is already been added");
            }

            //await _service.ProgramLog.AddAsync(programLogEntity);
            _service.Save();
            //TODO fix
            return Ok(programLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramLog(int id)
        {
            var programLog = await _service.ProgramLog.GetProgramLogById(id);
            if (programLog == null)
            {
                _logger.LogError($"Program Log with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            //_service.ProgramLog.DeleteProgramLog(programLog);
            _service.Save();
            //TODO fix
            return NoContent();
        }
    }
}
