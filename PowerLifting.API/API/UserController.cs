﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Services.Service.Users.Exceptions;
using PowerLifting.Services.Users.DTO;
using PowerLifting.Services.Users.Exceptions;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IServiceWrapper _service;

        public UserController(IServiceWrapper service)
        {
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
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(string id)
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
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserDTO user, string password)
        {
            try
            {
                if (user == null) return BadRequest("User object is null");

                if (!ModelState.IsValid) return BadRequest("Invalid model object");

                await _service.User.RegisterUser(user, password);
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
