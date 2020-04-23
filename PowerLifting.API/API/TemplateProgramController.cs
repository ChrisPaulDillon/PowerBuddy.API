using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.TemplatePrograms.DTO;
using PowerLifting.Service.TemplatePrograms.Exceptions;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TemplateProgramController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public TemplateProgramController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TemplateProgramDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTemplatePrograms()
        {
            var templatePrograms = await _service.TemplateProgram.GetAllTemplatePrograms();

            if (templatePrograms == null) return NotFound();

            return Ok(templatePrograms);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TemplateProgramDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTemplateProgramById(int templateId)
        {
            try
            {
                var templateProgram = await _service.TemplateProgram.GetTemplateProgramById(templateId);
                return Ok(templateProgram);
            }
            catch (TemplateProgramDoesNotExistException e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("Calculate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GenerateProgramTemplateForIndividual(string userId, int programTemplateId)
        {
            try
            {
                var programType = await _service.TemplateProgram.GenerateProgramTemplateForIndividual(userId, programTemplateId);
                return Ok(programType);
            }
            catch(UserDoesNotHaveLiftingStatSetForExerciseException e)
            {
                return Unauthorized(e);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateTemplateProgram([FromBody] TemplateProgramDTO templateProgramDTO)
        {
            try
            {
                await _service.TemplateProgram.CreateTemplateProgram(templateProgramDTO);
                return Ok();
            }
            catch (TemplateProgramNameAlreadyExistsException e)
            {
                return Conflict(e);
            }
        }
    }
}
