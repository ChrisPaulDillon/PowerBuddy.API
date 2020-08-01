﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;

namespace PowerLifting.API.Areas.ProgramLog.Controllers
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

        [HttpPost("Collection")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public IActionResult CreateProgramLogRepSchemeCollection([FromBody] IEnumerable<ProgramLogRepSchemeDTO> programLogRepSchemeCollection)
        {
            try
            {
                var result = _service.ProgramLogRepScheme.CreateProgramLogExerciseCollection(programLogRepSchemeCollection);
                return Ok(Responses.Success(result));
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteProgramLogRepSchemeAsync(int programLogRepSchemeId)
        {
            try
            {
                var result = await _service.ProgramLogRepScheme.DeleteProgramLogRepScheme(programLogRepSchemeId);
                return Ok(result);
            }
            catch (ProgramLogDayNotWithinWeekException e)
            {
                return Unauthorized(e);
            }
        }
    }
}
