using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogExercises.Command.Account;

namespace PowerLifting.MediatR.ProgramLogExercises.CommandHandler.Account
{
    public class UpdateProgramLogExerciseNotesCommandHandler : IRequestHandler<UpdateProgramLogExerciseNotesCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateProgramLogExerciseNotesCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProgramLogExerciseNotesCommand request, CancellationToken cancellationToken)
        {
            var programLogExercise = await _context.ProgramLogExercise.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProgramLogExerciseId == request.ProgramLogExerciseId,
                    cancellationToken: cancellationToken);

            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            var isUserAuthorized = await _context.ProgramLogDay.AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == programLogExercise.ProgramLogDayId && x.UserId == request.UserId,
                    cancellationToken: cancellationToken);

            if (!isUserAuthorized) throw new UnauthorisedUserException();

            programLogExercise.Comment = request.Notes;

            _context.ProgramLogExercise.Update(programLogExercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}