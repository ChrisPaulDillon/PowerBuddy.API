using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.MediatR.ProgramLogRepSchemes.Command.Account;
using PowerLifting.MediatR.TemplatePrograms.Command.Admin;
using PowerLifting.MediatR.TemplatePrograms.Query.Public;

namespace PowerLifting.API.Areas.Public
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
