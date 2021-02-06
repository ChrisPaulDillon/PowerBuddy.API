using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.TemplatePrograms;
using PowerBuddy.Data.Dtos.Templates;

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
                var result = await _mediator.Send(new CreateAllTemplateExerciseCollectionForTemplateCommand(userId));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
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
                var result = await _mediator.Send(new CreateTemplateExerciseCollectionForTemplateCommand(templateProgramId, userId));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateTemplateProgram([FromBody] TemplateProgramDto templateProgramDto)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new CreateTemplateProgramCommand(templateProgramDto, userId));

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))),
                    TemplateProgramNameAlreadyExists => BadRequest(Errors.Create(nameof(TemplateProgramNameAlreadyExists))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}