using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.MediatR.ProgramLogs.Model;

namespace PowerBuddy.MediatR.ProgramLogs.Querys
{
    public class GetAllProgramLogStatsQuery : IRequest<ProgramLogStatExtendedDTO>
    {
        public string UserId { get; }

        public GetAllProgramLogStatsQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetAllProgramLogStatsQueryHandler : IRequestHandler<GetAllProgramLogStatsQuery, ProgramLogStatExtendedDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllProgramLogStatsQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogStatExtendedDTO> Handle(GetAllProgramLogStatsQuery request, CancellationToken cancellationToken)
        {
            var programLogStats = await _context.ProgramLog.Where(x => x.UserId == request.UserId)
                .ProjectTo<ProgramLogStatDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            if (!programLogStats.Any()) throw new ProgramLogNotFoundException();

            foreach (var programLog in programLogStats)
            {
                programLog.DayCount = programLog.ProgramLogWeeks.Sum(j => j.ProgramLogDays.Count());
                programLog.ExerciseCount = programLog.ProgramLogWeeks.SelectMany(c => c.ProgramLogDays).SelectMany(p => p.ProgramLogExercises).Count();
                programLog.ProgramLogWeeks = null;
            }

            var programLogStatExtended = new ProgramLogStatExtendedDTO()
            {
                UserId = programLogStats[0].UserId,
                LifetimeLogCount = programLogStats.Count(),
                LifetimeDayCount = programLogStats.Sum(j => j.DayCount),
                LifetimeExerciseCount = programLogStats.Sum(x => x.ExerciseCount),
                ProgramLogStats = programLogStats
            };


            return programLogStatExtended;
        }
    }
}
