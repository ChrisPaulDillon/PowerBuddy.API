﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.ProgramLogs.Service.Exceptions;

namespace PowerLifting.API.Areas.ProgramLog.Controllers
{
    [Route("api/ProgramLog/[controller]")]
    [ApiController]
    [Area("ProgramLog")]
    [Produces("application/json")]
    public class DayController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private string _userId = "";

        public DayController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByUserId(DateTime dateSelected)
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogDay = await _service.ProgramLogDay.GetProgramLogDayByDate(_userId, dateSelected);
                return Ok(Responses.Success(programLogDay));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet("LogSpecific/{programLogId:int}")]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByProgramLogId(int programLogId, DateTime dateSelected)
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogDay = await _service.ProgramLogDay.GetProgramLogDayByProgramLogId(_userId, programLogId, dateSelected);
                return Ok(Responses.Success(programLogDay));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet("Closest")]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetClosestProgramLogDayToDate(DateTime dateSelected)
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogDay = await _service.ProgramLogDay.GetClosestProgramLogDayToDate(_userId, dateSelected);
                return Ok(Responses.Success(programLogDay));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet("{programLogDayId:int}", Name = nameof(GetProgramLogDayById))]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayById(int programLogDayId)
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogs = await _service.ProgramLogDay.GetProgramLogDayById(_userId, programLogDayId);
                return Ok(Responses.Success(programLogs));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateProgramLogDay([FromBody] ProgramLogDayDTO programLogDayDTO)
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
                var createdProgramLogDayDTO = await _service.ProgramLogDay.CreateProgramLogDay(_userId, programLogDayDTO);
                return CreatedAtRoute(nameof(GetProgramLogDayById), new { programLogDayId = createdProgramLogDayDTO.ProgramLogDayId }, createdProgramLogDayDTO);
            }
            catch (ProgramLogDayNotWithinWeekException ex)
            {
                return Conflict(Responses.Error(ex));
            }
        }

        [HttpDelete("{programLogDayId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> DeleteProgramLogDay(int programLogDayId)
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _service.ProgramLogDay.DeleteProgramLogDay(_userId, programLogDayId);
                return Ok(Responses.Success(result));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return Conflict(Responses.Error(ex));
            }
        }

        [HttpGet("All/Date")]
        [ProducesResponseType(typeof(IEnumerable<DateTime>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProgramLogDates()
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogDates = await _service.ProgramLogDay.GetAllUserProgramLogDates(_userId);
                return Ok(Responses.Success(programLogDates));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }
    }
}
