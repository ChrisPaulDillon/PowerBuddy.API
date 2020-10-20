using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Factories;
using PowerLifting.MediatR.ProgramLogDays.Command.Member;
using PowerLifting.Service.Tonnages;

namespace PowerLifting.MediatR.ProgramLogDays.CommandHandler.Member
{
    public class UpdateProgramLogDayMemberCommandHandler : IRequestHandler<UpdateProgramLogDayMemberCommand, IEnumerable<LiftingStatDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IEntityFactory _entityFactory;
        private readonly ITonnageService _tonnageService;

        public UpdateProgramLogDayMemberCommandHandler(PowerLiftingContext context, IMapper mapper, IEntityFactory entityFactory, ITonnageService tonnageService)
        {
            _context = context;
            _mapper = mapper;
            _entityFactory = entityFactory;
            _tonnageService = tonnageService;
        }

        public async Task<IEnumerable<LiftingStatDTO>> Handle(UpdateProgramLogDayMemberCommand request, CancellationToken cancellationToken)
        {
            var doesProgramLogDayExist = await _context.ProgramLogExercise.AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == request.ProgramLogDayDTO.ProgramLogDayId, cancellationToken: cancellationToken);

            var programLogId = await _context.ProgramLogWeek
                .AsNoTracking()
                .Where(x => x.ProgramLogWeekId == request.ProgramLogDayDTO.ProgramLogWeekId)
                .Select(x => x.ProgramLogId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (!doesProgramLogDayExist) throw new ProgramLogDayNotFoundException();

            var isUserAuthorized = await _context.ProgramLogDay.AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == request.ProgramLogDayDTO.ProgramLogDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (!isUserAuthorized) throw new UnauthorisedUserException();

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

                    totalPersonalBests.Add(_mapper.Map<LiftingStatDTO>(liftingStatPb));
                    repScheme.PersonalBest = true;
                    repScheme.NoOfReps = (int)repScheme.RepsCompleted;
                    programExercise.PersonalBest = true;

                    var index = updatedRepSchemes.FindIndex(a => a.ProgramLogRepSchemeId == repScheme.ProgramLogRepSchemeId);
                    updatedRepSchemes[index] = repScheme; //replace the current program log rep scheme with the newly updated PB
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