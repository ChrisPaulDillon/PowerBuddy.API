using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogs.Query.Account;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.ProgramLogs.QueryHandler.Account
{
    public class GetAllProgramLogsByUserIdQueryHandler : IRequestHandler<GetAllProgramLogsByUserIdQuery, IEnumerable<ProgramLogStatDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllProgramLogsByUserIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogStatDTO>> Handle(GetAllProgramLogsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var programLogStats = await _context.Set<ProgramLog>().Where(x => x.UserId == request.UserId)
                .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();

            if (programLogStats == null) throw new ProgramLogNotFoundException();

            var stats = programLogStats.Select(x => new ProgramLogStatDTO()
            {
                ProgramLogId = x.ProgramLogId,
                TemplateProgramId = x.TemplateProgramId ?? 0,
                NoOfWeeks = x.NoOfWeeks,
                UserId = x.UserId,
                Monday = x.Monday,
                Tuesday = x.Tuesday,
                Wednesday = x.Wednesday,
                Thursday = x.Thursday,
                Friday = x.Friday,
                Saturday = x.Saturday,
                Sunday = x.Sunday,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Active = x.Active,
                DayCount = x.ProgramLogWeeks.Sum(j => j.ProgramLogDays.Count),
                ExerciseCount = x.ProgramLogWeeks.SelectMany(c => c.ProgramLogDays).SelectMany(p => p.ProgramLogExercises).Count(),
                ExerciseCompletedCount = x.ProgramLogWeeks.SelectMany(c => c.ProgramLogDays).SelectMany(p => p.ProgramLogExercises.Where(x => x.Completed)).Count(),
            });
            return stats;
        }
    }
}
