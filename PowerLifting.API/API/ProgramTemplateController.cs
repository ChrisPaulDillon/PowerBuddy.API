using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerlifting.Services.ProgramTemplates.DTO;
using Powerlifting.Services.ServiceWrappers;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramTemplateController : ControllerBase
    {
        private ILogger<ProgramTemplateController> _logger;
        private IServiceWrapper _service;

        public ProgramTemplateController(IServiceWrapper service, ILogger<ProgramTemplateController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProgramTypes()
        {
            var programTemplates = await _service.ProgramTemplate.GetAllProgramTemplates();
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
        public async Task<IActionResult> GetProgramTemplateById(int templateId)
        {
            var programType = await _service.ProgramTemplate.GetProgramTemplateById(templateId);

            if (programType == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(programType);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgramType([FromBody] ProgramTemplateDTO programTemplate)
        {
            if (programTemplate == null)
            {
                return BadRequest("ProgramType object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid ProgramType model object");
            }

            var ProgramTypeCheck = await _service.ProgramTemplate.GetProgramTemplateByName(programTemplate.Name);
            if (ProgramTypeCheck != null)
            {
                return Conflict("Exercise Category is already been added");
            }

            //await _service.ProgramTemplate.AddAsync(programTemplate);
            //TODO FIX
            return Ok(programTemplate);
        }
    }
}
