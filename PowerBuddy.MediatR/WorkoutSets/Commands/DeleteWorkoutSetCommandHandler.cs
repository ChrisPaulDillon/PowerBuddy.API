﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Services.Workouts;

namespace PowerBuddy.MediatR.WorkoutSets.Commands
{
    public class DeleteWorkoutSetCommand : IRequest<bool>
    {
        public int WorkoutSetId { get; }
        public string UserId { get; }

        public DeleteWorkoutSetCommand(int workoutSetId, string userId)
        {
            WorkoutSetId = workoutSetId;
            UserId = userId;
        }
    }

    public class DeleteWorkoutSetCommandValidator : AbstractValidator<DeleteWorkoutSetCommand>
    {
        public DeleteWorkoutSetCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutSetId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class DeleteWorkoutSetCommandHandler : IRequestHandler<DeleteWorkoutSetCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkoutService _programLogService;

        public DeleteWorkoutSetCommandHandler(PowerLiftingContext context, IMapper mapper, IWorkoutService programLogService)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
        }

        public async Task<bool> Handle(DeleteWorkoutSetCommand request, CancellationToken cancellationToken)
        {
            var workoutSet = await _context.WorkoutSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.WorkoutSetId == request.WorkoutSetId, cancellationToken: cancellationToken);

            if (workoutSet == null) return false;

            var workoutExercise = await _context.WorkoutExercise
                .Where(x => x.WorkoutExerciseId == workoutSet.WorkoutExerciseId)
                .Include(x => x.WorkoutExerciseTonnage)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (workoutExercise == null) return false;

            var workoutDay = await _context.WorkoutDay
                .Where(x => x.WorkoutDayId == workoutExercise.WorkoutDayId && x.UserId == request.UserId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (workoutDay == null) return false;

            workoutDay.Completed = false;

            if (workoutExercise.WorkoutSets.Count == 1) //last set in exercise, delete the full exercise
            {
                _context.WorkoutExercise.Remove(workoutExercise);
                _context.WorkoutSet.Remove(workoutSet);
                var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
                return modifiedRows > 0;
            }

            // Update tonnage
            workoutExercise.WorkoutExerciseTonnage = await _programLogService.UpdateExerciseTonnage(workoutExercise, request.UserId);
            _context.WorkoutSet.Remove(workoutSet);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
