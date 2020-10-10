﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogRepSchemes.Command.Account;

namespace PowerLifting.MediatR.ProgramLogRepSchemes.CommandHandler.Account
{
    public class DeleteProgramLogRepSchemeCommandHandler : IRequestHandler<DeleteProgramLogRepSchemeCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public DeleteProgramLogRepSchemeCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteProgramLogRepSchemeCommand request, CancellationToken cancellationToken)
        {
            var programLogRepScheme = await _context.Set<ProgramLogRepScheme>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProgramLogRepSchemeId == request.ProgramLogRepSchemeId,
                    cancellationToken: cancellationToken);

            if (programLogRepScheme == null) throw new ProgramLogRepSchemeNotFoundException();

            var programLogExercise = await _context.ProgramLogExercise
                .FirstOrDefaultAsync(x => x.ProgramLogExerciseId == programLogRepScheme.ProgramLogExerciseId, cancellationToken: cancellationToken);

            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            var isUserAuthorized = await _context.ProgramLogDay
                .AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == programLogExercise.ProgramLogDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (!isUserAuthorized) throw new UnauthorisedUserException();

            if (programLogExercise.NoOfSets == 1) //last set in exercise, delete the full exercise
            {
                _context.ProgramLogExercise.Remove(programLogExercise);
            }
            else
            {
                programLogExercise.NoOfSets--;
            }
  
            _context.ProgramLogRepScheme.Remove(programLogRepScheme);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
