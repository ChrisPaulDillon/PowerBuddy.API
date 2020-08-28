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

            var deadliftLs = await _context.LiftingStat.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.RepRange == 1 && x.ExerciseId == deadlift, cancellationToken: cancellationToken);

            var squat = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseName.ToUpper() == "Back Squat".ToUpper())
                .Select(x => x.ExerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var squatLs = await _context.LiftingStat.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.RepRange == 1 && x.ExerciseId == squat, cancellationToken: cancellationToken);

            var overheadPress = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseName.ToUpper() == "Overhead Press".ToUpper())
                .Select(x => x.ExerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var overheadPressLs = await _context.LiftingStat.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.RepRange == 1 && x.ExerciseId == overheadPress, cancellationToken: cancellationToken);

            var bench = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseName.ToUpper() == "Bench Press".ToUpper())
                .Select(x => x.ExerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var benchLs = await _context.LiftingStat.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.RepRange == 1 && x.ExerciseId == bench, cancellationToken: cancellationToken);

            var liftingStats = new List<LiftingStat>();

            deadliftLs.Weight = request.FirstVisitDTO.DeadliftWeight;
            deadliftLs.LastUpdated = DateTime.UtcNow;

            squatLs.Weight = request.FirstVisitDTO.SquatWeight;
            squatLs.LastUpdated = DateTime.UtcNow;

            overheadPressLs.Weight = request.FirstVisitDTO.OverheadPressWeight;
            overheadPressLs.LastUpdated = DateTime.UtcNow;
            
            squatLs.Weight = request.FirstVisitDTO.SquatWeight;
            squatLs.LastUpdated = DateTime.UtcNow;

            benchLs.Weight = request.FirstVisitDTO.BenchPressWeight;
            benchLs.LastUpdated = DateTime.UtcNow;

            liftingStats.Add(deadliftLs);
            liftingStats.Add(squatLs);
            liftingStats.Add(overheadPressLs);
            liftingStats.Add(squatLs);
            liftingStats.Add(benchLs);

            _context.LiftingStat.AttachRange(liftingStats);
            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}