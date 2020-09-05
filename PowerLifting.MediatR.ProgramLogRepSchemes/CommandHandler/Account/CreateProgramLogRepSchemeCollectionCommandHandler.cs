using System;
using System.Collections.Generic;
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
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogRepSchemes.Command.Account;

namespace PowerLifting.MediatR.ProgramLogRepSchemes.CommandHandler.Account
{
    public class CreateProgramLogRepSchemeCollectionCommandHandler : IRequestHandler<CreateProgramLogRepSchemeCollectionCommand, IEnumerable<ProgramLogRepSchemeDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateProgramLogRepSchemeCollectionCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogRepSchemeDTO>> Handle(CreateProgramLogRepSchemeCollectionCommand request, CancellationToken cancellationToken)
        {
            var programLogExercise = await _context.ProgramLogExercise
                .FirstOrDefaultAsync(x => x.ProgramLogExerciseId == request.RepSchemeCollectionDTO[0].ProgramLogExerciseId, cancellationToken: cancellationToken);

            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            var isUserAuthorized = await _context.ProgramLogDay
                .AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == programLogExercise.ProgramLogDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (!isUserAuthorized) throw new UnauthorisedUserException();

            var repSchemeCollection = _mapper.Map<IList<ProgramLogRepScheme>>(request.RepSchemeCollectionDTO);
            programLogExercise.NoOfSets += repSchemeCollection.Count;

            _context.AddRange(repSchemeCollection);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProgramLogRepSchemeDTO>>(repSchemeCollection);
        }
    }
}
