using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerlifting.Contracts;
using PowerLifting.Cypto;
using PowerLifting.Entities.DTOs;
using PowerLifting.Entities.Model;

namespace PowerLifting.API.API
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;
        private IMapper _mapper;
        private IServiceWrapper _service;
        public UserController(IServiceWrapper service, ILogger<UserController> logger, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _service.User.GetAllUsers();
                if (users == null)
                {
                    _logger.LogError($"No Users have been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned all users");
                    var userResult = _mapper.Map<IEnumerable<UserDTO>>(users);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error returning all users");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _service.User.GetUserById(id);

                if (user == null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned owner with details for id: {id}");

                    var userResult = _mapper.Map<UserDTO>(user);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUser action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            try
            {
                if (user == null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var userCheck = await _service.User.GetUserByEmail(user.Email);
                if (userCheck != null)
                {
                    _logger.LogError("Username is already taken");
                    return Conflict("Username is already taken");
                }

                user.Password = PasswordHandler.Instance.ComputeHash(user.Password);

                //user.LiftingStats = liftingStats;

                var userEntity = _mapper.Map<User>(user);

                await _service.User.AddAsync(userEntity);
                _service.Save();

                var createdUser = _mapper.Map<UserDTO>(userEntity);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody]UserDTO user)
        {
            try
            {
                if (user == null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid User object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var userEntity = await _service.User.GetUserById(id);
                if (userEntity == null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(user, userEntity);

                _service.User.Update(userEntity);
                _service.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _service.User.GetUserById(id);
                if (user == null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _service.User.DeleteUser(user);
                _service.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/User/5
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var user = await _service.User.GetUserByEmail(username);

                if (user == null)
                {
                    _logger.LogError($"User with username: {username}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    bool verifyPassword = PasswordHandler.Instance.VerifyHash(password, user.Password);
                    if (!verifyPassword)
                    {
                        _logger.LogError($"Password authentication failed for username : {username}");
                        return Unauthorized(); //Change in future?
                    }

                    _logger.LogInformation($"Returned user with details for username: {username}");

                    var userResult = _mapper.Map<UserDTO>(user);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
