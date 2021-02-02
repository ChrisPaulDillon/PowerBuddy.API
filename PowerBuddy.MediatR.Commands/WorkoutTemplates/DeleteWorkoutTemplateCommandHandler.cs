using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Exceptions.Workouts;

namespace PowerBuddy.MediatR.Commands.WorkoutTemplates
{
    public class DeleteWorkoutTemplateCommand : IRequest<bool>
    {
        public int WorkoutTemplateId { get; }
        public string UserId { get; }

        public DeleteWorkoutTemplateCommand(int workoutTemplateId, string userId)
        {
            WorkoutTemplateId = workoutTemplateId;
            UserId = userId;
        }
    }

    public class DeleteWorkoutTemplateCommandValidator : AbstractValidator<DeleteWorkoutTemplateCommand>
    {
        public DeleteWorkoutTemplateCommandValidator()
        {
            RuleFor(x => x.WorkoutTemplateId).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than {ComparisonValue}");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
        }
    }

    public class DeleteWorkoutTemplateCommandHandler : IRequestHandler<DeleteWorkoutTemplateCommand, bool>
    {
        private readonly PowerLiftingContext _context;

        public DeleteWorkoutTemplateCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteWorkoutTemplateCommand request, CancellationToken cancellationToken)
        {
            var workoutTemplate = await _context.WorkoutTemplate
                .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.WorkoutTemplateId == request.WorkoutTemplateId);

            if (workoutTemplate == null)
            {
                throw new WorkoutTemplateNotFoundException();
            }

            _context.WorkoutTemplate.Remove(workoutTemplate);
            var modifiedRows = await _context.SaveChangesAsync();

            return modifiedRows > 0;
        }
    }
}