using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Factories;
using PowerLifting.MediatR.LiftingStats.Commands.Account;
using PowerLifting.MediatR.ProgramLogDays.Commands.Account;

namespace PowerLifting.MediatR.ProgramLogDays.Commands.Member
{
    public class UpdateProgramLogDayMemberCommand : IRequest<IEnumerable<LiftingStatDTO>>
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

    public class UpdateProgramLogDayMemberCommandHandler : IRequestHandler<UpdateProgramLogDayMemberCommand, IEnumerable<LiftingStatDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IEntityFactory _entityFactory;
        private readonly IMediator _mediator;

        public UpdateProgramLogDayMemberCommandHandler(PowerLiftingContext context, IMapper mapper, IEntityFactory entityFactory, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _entityFactory = entityFactory;
            _mediator = mediator;
        }

        public async Task<IEnumerable<LiftingStatDTO>> Handle(UpdateProgramLogDayMemberCommand request, CancellationToken cancellationToken)
        {
            var doesProgramLogDayExist = await _context.ProgramLogDay.AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == request.ProgramLogDayDTO.ProgramLogDayId, cancellationToken: cancellationToken);

            if (!doesProgramLogDayExist) throw new ProgramLogDayNotFoundException();

            var programLogDay = await _context.ProgramLogDay.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProgramLogDayId == request.ProgramLogDayDTO.ProgramLogDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (programLogDay == null) throw new UnauthorisedUserException();

            var programLogExercises = request.ProgramLogDayDTO.ProgramLogExercises;

            var totalPersonalBests = new List<LiftingStatDTO>();
            var updatedProgramLogExercises = new List<ProgramLogExerciseDTO>();

            foreach (var programExercise in programLogExercises)
            {
                if (programExercise.Completed) continue; //Exercise has already been evaluated for PBs

                //Get the highest weight lifted for the given exercise and each rep
                var maxWeightRepSchemes = programExercise.ProgramLogRepSchemes.GroupBy(x => x.RepsCompleted).Select(g => g.OrderByDescending(x => x.WeightLifted).First()).ToList();

                var updatedRepSchemes = programExercise.ProgramLogRepSchemes.ToList(); //repSchemes to be updated

                foreach (var repScheme in maxWeightRepSchemes.Where(repScheme => repScheme.RepsCompleted != 0))
                {
                    var liftingStatPb = await _context.LiftingStat
                        .FirstOrDefaultAsync(
                            x => x.RepRange == repScheme.RepsCompleted && x.ExerciseId == programExercise.ExerciseId && x.UserId == request.UserId, cancellationToken: cancellationToken);

                    if (liftingStatPb != null) //Personal best exists
                    {
                        if (repScheme.WeightLifted > liftingStatPb.Weight || liftingStatPb.Weight == null) //Pb was hit and lifting stat exists
                        {
                            liftingStatPb.Weight = repScheme.WeightLifted;
                            liftingStatPb.LastUpdated = request.ProgramLogDayDTO.Date;
                            _context.LiftingStat.Update(liftingStatPb);
                        }
                        else
                        {
                            continue; //Personal best was higher than max weight lifted
                        }
                    }
                    else // Pb was hit, though no lifting stat exists for the current rep and exercise
                    {
                        liftingStatPb = _entityFactory.CreateLiftingStat(programExercise.ExerciseId, repScheme.WeightLifted, (int)repScheme.RepsCompleted, request.UserId, request.ProgramLogDayDTO.Date);
                        _context.LiftingStat.Add(liftingStatPb);
                    }

                    liftingStatPb.Exercise = await _context.Exercise.AsNoTracking().FirstOrDefaultAsync(x => x.ExerciseId == programExercise.ExerciseId);
                    totalPersonalBests.Add(_mapper.Map<LiftingStatDTO>(liftingStatPb));
                    _context.Entry(liftingStatPb.Exercise).State = EntityState.Detached;

                    repScheme.PersonalBest = true;
                    repScheme.NoOfReps = (int)repScheme.RepsCompleted;
                    programExercise.PersonalBest = true;

                    var index = updatedRepSchemes.FindIndex(a => a.ProgramLogRepSchemeId == repScheme.ProgramLogRepSchemeId);
                    updatedRepSchemes[index] = repScheme; //replace the current program log rep scheme with the newly updated PB

                    await _mediator.Send(new CreateLiftingStatAuditCommand(liftingStatPb.LiftingStatId, programExercise.ExerciseId, liftingStatPb.RepRange, (decimal)liftingStatPb.Weight, request.UserId, programLogDay.Date), cancellationToken);
                }

                programExercise.ProgramLogRepSchemes = updatedRepSchemes;
                updatedProgramLogExercises.Add(programExercise);
            }

            //var dayTonnages = await _tonnageService.CreateTonnageBreakdownForDay(programLogId, request.ProgramLogDayDTO.ProgramLogDayId, request.UserId);

            request.ProgramLogDayDTO.ProgramLogExercises = updatedProgramLogExercises;

            _context.ProgramLogDay.Update(_mapper.Map<ProgramLogDay>(request.ProgramLogDayDTO));
            await _context.SaveChangesAsync(cancellationToken);

            return totalPersonalBests;
        }
    }
}