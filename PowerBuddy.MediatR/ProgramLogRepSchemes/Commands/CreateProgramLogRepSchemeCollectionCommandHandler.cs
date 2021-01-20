using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Services.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogRepSchemes.Commands
{
    public class CreateProgramLogRepSchemeCollectionCommand : IRequest<IEnumerable<ProgramLogRepSchemeDTO>>
    {
        public IList<ProgramLogRepSchemeDTO> RepSchemeCollectionDTO { get; }
        public string UserId { get; }

        public CreateProgramLogRepSchemeCollectionCommand(IList<ProgramLogRepSchemeDTO> repSchemeDTOCollection, string userId)
        {
            RepSchemeCollectionDTO = repSchemeDTOCollection;
            UserId = userId;
            new CreateProgramLogRepSchemeCollectionCommandValidator().ValidateAndThrow(this);
        }
    }

    internal class CreateProgramLogRepSchemeCollectionCommandValidator : AbstractValidator<CreateProgramLogRepSchemeCollectionCommand>
    {
        public CreateProgramLogRepSchemeCollectionCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.RepSchemeCollectionDTO.Count).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class CreateProgramLogRepSchemeCollectionCommandHandler : IRequestHandler<CreateProgramLogRepSchemeCollectionCommand, IEnumerable<ProgramLogRepSchemeDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IProgramLogService _service;
        private readonly IMapper _mapper;

        public CreateProgramLogRepSchemeCollectionCommandHandler(PowerLiftingContext context, IProgramLogService service, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        public async Task<IEnumerable<ProgramLogRepSchemeDTO>> Handle(CreateProgramLogRepSchemeCollectionCommand request, CancellationToken cancellationToken)
        {
            var programLogExercise = await _context.ProgramLogExercise
                .Include(x => x.ProgramLogRepSchemes)
                .FirstOrDefaultAsync(x => x.ProgramLogExerciseId == request.RepSchemeCollectionDTO[0].ProgramLogExerciseId, cancellationToken: cancellationToken);

            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            var programLogDay = await _context.ProgramLogDay
                .FirstOrDefaultAsync(x => x.ProgramLogDayId == programLogExercise.ProgramLogDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (programLogDay == null) throw new UserNotFoundException();

            programLogDay.Completed = false;
            var repSchemeCollection = _mapper.Map<IList<ProgramLogRepScheme>>(request.RepSchemeCollectionDTO);
            programLogExercise.NoOfSets += repSchemeCollection.Count;

            var exerciseTonnage = await _service.UpdateExerciseTonnage(programLogExercise, request.UserId);
            programLogExercise.ProgramLogExerciseTonnageId = exerciseTonnage.ProgramLogExerciseTonnageId;

            _context.ProgramLogRepScheme.AddRange(repSchemeCollection);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProgramLogRepSchemeDTO>>(repSchemeCollection);
        }
    }
}
