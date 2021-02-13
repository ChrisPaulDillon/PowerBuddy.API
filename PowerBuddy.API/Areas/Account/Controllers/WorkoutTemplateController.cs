using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.WorkoutTemplates;
using PowerBuddy.App.Services.Weights;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize]
    public class WorkoutTemplateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWeightInsertConvertorService _weightInsertService;
        private readonly string _userId;

        public WorkoutTemplateController(IMediator mediator, IWeightInsertConvertorService weightInsertService, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _weightInsertService = weightInsertService;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWorkoutTemplate(WorkoutTemplateDto workoutTemplate)
        {
            var convertedWorkoutExercises = await _weightInsertService.ConvertWorkoutExerciseWeightsToDbSuitable(_userId, workoutTemplate.WorkoutExercises);
            workoutTemplate.WorkoutExercises = convertedWorkoutExercises.Data;

            var result = await _mediator.Send(new CreateWorkoutTemplateCommand(workoutTemplate, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                WorkoutNameAlreadyExists => NotFound(Errors.Create(nameof(WorkoutNameAlreadyExists))));
        }
    }
}
