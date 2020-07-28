using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.ProgramLogs.Contracts.Services;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.Service.ProgramLogs.Exceptions;

namespace PowerLifting.ProgramLogs.Service.Services
{
    public class ProgramLogDayService : IProgramLogDayService
    {
        private readonly IMapper _mapper;
        private readonly IProgramLogWrapper _repo;

        public ProgramLogDayService(IProgramLogWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ProgramLogDay> GetProgramLogDayById(string userId, int programLogDayId)
        {
            var programLogDayDTO = await _repo.ProgramLogDay.GetProgramLogDayById(userId, programLogDayId);
            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayByDate(string userId, DateTime date)
        {
            var programLogDayDTO = await _repo.ProgramLogDay.GetProgramLogDayByDate(userId, date);
            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayByProgramLogId(string userId, int programLogId, DateTime date)
        {
            var programLogDayDTO = await _repo.ProgramLogDay.GetProgramLogDayByProgramLogId(userId, programLogId, date);
            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> GetClosestProgramLogDayToDate(string userId, DateTime date)
        {
            return await _repo.ProgramLogDay.GetClosestProgramLogDayToDate(userId, date);
        }

        public async Task<ProgramLogDay> CreateProgramLogDay(string userId, ProgramLogDayDTO programLogDayDTO)
        {
            programLogDayDTO.UserId = userId;
            var programLogWeek = await _repo.ProgramLogWeek.GetProgramLogWeekById(programLogDayDTO.ProgramLogWeekId);
            if (programLogDayDTO.Date >= programLogWeek.StartDate && programLogDayDTO.Date <= programLogWeek.EndDate)
            {
                return await _repo.ProgramLogDay.CreateProgramLogDay(programLogDayDTO);
            }
            else
            {
                throw new ProgramLogDayNotWithinWeekException();
            }
        }

        public async Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId)
        {
            return await _repo.ProgramLogDay.GetAllUserProgramLogDates(userId);
        }

        public async Task<bool> DeleteProgramLogDay(string userId, int programLogDayId)
        {
            var programLogDay = await _repo.ProgramLogDay.GetProgramLogDayById(userId, programLogDayId);
            if (programLogDay == null) throw new ProgramLogDayNotFoundException();

            return await _repo.ProgramLogDay.DeleteProgramLogDay(programLogDay);
        }
    }
}