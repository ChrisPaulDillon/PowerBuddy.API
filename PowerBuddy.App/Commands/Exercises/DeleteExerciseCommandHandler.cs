using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Models.Exercises;

namespace PowerBuddy.App.Commands.Exercises
{
    public class DeleteExerciseCommand : IRequest<OneOf<bool, ExerciseNotFound>>
    {
        public int ExerciseId { get; }
        public string UserId { get; }

        public DeleteExerciseCommand(int exerciseId, string userId)
        {
            ExerciseId = exerciseId;
            UserId = userId;
        }
    }

    public class DeleteExerciseCommandValidator : AbstractValidator<DeleteExerciseCommand>
    {
        public DeleteExerciseCommandValidator()
        {
            RuleFor(x => x.ExerciseId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand, OneOf<bool, ExerciseNotFound>>
    {
        private readonly PowerLiftingContext _context;

        public DeleteExerciseCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<OneOf<bool, ExerciseNotFound>> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercise
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ExerciseId == request.ExerciseId, cancellationToken: cancellationToken);

            if (exercise == null)
            {
                return new ExerciseNotFound();
            }

            _context.Remove(exercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
