﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.Data.DTOs.System;
using PowerBuddy.MediatR.Quotes.Querys;

namespace PowerBuddy.API.Areas.Public
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
        [ProducesResponseType(typeof(IEnumerable<QuoteDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _mediator.Send(new GetAllQuotesQuery()).ConfigureAwait(false);
            return Ok(quotes);
        }
    }
}

