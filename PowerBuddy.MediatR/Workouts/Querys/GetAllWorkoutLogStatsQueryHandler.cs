using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.MediatR.Workouts.Models;

namespace PowerBuddy.MediatR.Workouts.Querys
{
    public class GetAllWorkoutStatsQuery : IRequest<WorkoutStatExtendedDTO>
    {
        public string UserId { get; }

        public GetAllWorkoutStatsQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetAllWorkoutStatsQueryHandler : IRequestHandler<GetAllWorkoutStatsQuery, WorkoutStatExtendedDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetAllWorkoutStatsQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkoutStatExtendedDTO> Handle(GetAllWorkoutStatsQuery request, CancellationToken cancellationToken)
        {
            var workoutLogStats = await _context.WorkoutLog
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .ToListAsync(cancellationToken: cancellationToken);

            if (!workoutLogStats.Any()) throw new WorkoutLogNotFoundException();

            //foreach (var workoutLog in workoutLogStats)
            //{
            //    programLog.DayCount = programLog.WorkoutWeeks.Sum(j => j.WorkoutDays.Count());
            //    programLog.ExerciseCount = programLog.WorkoutWeeks.SelectMany(c => c.WorkoutDays)
            //        .SelectMany(p => p.WorkoutExercises).Count();
            //    programLog.WorkoutWeeks = null;
            //}

            var workoutLogStatsExtended = new WorkoutStatExtendedDTO()
            {
                //UserId = programLogStats[0].UserId,
                //LifetimeLogCount = programLogStats.Count(),
                //LifetimeDayCount = programLogStats.Sum(j => j.DayCount),
                //LifetimeExerciseCount = programLogStats.Sum(x => x.ExerciseCount),
                WorkoutLogStats = workoutLogStats
            };

            return workoutLogStatsExtended;
        }
    }
}
