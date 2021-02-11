using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Data.Models.Exercises;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Exercises
{
    public class ApproveExerciseCommand : IRequest<OneOf<bool, ExerciseNotFound, UserNotFound>>
    {
        public int ExerciseId { get; }
        public string UserId { get; }

        public ApproveExerciseCommand(int exerciseId, string userId)
        {
            ExerciseId = exerciseId;
            UserId = userId;
        }
    }

    public class ApproveExerciseCommandValidator : AbstractValidator<ApproveExerciseCommand>
    {
        public ApproveExerciseCommandValidator()
        {
            RuleFor(x => x.ExerciseId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class ApproveExerciseCommandHandler : IRequestHandler<ApproveExerciseCommand, OneOf<bool, ExerciseNotFound, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;

        public ApproveExerciseCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<OneOf<bool, ExerciseNotFound, UserNotFound>> Handle(ApproveExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercise.FirstOrDefaultAsync(x => x.ExerciseId == request.ExerciseId, cancellationToken: cancellationToken);

            if (exercise == null)
            {
                return new ExerciseNotFound();
            }

            var userName = await _context.User.Where(x => x.Id == request.UserId && x.MemberStatusId >= 2) //user is a mod or admin
                .AsNoTracking()
                .Select(x => x.UserName)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (userName == null)
            {
                return new UserNotFound();
            }

            exercise.IsApproved = true;
            exercise.AdminApprover = userName;

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
