using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Data.Factories;
using PowerBuddy.Services.LiftingStats;
using PowerBuddy.Services.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogDays.Commands.Member
{
    public class UpdateProgramLogDayMemberCommand : IRequest<IEnumerable<LiftingStatAuditDTO>>
    {
        public ProgramLogDayDTO ProgramLogDayDTO { get; }
        public string UserId { get; }

        public UpdateProgramLogDayMemberCommand(ProgramLogDayDTO programLogDayDTO, string userId)
        {
            ProgramLogDayDTO = programLogDayDTO;
            UserId = userId;
            new UpdateProgramLogDayMemberCommandValidator().ValidateAndThrow(this);
        }
    }

    public class UpdateProgramLogDayMemberCommandValidator : AbstractValidator<UpdateProgramLogDayMemberCommand>
    {
        public UpdateProgramLogDayMemberCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.ProgramLogDayDTO.Date).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.ProgramLogDayDTO.ProgramLogWeekId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class UpdateProgramLogDayMemberCommandHandler : IRequestHandler<UpdateProgramLogDayMemberCommand, IEnumerable<LiftingStatAuditDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogService _programLogService;
        private readonly ILiftingStatService _liftingStatService;
        private readonly IEntityFactory _entityFactory;

        public UpdateProgramLogDayMemberCommandHandler(PowerLiftingContext context, IMapper mapper, IProgramLogService programLogService, ILiftingStatService liftingStatService, IEntityFactory entityFactory)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
            _liftingStatService = liftingStatService;
            _entityFactory = entityFactory;
        }

        public async Task<IEnumerable<LiftingStatAuditDTO>> Handle(UpdateProgramLogDayMemberCommand request, CancellationToken cancellationToken)
        {
            var doesProgramLogDayExist = await _context.ProgramLogDay.AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == request.ProgramLogDayDTO.ProgramLogDayId, cancellationToken: cancellationToken);

            if (!doesProgramLogDayExist) throw new ProgramLogDayNotFoundException();

            var programLogDay = await _context.ProgramLogDay.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProgramLogDayId == request.ProgramLogDayDTO.ProgramLogDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (programLogDay == null) throw new UnauthorisedUserException();

            var programLogExercises = request.ProgramLogDayDTO.ProgramLogExercises;

            var totalPersonalBests = new List<LiftingStatAuditDTO>();
            var updatedProgramLogExercises = new List<ProgramLogExerciseDTO>();

            foreach (var programExercise in programLogExercises)
            {
                //Get the highest weight lifted for the given exercise and each rep

                var maxWeightRepSchemes = _programLogService.GetHighestWeightRepSchemeForEachRepFromCollection(programExercise.ProgramLogRepSchemes);

                var updatedRepSchemes = programExercise.ProgramLogRepSchemes.ToList(); //repSchemes to be updated

                foreach (var repScheme in maxWeightRepSchemes.Where(repScheme => repScheme.RepsCompleted != 0))
                {
                   // var liftingStatPb = await _liftingStatService.GetTopLiftingStatForRepRange((int)repScheme.RepsCompleted, programExercise.ExerciseId, request.UserId);
                   var liftingStatPb = new LiftingStatAuditDTO();
                    if (liftingStatPb != null) //Personal best exists
                    {
                        if (repScheme.WeightLifted <= liftingStatPb.Weight)
                        {
                            continue; //Personal best was higher than max weight
                        }
                    }

                    var hitPersonalBest = _entityFactory.CreateLiftingStatAudit(
                        programExercise.ExerciseId, 
                        (int)repScheme.RepsCompleted, 
                        repScheme.WeightLifted, 
                        request.ProgramLogDayDTO.Date, 
                       // repScheme.ProgramLogRepSchemeId, 
                        request.UserId);

                    _context.LiftingStatAudit.Add(hitPersonalBest);
                    await _context.SaveChangesAsync();

                    hitPersonalBest.Exercise = await _context.Exercise.AsNoTracking().FirstOrDefaultAsync(x => x.ExerciseId == programExercise.ExerciseId);
                    totalPersonalBests.Add(_mapper.Map<LiftingStatAuditDTO>(hitPersonalBest));
                    _context.Entry(hitPersonalBest.Exercise).State = EntityState.Detached;

                    repScheme.PersonalBest = true;
                    repScheme.NoOfReps = (int)repScheme.RepsCompleted;
                    repScheme.LiftingStatAuditId = hitPersonalBest.LiftingStatAuditId;

                    var index = updatedRepSchemes.FindIndex(a => a.ProgramLogRepSchemeId == repScheme.ProgramLogRepSchemeId);
                    updatedRepSchemes[index] = repScheme; //replace the current program log rep scheme with the newly updated PB
                }

                programExercise.ProgramLogRepSchemes = updatedRepSchemes;
                updatedProgramLogExercises.Add(programExercise);
            }

            request.ProgramLogDayDTO.ProgramLogExercises = updatedProgramLogExercises;

            _context.ProgramLogDay.Update(_mapper.Map<ProgramLogDay>(request.ProgramLogDayDTO));
            await _context.SaveChangesAsync(cancellationToken);

            return totalPersonalBests;
        }
    }
}