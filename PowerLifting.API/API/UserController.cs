using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.Service;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Exceptions;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private readonly SignInManager<User> _signInManager;

        public UserController(IServiceWrapper service, SignInManager<User> signInManager)
        {
            _service = service;
            _signInManager = signInManager;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginUser(LoginModel loginModel)
        {
            try
            {

                var user = await _service.User.LoginUser(loginModel);
                return Ok(user);
            }
            catch(InvalidCredentialsException e)
            {
                return Unauthorized(e);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserDTO user)
        {
            try
            {
                user.UserName = user.Email;
                if (user == null) return BadRequest("User object is null");
                if (!ModelState.IsValid) return BadRequest("Invalid model object");

                await _service.User.RegisterUser(user);
                return Ok(user);
            }
            catch(EmailInUseException e)
            {
                return Conflict(e);
            }   
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult UpdateUser(int id, [FromBody]UserDTO user)
        {
            try
            {
                if (user == null) return BadRequest("User object is null");
                if (!ModelState.IsValid) return BadRequest("Invalid model object");

                _service.User.UpdateUser(user);
                return NoContent();
            }
            catch(UserNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _service.User.DeleteUser(id);
                return NoContent();
            }
            catch(UserNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
