using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class SystemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SystemController(IMediator mediator)
        {
            _mediator = mediator;
            _request = accessor.HttpContext.Request;
        }

        [HttpGet("TemplateDifficulty")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<TemplateDifficulty>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTemplateDifficulties()
        {
            var exerciseTypes = await _service.ExerciseType.GetAllExerciseTypes();
            if (exerciseTypes == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Exercise Types Found"));
            return Ok(Responses.Success(exerciseTypes));
        }

        [HttpGet("RepSchemeType")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<RepSchemeType>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllRepSchemeTypes()
        {
            var repSchemeTypes = await _service.RepSchemeType.GetAllRepSchemeTypes();
            if (repSchemeTypes == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Rep Scheme Types Found"));
            return Ok(Responses.Success(repSchemeTypes));
        }

        [HttpGet("Quote")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<QuoteDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _service.Quote.GetAllQuotes();
            if (quotes == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Quotes Found"));
            return Ok(Responses.Success(quotes));
        }
    }
}

