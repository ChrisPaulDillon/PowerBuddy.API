using Microsoft.EntityFrameworkCore;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using PowerLifting.ProgramLogs.Contracts.Repositories;
using System.Collections.Generic;
using PowerLifting.Entity.ProgramLogs.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MoreLinq;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogDayRepository : IProgramLogDayRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogDayRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayByDate(string userId, DateTime dateSelected)
        {
            return await _context.Set<ProgramLogDay>().Where(x => x.UserId == userId
                                                             && DateTime.Compare(dateSelected.Date, x.Date.Date) == 0)
                                                             .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                                                             .AsNoTracking()
                                                             .FirstOrDefaultAsync();
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayByProgramLogId(string userId, int programLogId, DateTime dateSelected)
        {
            return await _context.Set<ProgramLogDay>().Where(x => x.UserId == userId //wtf is this garbage
                                                                        && DateTime.Compare(dateSelected.Date, x.Date.Date) == 0
                                                                        && x.ProgramLogDayId == programLogId)
                                                                        .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                                                                        .AsNoTracking()
                                                                        .FirstOrDefaultAsync();
        }

        public async Task<ProgramLogDayDTO> GetClosestProgramLogDayToDate(string userId, DateTime date)
        {
            var result = _context.Set<ProgramLogDay>().Where(x => x.UserId == userId && x.Date >= date)
                                                                        .AsNoTracking()
                                                                        .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                                                                        .MinBy(x => Math.Abs((x.Date - date).Ticks))
                                                                        .ToList();
            if (result.Any())
            {
                var programLogDay = result[0];
                return programLogDay;
            }
            return null;
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayById(int programLogDayId)
        {
            return await _context.Set<ProgramLogDay>().Where(x => x.ProgramLogDayId == programLogDayId)
                                                                 .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                                                                 .AsNoTracking()
                                                                 .FirstOrDefaultAsync();
        }

        public async Task<ProgramLogDay> CreateProgramLogDay(ProgramLogDayDTO programLogDayDTO)
        {
            var programLogDay = _mapper.Map<ProgramLogDay>(programLogDayDTO);
            _context.Add(programLogDay);

            await _context.SaveChangesAsync();
            return programLogDay;
        }

        public async Task<bool> UpdateProgramLogDay(ProgramLogDayDTO programLogDayDTO)
        {
            var programLogDay = _mapper.Map<ProgramLogDay>(programLogDayDTO);
            _context.Update(programLogDay);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteProgramLogDay(ProgramLogDayDTO programLogDayDTO)
        {
            var programLogDay = _mapper.Map<ProgramLogDay>(programLogDayDTO);
            _context.Remove(programLogDay);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId)
        {
            return await _context.Set<ProgramLogDay>()
                .Where(x => x.UserId == userId)
                .Select(x => x.Date.Date)
                .ToListAsync();
        }
    }
}
