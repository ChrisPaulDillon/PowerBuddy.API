﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.Exercises.Command.Admin;

namespace PowerLifting.MediatR.Exercises.CommandHandler.Admin
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

            var exercise = await _context.Exercise.FirstOrDefaultAsync(x => x.ExerciseId == request.ExerciseId, cancellationToken: cancellationToken);

            if (exercise == null) throw new ExerciseNotFoundException();

            var userName = await _context.User.Where(x => x.Id == request.UserId && x.Rights >= 1) //user is a mod or admin
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