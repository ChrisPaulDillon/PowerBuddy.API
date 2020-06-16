﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Common.Exceptions;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.Service.ProgramLogs.Exceptions;

namespace PowerLifting.API.API.Areas.ProgramLog
{
    [Route("api/ProgramLog/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RepSchemeController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public RepSchemeController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public IActionResult CreateProgramLogRepScheme([FromBody] ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            try
            {
                _service.ProgramLogRepScheme.CreateProgramLogRepScheme(programLogRepSchemeDTO);
                return Ok(Responses.Success());
            }
            catch (ProgramLogRepSchemeNotFoundException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogRepScheme([FromBody] ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            try
            {
                await _service.ProgramLogRepScheme.UpdateProgramLogRepScheme(programLogRepSchemeDTO);
                return NoContent();
            }
            catch (ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
            catch (UnauthorisedUserException e)
            {
                return Unauthorized(e);
            }
        }

        [HttpDelete("{programLogRepSchemeId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteProgramLogRepScheme(int programLogRepSchemeId)
        {
            try
            {
                _service.ProgramLogRepScheme.DeleteProgramLogRepScheme(programLogRepSchemeId);
                return NoContent();
            }
            catch (ProgramLogDayNotWithWeekRangeException e)
            {
                return Unauthorized(e);
            }
        }
    }
}