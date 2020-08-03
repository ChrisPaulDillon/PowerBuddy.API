using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;

namespace PowerLifting.API.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Admin")]
    public class ExerciseController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private string _userId;

        public ExerciseController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ExerciseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUnapprovedExercises()
        {
            var exercises = await _service.Exercise.GetAllUnapprovedExercises();
            return Ok(Responses.Success(exercises));
        }

        [HttpPut("{exerciseId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ApproveExercise(int exerciseId)
        {
            try
            {
                var result = await _service.Exercise.ApproveExercise(exerciseId, _userId);
                return Ok(Responses.Success(result));
            }
            catch(ExerciseNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
