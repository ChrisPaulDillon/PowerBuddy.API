using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerlifting.Contracts;
using PowerLifting.Entities.DTOs.Programs;
using PowerLifting.Entities.Model.Programs;

namespace PowerLifting.API.API
{
    [Route("api/ProgramType")]
    [ApiController]
    public class ProgramTypeController : ControllerBase
    {
        private ILogger<ProgramTypeController> _logger;
        private IServiceWrapper _service;
        public ProgramTypeController(IServiceWrapper service, ILogger<ProgramTypeController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProgramTypes()
        {
            try
            {
                var programTemplates = await _service.ProgramTemplate.GetAllIncludeProgramExercises();
                if (programTemplates == null)
                {
                    _logger.LogError($"No Program Types have been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned all Program Types");
                    return Ok(programTemplates);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error returning all Program Types");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramType(int programTypeId)
        {
            try
            {
                var programType = await _service.ProgramTemplate.GetByCondition(x => x.ProgramTypeId == programTypeId);

                if (programType == null)
                {
                    _logger.LogError($"Program Types with id: {programTypeId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned ProgramType with details for id: {programTypeId}");
                    return Ok(programType);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProgramTypeByName action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgramType([FromBody] ProgramTemplateDTO programTemplate)
        {
            try
            {
                if (programTemplate == null)
                {
                    _logger.LogError("ProgramType object sent from client is null.");
                    return BadRequest("ProgramType object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid ProgramType object sent from client.");
                    return BadRequest("Invalid ProgramType model object");
                }

                var ProgramTypeCheck = await _service.ProgramTemplate.GetProgramTypeByName(programTemplate.Name);
                if (ProgramTypeCheck != null)
                {
                    _logger.LogError("Exercise Category is already been added");
                    return Conflict("Exercise Category is already been added");
                }

                //await _service.ProgramTemplate.AddAsync(programTemplate);
                _service.Save();
                //TODO FIX
                return Ok(programTemplate);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProgramType action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
