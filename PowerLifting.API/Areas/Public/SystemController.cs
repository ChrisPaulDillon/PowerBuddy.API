using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.System;
using PowerLifting.MediatR.System.Query.Public;

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

        [HttpGet("Gender")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<GenderDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await _mediator.Send(new GetAllGendersQuery()).ConfigureAwait(false);
            return Ok(Responses.Success(genders));
        }

        [HttpGet("MemberStatus")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<GenderDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMemberStatus()
        {
            var memberStatus = await _mediator.Send(new GetAllMemberStatusQuery()).ConfigureAwait(false);
            return Ok(Responses.Success(memberStatus));
        }
    }
}
