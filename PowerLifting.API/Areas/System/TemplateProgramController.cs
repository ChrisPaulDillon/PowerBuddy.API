﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Exceptions.TemplatePrograms;

namespace PowerLifting.API.Areas.System
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
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<TemplateProgramDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTemplatePrograms()
        {
            var templatePrograms = await _service.TemplateProgram.GetAllTemplatePrograms();

            if (templatePrograms == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Template Programs found!"));

            return Ok(Responses.Success(templatePrograms));
        }

        [HttpGet("{templateProgramId:int}")]
        [ProducesResponseType(typeof(ApiResponse<TemplateProgramDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTemplateProgramById(int templateProgramId)
        {
            try
            {
                var templateProgram = await _service.TemplateProgram.GetTemplateProgramById(templateProgramId);
                return Ok(Responses.Success(templateProgram));
            }
            catch (TemplateProgramNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateTemplateProgram([FromBody] TemplateProgramDTO templateProgramDTO)
        {
            try
            {
                await _service.TemplateProgram.CreateTemplateProgram(templateProgramDTO);
                return Ok(Responses.Success());
            }
            catch (TemplateProgramNameAlreadyExistsException ex)
            {
                return Conflict(Responses.Error(ex));
            }
        }
    }
}
