using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogDays.Command.Account;
using PowerLifting.MediatR.ProgramLogDays.Query.Account;

namespace PowerLifting.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Area("Account")]
    public class ProgramLogDayController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramLogDayController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByDate(DateTime dateSelected)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogDay = await _mediator.Send(new GetProgramLogDayByDateQuery(dateSelected, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLogDay));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet("LogSpecific/{programLogId:int}")]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByProgramLogId(int programLogId, DateTime dateSelected)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogDay = await _mediator.Send(new GetProgramSpecificDayByDateQuery(dateSelected, programLogId, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLogDay));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet("{programLogDayId:int}", Name = nameof(GetProgramLogDayById))]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayById(int programLogDayId)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogDayDTO = await _mediator.Send(new GetProgramLogDayByIdQuery(programLogDayId, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLogDayDTO));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateProgramLogDay([FromBody] ProgramLogDayDTO programLogDayDTO)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var createdProgramLogDayDTO = await _mediator.Send(new CreateProgramLogDayCommand(programLogDayDTO, userId)).ConfigureAwait(false);
                return CreatedAtRoute(nameof(GetProgramLogDayById), new { programLogDayId = createdProgramLogDayDTO.ProgramLogDayId }, createdProgramLogDayDTO);
            }
            catch (ProgramLogDayNotWithinWeekException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
            catch (ProgramLogWeekNotFoundException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpDelete("{programLogDayId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteProgramLogDay(int programLogDayId)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new DeleteProgramLogDayCommand(programLogDayId, userId))
                    .ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }
    }
}
