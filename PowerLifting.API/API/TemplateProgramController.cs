using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerLifting.Service.ServiceWrappers;
using Powerlifting.Services.TemplatePrograms.DTO;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateProgramController : ControllerBase
    {
        private ILogger<TemplateProgramController> _logger;
        private IServiceWrapper _service;

        public TemplateProgramController(IServiceWrapper service, ILogger<TemplateProgramController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProgramTypes()
        {
            var programTemplates = await _service.TemplateProgram.GetAllTemplatePrograms();
            if (programTemplates == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(programTemplates);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplateProgramById(int templateId)
        {
            var programType = await _service.TemplateProgram.GetTemplateProgramById(templateId);

            if (programType == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(programType);
            }
        }


        [HttpGet("Calculate/{id}")]
        public async Task<IActionResult> GetTemplateProgramByIdIncludeLiftingStats(string userId, int programTemplateId)
        {
            try
            {
                var programType = await _service.TemplateProgram.GetTemplateProgramByIdIncludeLiftingStats(userId, programTemplateId);

                if (programType == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(programType);
                }
            }
            catch(Exception e)
            {
                //TODO
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgramType([FromBody] TemplateProgramDTO programTemplate)
        {
            if (programTemplate == null)
            {
                return BadRequest("ProgramType object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid ProgramType model object");
            }

            var ProgramTypeCheck = await _service.TemplateProgram.GetTemplateProgramByName(programTemplate.Name);
            if (ProgramTypeCheck != null)
            {
                return Conflict("Exercise Category is already been added");
            }

            //await _service.TemplateProgram.AddAsync(programTemplate);
            //TODO FIX
            return Ok(programTemplate);
        }
    }
}
