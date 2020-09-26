using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogDays.Command.Member;
using PowerLifting.Service.LiftingStats;

namespace PowerLifting.MediatR.ProgramLogDays.CommandHandler.Member
{
    public class UpdateProgramLogDayMemberCommandHandler : IRequestHandler<UpdateProgramLogDayMemberCommand, IEnumerable<LiftingStatDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly ILiftingStatService _lsService;


        public UpdateProgramLogDayMemberCommandHandler(PowerLiftingContext context, IMapper mapper, ILiftingStatService lsService)
        {
            _context = context;
            _mapper = mapper;
            _lsService = lsService;
        }

        public async Task<IEnumerable<LiftingStatDTO>> Handle(UpdateProgramLogDayMemberCommand request, CancellationToken cancellationToken)
        {
            var doesProgramLogDayExist = await _context.ProgramLogExercise.AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == request.ProgramLogDayDTO.ProgramLogDayId, cancellationToken: cancellationToken);

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
                var maxWeightRepSchemes = programExercise.ProgramLogRepSchemes.GroupBy(x => x.RepsCompleted)
                    .Select(g => g.OrderByDescending(x => x.WeightLifted).First()).ToList();

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
                        }
                        else
                        {
                            continue; //Personal best was higher than max weight lifted
                        }
                    }
                    else // Pb was hit, though no lifting stat exists for the current rep and exercise
                    {
                        liftingStatPb = new LiftingStat()
                        {
                            ExerciseId = programExercise.ExerciseId,
                            Exercise = _mapper.Map<Exercise>(programExercise.Exercise),
                            Weight = repScheme.WeightLifted,
                            RepRange = (int) repScheme.RepsCompleted,
                            LastUpdated = request.ProgramLogDayDTO.Date,
                            UserId = request.UserId
                        };
                    }

                    totalPersonalBests.Add(_mapper.Map<LiftingStatDTO>(liftingStatPb));
                    liftingStatPb.Exercise = null;
                    _context.LiftingStat.Add(liftingStatPb);

                    repScheme.PersonalBest = true;
                    repScheme.NoOfReps = (int)repScheme.RepsCompleted;
                    programExercise.PersonalBest = true;

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