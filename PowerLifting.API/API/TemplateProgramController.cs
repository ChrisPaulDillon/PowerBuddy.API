using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.TemplatePrograms.DTO;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateProgramController : ControllerBase
    {
        private IServiceWrapper _service;

        public TemplateProgramController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTemplatePrograms()
        {
            var programTemplates = await _service.TemplateProgram.GetAllTemplatePrograms();

            if (programTemplates == null) return NotFound();

            return Ok(programTemplates);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTemplateProgramById(int templateId)
        {
            var programType = await _service.TemplateProgram.GetTemplateProgramById(templateId);

            if (programType == null) return NotFound();
            
            return Ok(programType);
        }

        [HttpGet("Calculate/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GenerateProgramTemplateForIndividual(string userId, int programTemplateId)
        {
            try
            {
                var programType = await _service.TemplateProgram.GenerateProgramTemplateForIndividual(userId, programTemplateId);

                if (programType == null) return NotFound();

                return Ok(programType);
            }
            catch(Exception)
            {
                //TODO
                return NotFound();
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateTemplateProgram([FromBody] TemplateProgramDTO programTemplate)
        {
            var ProgramTypeCheck = await _service.TemplateProgram.GetTemplateProgramByName(programTemplate.Name);
            if (ProgramTypeCheck != null) return Conflict("Exercise Category has already been added");
           
            await _service.TemplateProgram.CreateTemplateProgram(programTemplate);
            return Ok(programTemplate);
        }
    }
}
