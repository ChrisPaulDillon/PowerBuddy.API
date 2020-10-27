using System.Linq;
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
using PowerLifting.Service.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogRepSchemes.CommandHandler.Account
{
    public class DeleteProgramLogRepSchemeCommandHandler : IRequestHandler<DeleteProgramLogRepSchemeCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogService _programLogService;

        public DeleteProgramLogRepSchemeCommandHandler(PowerLiftingContext context, IMapper mapper, IProgramLogService programLogService)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
        }

        public async Task<bool> Handle(DeleteProgramLogRepSchemeCommand request, CancellationToken cancellationToken)
        {
            var programLogRepScheme = await _context.ProgramLogRepScheme
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProgramLogRepSchemeId == request.ProgramLogRepSchemeId, cancellationToken: cancellationToken);

            if (programLogRepScheme == null) throw new ProgramLogRepSchemeNotFoundException();

            var programLogExercise = await _context.ProgramLogExercise
                .Where(x => x.ProgramLogExerciseId == programLogRepScheme.ProgramLogExerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            var programLogDay = await _context.ProgramLogDay
                .Where(x => x.ProgramLogDayId == programLogExercise.ProgramLogDayId && x.UserId == request.UserId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogDay == null) throw new UnauthorisedUserException();

            programLogDay.Completed = false;

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

            
            // Update tonnage

            var programLogExerciseToUpdate = await _context.ProgramLogExercise
                .AsNoTracking()
                .Where(x => x.ProgramLogExerciseId == programLogExercise.ProgramLogExerciseId)
                .Include(x => x.ProgramLogRepSchemes)
                .FirstOrDefaultAsync();

            await _programLogService.UpdateExerciseTonnage(programLogExerciseToUpdate, request.UserId);

            return changedRows > 0;
        }
    }
}
