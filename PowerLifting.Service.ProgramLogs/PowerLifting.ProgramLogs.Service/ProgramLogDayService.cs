using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Service.Wrapper;

namespace PowerLifting.ProgramLogs.Service
{
    public class ProgramLogDayService : IProgramLogDayService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogWrapper _repo;

        public ProgramLogDayService(PowerLiftingContext context, IProgramLogWrapper repo, IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayById(int programLogDayId, string userId)
        {
            var programLogDayDTO = await _context.Set<ProgramLogDay>().Where(x => x.ProgramLogDayId == programLogDayId && x.UserId == userId)
                .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayByDate(DateTime date, string userId)
        {
            var programLogDayDTO = await _context.Set<ProgramLogDay>().Where(x => x.UserId == userId && DateTime.Compare(date.Date, x.Date.Date) == 0)
                .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayByProgramLogId(string userId, int programLogId, DateTime date)
        {
            var programLogDayDTO = await _context.Set<ProgramLogDay>().Where(x => x.UserId == userId && DateTime.Compare(date.Date, x.Date.Date) == 0 && x.ProgramLogDayId == programLogId)
                .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> CreateProgramLogDay(ProgramLogDayDTO programLogDayDTO, string userId)
        {
            if (userId != programLogDayDTO.UserId) throw new UnauthorisedUserException();

            var programLogWeek = await _context.Set<ProgramLogWeek>().Where(x => x.ProgramLogWeekId == programLogDayDTO.ProgramLogWeekId)
                .Select(x => new ProgramLogWeek()
                {
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (programLogDayDTO.Date >= programLogWeek.StartDate && programLogDayDTO.Date <= programLogWeek.EndDate)
            {
                var programLogDay = _mapper.Map<ProgramLogDay>(programLogDayDTO);
                _context.Add(programLogDay);

                await _context.SaveChangesAsync();
                return programLogDayDTO;
            }
            throw new ProgramLogDayNotWithinWeekException();
        }

        public async Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId)
        {
            return await _context.Set<ProgramLogDay>()
                .Where(x => x.UserId == userId)
                .Select(x => x.Date.Date)
                .ToListAsync();
        }

        public async Task<bool> DeleteProgramLogDay(int programLogDayId, string userId)
        {
            var doesProgramLogDayExist = await _context.ProgramLogDay.AsNoTracking().AnyAsync(x => x.ProgramLogDayId == programLogDayId && x.UserId == userId);
            if (!doesProgramLogDayExist) throw new ProgramLogDayNotFoundException();

            _context.Remove(new ProgramLogDay() { ProgramLogDayId = programLogDayId});

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}