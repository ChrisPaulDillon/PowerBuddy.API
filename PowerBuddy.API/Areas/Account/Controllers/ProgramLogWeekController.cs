﻿using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.MediatR.ProgramLogWeeks.Commands.Account;
using PowerBuddy.MediatR.ProgramLogWeeks.Querys.Account;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProgramLogWeekController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ProgramLogWeekController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost("{programLogId:int}")]
        [ProducesResponseType(typeof(ProgramLogWeekDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogWeek(int programLogId)
        {
            try
            {
                var programLogWeek = await _mediator.Send(new AddProgramLogWeekToLogCommand(programLogId, _userId)).ConfigureAwait(false);
                return Ok(programLogWeek);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Week/{date}")]
        [ProducesResponseType(typeof(ProgramLogWeekDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogWeekByDate(DateTime date)
        {
            try
            { 
                var programLogWeek = await _mediator.Send(new GetProgramLogWeekBetweenDateQuery(date, _userId)).ConfigureAwait(false);
                return Ok(programLogWeek);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogWeekNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}