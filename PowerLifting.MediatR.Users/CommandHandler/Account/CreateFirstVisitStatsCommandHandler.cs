using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Command.Account;

namespace PowerLifting.MediatR.Users.CommandHandler.Account
{
    public class CreateFirstVisitStatsCommandHandler : IRequestHandler<CreateFirstVisitStatsCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateFirstVisitStatsCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateFirstVisitStatsCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserId , cancellationToken: cancellationToken);
            if (user == null) throw new UserNotFoundException();

            user.Gender = request.FirstVisitDTO.Gender;
            user.LiftingLevel = request.FirstVisitDTO.LiftingLevel;
            user.FirstVisit = true;

            var deadlift = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseName.ToUpper() == "Deadlift".ToUpper())
                .Select(x => x.ExerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var squat = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseName.ToUpper() == "Back Squat".ToUpper())
                .Select(x => x.ExerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var overheadPress = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseName.ToUpper() == "Overhead Press".ToUpper())
                .Select(x => x.ExerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var bench = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseName.ToUpper() == "Bench Press".ToUpper())
                .Select(x => x.ExerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var liftingStats = new List<LiftingStat>();

            var benchStat = new LiftingStat() {UserId = request.UserId, ExerciseId = bench, Weight = request.FirstVisitDTO.BenchPressWeight, LastUpdated = DateTime.UtcNow, RepRange = 1};
            var deadliftStat = new LiftingStat() { UserId = request.UserId, ExerciseId = deadlift, Weight = request.FirstVisitDTO.DeadliftWeight, LastUpdated = DateTime.UtcNow, RepRange = 1};
            var overheadPressStat = new LiftingStat() { UserId = request.UserId, ExerciseId = overheadPress, Weight = request.FirstVisitDTO.OverheadPressWeight, LastUpdated = DateTime.UtcNow, RepRange = 1};
            var squatStat = new LiftingStat() { UserId = request.UserId, ExerciseId = squat, Weight = request.FirstVisitDTO.SquatWeight, LastUpdated = DateTime.UtcNow, RepRange = 1};

            liftingStats.Add(benchStat);
            liftingStats.Add(deadliftStat);
            liftingStats.Add(overheadPressStat);
            liftingStats.Add(squatStat);

            _context.LiftingStat.AttachRange(liftingStats);
            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}