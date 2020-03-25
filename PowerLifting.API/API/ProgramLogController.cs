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
            try
            {
                var programLogs = await _service.ProgramLog.GetAllProgramLogs();
                if (programLogs == null)
                {
                    _logger.LogError($"No Program Logs have been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned all Program Logs");
                    return Ok(programLogs);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error returning all Program Logs");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Active")]
        public async Task<IActionResult> GetActiveProgramLogs()
        {
            try
            {
                var programLogs = await _service.ProgramLog.GetAllProgramLogs();
                if (programLogs == null)
                {
                    _logger.LogError($"No Program Logs are currently active");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned all active Program Logs");
                    return Ok(programLogs);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error returning all Program Logs");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramLog(int id)
        {
            try
            {
                var programLog = await _service.ProgramLog.GetProgramLogById(id);

                if (programLog == null)
                {
                    _logger.LogError($"ProgramLog with name: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned owner with details for id: {id}");
                    return Ok(programLog);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProgramLog action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgramLog([FromBody] ProgramLogDTO programLog)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProgramLog action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramLog(int id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteProgramLog action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
