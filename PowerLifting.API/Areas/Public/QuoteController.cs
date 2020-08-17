using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.System;
using PowerLifting.MediaR.Quotes.Query.Public;

namespace PowerLifting.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class QuoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<QuoteDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _mediator.Send(new GetAllQuotesQuery()).ConfigureAwait(false);
            return Ok(Responses.Success(quotes));
        }
    }
}

