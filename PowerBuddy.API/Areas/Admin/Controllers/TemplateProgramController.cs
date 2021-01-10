using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.TemplatePrograms;
using PowerBuddy.MediatR.TemplatePrograms.Commands;

namespace PowerBuddy.API.Areas.Admin.Controllers
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
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateAllTemplateExerciseCollectionForProgram()
        {
            try
            {
                var userId = "3e892bab-0149-4593-9128-e3c1e193557e";
                var result = await _mediator.Send(new CreateAllTemplateExerciseCollectionForTemplateCommand(userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (UnauthorisedUserException ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPost("Collection/{templateProgramId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateTemplateExerciseCollectionForProgram(int templateProgramId)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new CreateTemplateExerciseCollectionForTemplateCommand(templateProgramId, userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex);
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
                var result = await _mediator.Send(new CreateTemplateProgramCommand(templateProgramDTO, userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (TemplateProgramNameAlreadyExistsException ex)
            {
                return Conflict(ex);
            }
        }
    }
}