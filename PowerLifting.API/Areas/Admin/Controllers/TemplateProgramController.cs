﻿using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.MediatR.TemplatePrograms.Command.Admin;

namespace PowerLifting.API.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Admin")]
    public class TemplateProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TemplateProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Collection/All")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateAllTemplateExerciseCollectionForProgram()
        {
            try
            {
                var userId = "3e892bab-0149-4593-9128-e3c1e193557e";
                var result = await _mediator.Send(new CreateAllTemplateExerciseCollectionForTemplateCommand(userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (UnauthorisedUserException ex)
            {
                return Conflict(Responses.Error(ex));
            }
        }

        [HttpPost("Collection/{templateProgramId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateTemplateExerciseCollectionForProgram(int templateProgramId)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new CreateTemplateExerciseCollectionForTemplateCommand(templateProgramId, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateTemplateProgram([FromBody] TemplateProgramDTO templateProgramDTO)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new CreateTemplateProgramCommand(templateProgramDTO, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (TemplateProgramNameAlreadyExistsException ex)
            {
                return Conflict(Responses.Error(ex));
            }
        }
    }
}