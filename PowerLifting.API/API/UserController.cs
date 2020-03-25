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
using PowerLifting.Services.Service.Users;

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
                    return NotFound();
                }
                else
                {
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
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
                return Ok(user);
            }
            catch(UserNotFoundException e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            try
            {
                if (user == null) return BadRequest("User object is null");

                if (!ModelState.IsValid) return BadRequest("Invalid model object");

                await _service.User.CreateUser(user);
                _service.Save();
                return Ok(user);
            }
            catch(EmailInUseException)
            {
                return Conflict();
            }   
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody]UserDTO user)
        {
            try
            {
                if (user == null) return BadRequest("User object is null");

                if (!ModelState.IsValid) return BadRequest("Invalid model object");

                await _service.User.UpdateUser(user);
                _service.Save();
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
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _service.User.DeleteUser(id);
                _service.Save();
                return NoContent();
            }
            catch(UserNotFoundException)
            {
                return NotFound();
            }
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
