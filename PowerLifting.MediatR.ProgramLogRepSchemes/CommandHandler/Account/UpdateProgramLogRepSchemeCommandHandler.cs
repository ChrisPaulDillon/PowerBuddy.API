using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogRepSchemes.Command.Account;
using PowerLifting.Service.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogRepSchemes.CommandHandler.Account
{
    public class UpdateProgramLogRepSchemeCommandHandler : IRequestHandler<UpdateProgramLogRepSchemeCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogService _programLogService;

        public UpdateProgramLogRepSchemeCommandHandler(PowerLiftingContext context, IMapper mapper, IProgramLogService programLogService)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
        }

        public async Task<bool> Handle(UpdateProgramLogRepSchemeCommand request, CancellationToken cancellationToken)
        {
            var doesRepSchemeExist = await _context.Set<ProgramLogRepScheme>()
                .AsNoTracking()
                .AnyAsync(x => x.ProgramLogRepSchemeId == request.ProgramLogRepSchemeDTO.ProgramLogRepSchemeId, cancellationToken: cancellationToken);

            if (!doesRepSchemeExist) throw new ProgramLogRepSchemeNotFoundException();

            var programLogExercise = await _context.ProgramLogExercise
                .AsNoTracking()
                .Where(x => x.ProgramLogExerciseId == request.ProgramLogRepSchemeDTO.ProgramLogExerciseId)
                .Include(x => x.ProgramLogRepSchemes)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            var programLogDay = await _context.ProgramLogDay
                .FirstOrDefaultAsync(x => x.ProgramLogDayId == programLogExercise.ProgramLogDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (programLogDay == null) throw new UnauthorisedUserException();

            programLogDay.Completed = false;

            var programLogRepScheme = _mapper.Map<ProgramLogRepScheme>(request.ProgramLogRepSchemeDTO);
            _context.ProgramLogRepScheme.Update(programLogRepScheme);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);

            var programLogExerciseTonnageUpdate = await _context.ProgramLogExercise
                .AsNoTracking()
                .Include(x => x.ProgramLogRepSchemes)
                .FirstOrDefaultAsync(x => x.ProgramLogExerciseId == programLogExercise.ProgramLogExerciseId);

            await _programLogService.UpdateExerciseTonnage(programLogExerciseTonnageUpdate, request.UserId);
            return changedRows > 0;
        }
    }
}
