using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Exceptions.TemplatePrograms;
using PowerBuddy.MediatR.TemplatePrograms.Commands.Admin;
using PowerBuddy.MediatR.TemplatePrograms.Querys.Public;

namespace PowerBuddy.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class TemplateProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TemplateProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TemplateProgramDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTemplatePrograms()
        {
            var templatePrograms = await _mediator.Send(new GetAllTemplateProgramsQuery()).ConfigureAwait(false);
            return Ok(templatePrograms);
        }

        [HttpGet("Search")]
        [ProducesResponseType(typeof(IEnumerable<TemplateKeyValuePairDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTemplateProgramSearchResults(string searchTerm)
        {
            var templatePrograms = await _mediator.Send(new GetTemplateProgramsBySearchQuery(searchTerm)).ConfigureAwait(false);
            return Ok(templatePrograms);
        }

        [HttpGet("Feed")]
        [ProducesResponseType(typeof(IEnumerable<TemplateProgramAuditDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTemplateProgramFeed()
        {
            var templateProgramFeed = await _mediator.Send(new GetTemplateActivityFeedQuery()).ConfigureAwait(false);
            return Ok(templateProgramFeed);
        }

        [HttpGet("{templateProgramId:int}")]
        [ProducesResponseType(typeof(TemplateProgramExtendedDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTemplateProgramById(int templateProgramId)
        {
            try
            {
                var templateProgram = await _mediator.Send(new GetTemplateProgramByIdQuery(templateProgramId)).ConfigureAwait(false);
                return Ok(templateProgram);
            }
            catch (TemplateProgramNotFoundException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateTemplateProgram([FromBody] TemplateProgramDTO templateProgramDTO)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var templateProgram = await _mediator.Send(new CreateTemplateProgramCommand(templateProgramDTO, userId)).ConfigureAwait(false);
                return Ok(templateProgram);
            }
            catch (TemplateProgramNameAlreadyExistsException ex)
            {
                return Conflict(ex);
            }
        }
    }
}
