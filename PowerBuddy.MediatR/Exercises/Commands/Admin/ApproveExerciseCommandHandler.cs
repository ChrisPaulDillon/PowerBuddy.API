using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.Exercises;

namespace PowerBuddy.MediatR.Exercises.Commands.Admin
{
    public class ApproveExerciseCommand : IRequest<bool>
    {
        public int ExerciseId { get; }
        public string UserId { get; }

        public ApproveExerciseCommand(int exerciseId, string userId)
        {
            ExerciseId = exerciseId;
            UserId = userId;
        }
    }
    internal class ApproveExerciseCommandHandler : IRequestHandler<ApproveExerciseCommand, bool>
    {
        private readonly PowerLiftingContext _context;

        public ApproveExerciseCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ApproveExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercise.FirstOrDefaultAsync(x => x.ExerciseId == request.ExerciseId, cancellationToken: cancellationToken);

            if (exercise == null) throw new ExerciseNotFoundException();

            var userName = await _context.User.Where(x => x.Id == request.UserId && x.MemberStatusId >= 2) //user is a mod or admin
                .AsNoTracking()
                .Select(x => x.UserName)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (userName == null) throw new UnauthorisedUserException();

            exercise.IsApproved = true;
            exercise.AdminApprover = userName;

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
