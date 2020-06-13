using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using PowerLifting.ProgramLogs.Contracts.Repositories;
using System.Collections.Generic;
using PowerLifting.Entity.ProgramLogs.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;

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
                                                                        .FirstOrDefaultAsync();
        }

        public async Task<ProgramLogDayDTO> GetProgramLogDayById(int programLogDayId)
        {
            return await PowerliftingContext.Set<ProgramLogDay>().Where(x => x.ProgramLogDayId == programLogDayId)
                                                                 .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                                                                 .AsNoTracking()
                                                                 .FirstOrDefaultAsync();
        }

        public void CreateProgramLogDay(ProgramLogDay programLogDay)
        {
            Create(programLogDay);
        }

        public void UpdateProgramLogDay(ProgramLogDay programLogDay)
        {
            Update(programLogDay);
        }

        public void DeleteProgramLogDay(ProgramLogDay programLogDay)
        {
            Delete(programLogDay);
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
