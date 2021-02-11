using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.WorkoutTemplates
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
            RuleFor(x => x.WorkoutTemplateId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
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
                .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.WorkoutTemplateId == request.WorkoutTemplateId, cancellationToken: cancellationToken);

            if (workoutTemplate == null)
            {
                return false;
            }

            _context.WorkoutTemplate.Remove(workoutTemplate);
            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

            return modifiedRows > 0;
        }
    }
}