using System.Threading;
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
    public class UpdateProgramLogRepSchemeCommandHandler : IRequestHandler<UpdateProgramLogRepSchemeCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateProgramLogRepSchemeCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProgramLogRepSchemeCommand request, CancellationToken cancellationToken)
        {
            var doesRepSchemeExist = await _context.Set<ProgramLogRepScheme>()
                .AsNoTracking()
                .AnyAsync(x => x.ProgramLogRepSchemeId == request.ProgramLogRepSchemeDTO.ProgramLogRepSchemeId,
                    cancellationToken: cancellationToken);

            if (!doesRepSchemeExist) throw new ProgramLogRepSchemeNotFoundException();

            var programLogExercise = await _context.ProgramLogExercise
                .FirstOrDefaultAsync(x => x.ProgramLogExerciseId == request.ProgramLogRepSchemeDTO.ProgramLogExerciseId, cancellationToken: cancellationToken);

            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            var isUserAuthorized = await _context.ProgramLogDay
                .AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == programLogExercise.ProgramLogDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (!isUserAuthorized) throw new UnauthorisedUserException();

            var programLogRepScheme = _mapper.Map<ProgramLogRepScheme>(request.ProgramLogRepSchemeDTO);
            _context.ProgramLogRepScheme.Update(programLogRepScheme);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
