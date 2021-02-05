using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.TemplatePrograms;
using PowerBuddy.App.Queries.TemplatePrograms;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Exceptions.TemplatePrograms;

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
            var templatePrograms = await _mediator.Send(new GetAllTemplateProgramsQuery());
            return Ok(templatePrograms);
        }

        [HttpGet("Search")]
        [ProducesResponseType(typeof(IEnumerable<TemplateKeyValuePairDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTemplateProgramSearchResults(string searchTerm)
        {
            var templatePrograms = await _mediator.Send(new GetTemplateProgramsBySearchQuery(searchTerm));
            return Ok(templatePrograms);
        }

        [HttpGet("Feed")]
        [ProducesResponseType(typeof(IEnumerable<TemplateProgramAuditDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTemplateProgramFeed()
        {
            var templateProgramFeed = await _mediator.Send(new GetTemplateActivityFeedQuery());
            return Ok(templateProgramFeed);
        }

        [HttpGet("{templateProgramId:int}")]
        [ProducesResponseType(typeof(TemplateProgramExtendedDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTemplateProgramById(int templateProgramId)
        {
            try
            {
                var result = await _mediator.Send(new GetTemplateProgramByIdQuery(templateProgramId));

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    TemplateProgramNotFound => NotFound(Errors.Create(nameof(TemplateProgramNotFound))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex);
            }
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        //public async Task<IActionResult> CreateTemplateProgram([FromBody] TemplateProgramDTO templateProgramDTO)
        //{
        //    try
        //    {
        //        var userId = User.Claims.First(x => x.Type == "UserID").Value;
        //        var templateProgram = await _mediator.Send(new CreateTemplateProgramCommand(templateProgramDTO, userId));
        //        return Ok(templateProgram);
        //    }
        //    catch (TemplateProgramNameAlreadyExistsException ex)
        //    {
        //        return Conflict(ex);
        //    }
        //}
    }
}
