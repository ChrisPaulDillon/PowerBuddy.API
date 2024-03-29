﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.WorkoutExercises
{
    public class DeleteWorkoutExerciseCommand : IRequest<bool>
    {
        public int WorkoutExerciseId { get; }
        public string UserId { get; }

        public DeleteWorkoutExerciseCommand(int workoutExerciseId, string userId)
        {
            WorkoutExerciseId = workoutExerciseId;
            UserId = userId;
        }
    }

    public class DeleteWorkoutExerciseCommandValidator : AbstractValidator<DeleteWorkoutExerciseCommand>
    {
        public DeleteWorkoutExerciseCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutExerciseId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
        }
    }

    public class DeleteWorkoutExerciseCommandHandler : IRequestHandler<DeleteWorkoutExerciseCommand, bool>
    {
        private readonly PowerLiftingContext _context;

        public DeleteWorkoutExerciseCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteWorkoutExerciseCommand request, CancellationToken cancellationToken)
        {
            var workoutExercise = await _context.WorkoutExercise
                .FirstOrDefaultAsync(x => x.WorkoutExerciseId == request.WorkoutExerciseId, cancellationToken: cancellationToken);

            if (workoutExercise == null) return false;

            var isUserAuthorized = await _context.WorkoutDay
                .AsNoTracking()
                .AnyAsync(x => x.WorkoutDayId == workoutExercise.WorkoutDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (!isUserAuthorized) return false;

            _context.WorkoutExercise.Remove(workoutExercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
