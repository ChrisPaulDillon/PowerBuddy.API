using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.Mediatr.Command.Exercises.Admin;
using PowerLifting.Mediatr.Command.Exercises.Public;
using PowerLifting.Persistence;

namespace PowerLifting.Mediatr.CommandHandler.Exercises.Admin
{
    public class ApproveExerciseCommandHandler : IRequestHandler<ApproveExerciseCommand, bool>
    {
        private readonly PowerLiftingContext _context;

        public ApproveExerciseCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ApproveExerciseCommand request, CancellationToken cancellationToken)
        {
            if (request.ExerciseId <= 0) throw new ExerciseValidationException("ExerciseId must be greater than zero");
            if (string.IsNullOrEmpty(request.UserId)) throw new UserValidationException("UserId cannot be null or invalid");

            var exercise = await _context.Exercise.FirstOrDefaultAsync(x => x.ExerciseId == request.ExerciseId);

            if (exercise == null) throw new ExerciseNotFoundException();

            var userName = await _context.User.Where(x => x.Id == request.UserId && x.Rights >= 1) //user is a mod or admin
                .AsNoTracking()
                .Select(x => x.UserName)
                .FirstOrDefaultAsync();

            if (userName == null) throw new UserNotFoundException();

            exercise.IsApproved = true;
            exercise.AdminApprover = userName;

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
