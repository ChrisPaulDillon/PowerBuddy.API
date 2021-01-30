using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Exceptions.Exercises;

namespace PowerBuddy.MediatR.Commands.Exercises
{
    public class DeleteExerciseCommand : IRequest<bool>
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

    internal class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public DeleteExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercise
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ExerciseId == request.ExerciseId);

            if (exercise == null) throw new ExerciseNotFoundException();

            _context.Remove(exercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
