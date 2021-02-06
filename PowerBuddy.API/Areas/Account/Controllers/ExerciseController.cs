using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.Exercises;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.DTOs.System;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [Area("Account")]
    public class ExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ExerciseController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<TopLevelExerciseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateExercise([FromBody] CExerciseDTO exerciseDTO)
        {
            try
            {
                var result = await _mediator.Send(new CreateExerciseCommand(exerciseDTO));

                return result.Match<IActionResult>(Ok,
                    ExerciseAlreadyExists => BadRequest(Errors.Create(nameof(ExerciseAlreadyExists))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
