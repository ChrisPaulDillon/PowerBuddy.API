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
        private IServiceWrapper _service;
        public UserController(IServiceWrapper service, ILogger<UserController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
                    return Ok(users);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUser action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

                //await _service.User.AddAsync(userEntity);
                _service.Save();
                //TODO fix
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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

                ///_service.User.Update(user);
                _service.Save();
                //TODO fix
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
            var user = await _service.User.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            //_service.User.DeleteUser(user);
            _service.Save();

            return NoContent();
        
        }

        // GET: api/User/5
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _service.User.GetUserByEmail(username);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                bool verifyPassword = PasswordHandler.Instance.VerifyHash(password, user.Password);
                if (!verifyPassword)
                {
                    return Unauthorized(); //Change in future?
                }

                return Ok(user);
            }
        }
    }
}
