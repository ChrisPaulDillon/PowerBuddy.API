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
        public async Task<IActionResult> GetProgramTemplate(int templateId)
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

            var ProgramTypeCheck = await _service.ProgramTemplate.GetProgramTypeByName(programTemplate.Name);
            if (ProgramTypeCheck != null)
            {
                return Conflict("Exercise Category is already been added");
            }

            //await _service.ProgramTemplate.AddAsync(programTemplate);
            _service.Save();
            //TODO FIX
            return Ok(programTemplate);
        }
    }
}
