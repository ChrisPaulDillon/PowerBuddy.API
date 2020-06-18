using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
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
    public class ProgramLogDayRepository : RepositoryBase<ProgramLogDay>, IProgramLogDayRepository
    {
        private readonly IMapper _mapper;

        public ProgramLogDayRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDay(string userId, int programLogId, DateTime dateSelected)
        {
            return await PowerliftingContext.Set<ProgramLogDay>().Where(x => x.UserId == userId
                                                                        && DateTime.Compare(dateSelected.Date, x.Date.Date) == 0
                                                                        && x.ProgramLogDayId == programLogId)
                                                                        .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                                                                        .AsNoTracking()
                                                                        .FirstOrDefaultAsync();
        }

        public async Task<ProgramLogDayDTO> GetClosestProgramLogDayToDate(string userId, int programLogId, DateTime date)
        {
            var result = PowerliftingContext.Set<ProgramLogDay>().Where(x => x.Date > date)
                                                                        .AsNoTracking()
                                                                        .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                                                                        .MinBy(x => Math.Abs((x.Date - date).Ticks))
                                                                        .ToList();

            var programLogDay = result[0];
            return programLogDay;
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayById(int programLogDayId)
        {
            return await PowerliftingContext.Set<ProgramLogDay>().Where(x => x.ProgramLogDayId == programLogDayId)
                                                                 .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                                                                 .AsNoTracking()
                                                                 .FirstOrDefaultAsync();
        }

        public async Task CreateProgramLogDay(ProgramLogDay programLogDay)
        {
            await Create(programLogDay);
        }

        public async Task<bool> UpdateProgramLogDay(ProgramLogDay programLogDay)
        {
            return await Update(programLogDay);
        }

        public async Task<bool> DeleteProgramLogDay(ProgramLogDay programLogDay)
        {
            return await Delete(programLogDay);
        }

        public async Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId)
        {
            return await PowerliftingContext.Set<ProgramLogDay>()
                .Where(x => x.UserId == userId)
                .Select(x => x.Date.Date)
                .ToListAsync();
        }
    }
}
