using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Services.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogRepSchemes.Commands.Account
{
    public class UpdateProgramLogRepSchemeCommand : IRequest<bool>
    {
        public ProgramLogRepSchemeDTO ProgramLogRepSchemeDTO { get; }
        public string UserId { get; }

        public UpdateProgramLogRepSchemeCommand(ProgramLogRepSchemeDTO programLogRepSchemeDTO, string userId)
        {
            ProgramLogRepSchemeDTO = programLogRepSchemeDTO;
            UserId = userId;
        }
    }

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
