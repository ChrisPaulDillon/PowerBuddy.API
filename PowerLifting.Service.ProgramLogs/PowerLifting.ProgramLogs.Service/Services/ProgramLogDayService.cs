using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.ProgramLogs.Contracts.Services;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.ProgramLogs.Service.Services
{
    public class ProgramLogDayService : IProgramLogDayService
    {
        private readonly IMapper _mapper;
        private readonly IProgramLogWrapper _repo;
        private readonly UserManager<User> _userManager;

        public ProgramLogDayService(IProgramLogWrapper repo, IMapper mapper, UserManager<User> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayById(int programLogDayId)
        {

            var programLogDayDTO = await _repo.ProgramLogDay.GetProgramLogDayById(programLogDayId);
            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> GetClosestProgramLogDayToDate(int programLogWeekId, string userId, DateTime date)
        {
            return await _repo.ProgramLogDay.GetClosestProgramLogDayToDate(programLogWeekId, userId, date);
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayByUserId(string userId, int programLogId, DateTime date)
        {
            var programLogDayDTO = await _repo.ProgramLogDay.GetProgramLogDay(userId, programLogId, date);
            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }

        public async Task<ProgramLogDay> CreateProgramLogDay(ProgramLogDayDTO programLogDayDTO)
        {
            var programLogWeek = await _repo.ProgramLogWeek.GetProgramLogWeekById(programLogDayDTO.ProgramLogWeekId);
            //validator.ValidateProgramLogDayWithinProgramLogWeek(programLogWeek.StartDate, programLogWeek.EndDate, programLogDayDTO.Date);
            //TODO
            return await _repo.ProgramLogDay.CreateProgramLogDay(programLogDayDTO);
        }

        public async Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId)
        {
            return await _repo.ProgramLogDay.GetAllUserProgramLogDates(userId);
        }
    }
}