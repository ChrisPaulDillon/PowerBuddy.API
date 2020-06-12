using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.ProgramLogs.Contracts.Services;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.ProgramLogs.Service.Validator;
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

        public async Task<ProgramLogDayDTO> GetProgramLogDayByUserId(string userId, int programLogId, DateTime date)
        {
            var validator = new ProgramLogValidator();
            validator.ValidateProgramLogDayId(programLogId);

            var programLogDay = await _repo.ProgramLogDay.GetProgramLogDay(userId, programLogId, date);

            if (programLogDay == null) throw new ProgramLogDayNotFoundException();

            var programLogDayDTO = _mapper.Map<ProgramLogDayDTO>(programLogDay);
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> GetTodaysProgramLogDayByUserId(string userId)
        {
            var programLogDay = await _repo.ProgramLogDay.GetProgramLogTodayDay(userId);
            if (programLogDay == null) throw new ProgramLogDayNotFoundException();

            var programLogDayDTO = _mapper.Map<ProgramLogDayDTO>(programLogDay);
            return programLogDayDTO;
        }

        public async Task CreateProgramLogDay(ProgramLogDayDTO programLogDayDTO)
        {
            var programLogWeek = await _repo.ProgramLogWeek.GetProgramLogWeekById(programLogDayDTO.ProgramLogWeekId);
            var validator = new ProgramLogValidator();
            validator.ValidateProgramLogDayWithinProgramLogWeek(programLogWeek.StartDate, programLogWeek.EndDate, programLogDayDTO.Date);

            var newProgramLogDay = _mapper.Map<ProgramLogDay>(programLogDayDTO);
            _repo.ProgramLogDay.CreateProgramLogDay(newProgramLogDay);
        }

        public async Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId)
        {
            return await _repo.ProgramLogDay.GetAllUserProgramLogDates(userId);
        }
    }
}