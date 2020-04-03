using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.Service.ServiceWrappers;
using Powerlifting.Services.TemplatePrograms.DTO;

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
        public async Task<IActionResult> GetAllTemplatePrograms()
        {
            var programTemplates = await _service.TemplateProgram.GetAllTemplatePrograms();

            if (programTemplates == null) return NotFound();

            return Ok(programTemplates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplateProgramById(int templateId)
        {
            var programType = await _service.TemplateProgram.GetTemplateProgramById(templateId);

            if (programType == null) return NotFound();
            
            return Ok(programType);
        }

        [HttpGet("Calculate/{id}")]
        public async Task<IActionResult> GetTemplateProgramByIdIncludeLiftingStats(string userId, int programTemplateId)
        {
            try
            {
                var programType = await _service.TemplateProgram.GetTemplateProgramByIdIncludeLiftingStats(userId, programTemplateId);

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
        public async Task<IActionResult> CreateTemplateProgram([FromBody] TemplateProgramDTO programTemplate)
        {
            if (programTemplate == null) return BadRequest("TemplateProgram object is null");
            if (!ModelState.IsValid) return BadRequest("Invalid TemplateProgram model object");
           
            var ProgramTypeCheck = await _service.TemplateProgram.GetTemplateProgramByName(programTemplate.Name);
            if (ProgramTypeCheck != null) return Conflict("Exercise Category has already been added");
           
            await _service.TemplateProgram.CreateTemplateProgram(programTemplate);
            return Ok(programTemplate);
        }
    }
}
