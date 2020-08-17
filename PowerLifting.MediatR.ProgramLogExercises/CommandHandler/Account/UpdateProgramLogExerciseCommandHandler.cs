using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogExercises.Command.Account;

namespace PowerLifting.MediatR.ProgramLogExercises.CommandHandler.Account
{
    public class UpdateProgramLogExerciseCommandHandler : IRequestHandler<UpdateProgramLogExerciseCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateProgramLogExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProgramLogExerciseCommand request, CancellationToken cancellationToken)
        {
            var doesProgramLogExerciseExist = await _context.ProgramLogExercise.AsNoTracking()
                .AnyAsync(x => x.ProgramLogExerciseId == request.ProgramLogExerciseDTO.ProgramLogExerciseId,
                    cancellationToken: cancellationToken);

            if (!doesProgramLogExerciseExist) throw new ProgramLogExerciseNotFoundException();

            var isUserAuthorized = await _context.ProgramLogDay.AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == request.ProgramLogExerciseDTO.ProgramLogDayId && x.UserId == request.UserId, 
                            cancellationToken: cancellationToken);

            if (!isUserAuthorized) throw new UnauthorisedUserException();

            var programLogExercise = _mapper.Map<ProgramLogExercise>(request.ProgramLogExerciseDTO);
            _context.ProgramLogExercise.Update(programLogExercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
