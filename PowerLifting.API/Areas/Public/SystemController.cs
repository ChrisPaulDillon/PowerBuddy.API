using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.System;
using PowerLifting.MediaR.Quotes.Query.Public;

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
        }

        [HttpGet("Quote")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<QuoteDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _mediator.Send(new GetAllQuotesQuery()).ConfigureAwait(false);
            if (quotes == null) return NotFound(Responses.Error(StatusCodes.Status404NotFound, "No Quotes Found"));
            return Ok(Responses.Success(quotes));
        }
    }
}

