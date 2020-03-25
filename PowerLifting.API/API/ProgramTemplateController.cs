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
        private IMapper _mapper;
        private IServiceWrapper _service;
        public ProgramTypeController(IServiceWrapper service, ILogger<ProgramTypeController> logger, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProgramTypes()
        {
            try
            {
                var programTypes = await _service.ProgramType.GetAllIncludeProgramExercises();
                if (programTypes == null)
                {
                    _logger.LogError($"No Program Types have been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned all Program Types");

                    var programTypesResult = _mapper.Map<IEnumerable<ProgramTypeDTO>>(programTypes);
                    return Ok(programTypesResult);
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
                var programType = await _service.ProgramType.GetByCondition(x => x.ProgramTypeId == programTypeId);

                if (programType == null)
                {
                    _logger.LogError($"Program Types with id: {programTypeId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned Exercise Category with details for id: {programTypeId}");

                    var userResult = _mapper.Map<ProgramTypeDTO>(programType);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProgramTypeByName action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgramType([FromBody] ProgramType programType)
        {
            try
            {
                if (programType == null)
                {
                    _logger.LogError("ProgramType object sent from client is null.");
                    return BadRequest("ProgramType object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid ProgramType object sent from client.");
                    return BadRequest("Invalid ProgramType model object");
                }

                var ProgramTypeCheck = await _service.ProgramType.GetProgramTypeByName(programType.Name);
                if (ProgramTypeCheck != null)
                {
                    _logger.LogError("Exercise Category is already been added");
                    return Conflict("Exercise Category is already been added");
                }

                var ProgramTypeEntity = _mapper.Map<ProgramType>(programType);

                await _service.ProgramType.AddAsync(ProgramTypeEntity);
                _service.Save();

                var createdUser = _mapper.Map<ProgramTypeDTO>(ProgramTypeEntity);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProgramType action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
