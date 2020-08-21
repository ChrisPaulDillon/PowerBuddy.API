using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogExercises.Command.Account;
using PowerLifting.MediatR.ProgramLogExercises.Command.Member;

namespace PowerLifting.MediatR.ProgramLogExercises.CommandHandler.Member
{
    public class UpdateProgramLogExerciseMemberCommandHandler : IRequestHandler<UpdateProgramLogExerciseMemberCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateProgramLogExerciseMemberCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProgramLogExerciseMemberCommand request, CancellationToken cancellationToken)
        {
            var doesProgramLogExerciseExist = await _context.ProgramLogExercise.AsNoTracking()
                .AnyAsync(x => x.ProgramLogExerciseId == request.ProgramLogExerciseDTO.ProgramLogExerciseId,
                    cancellationToken: cancellationToken);

            if (!doesProgramLogExerciseExist) throw new ProgramLogExerciseNotFoundException();

            var isUserAuthorized = await _context.ProgramLogDay.AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == request.ProgramLogExerciseDTO.ProgramLogDayId && x.UserId == request.UserId,
                    cancellationToken: cancellationToken);

            if (!isUserAuthorized) throw new UnauthorisedUserException();

            var noOfReps = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var repSchemes = request.ProgramLogExerciseDTO.ProgramLogRepSchemes.ToList();
            var weightsThatWillPb = new List<LiftingStat>();

            foreach (var rep in noOfReps)
            {
                //Get the highest weight lifted for the given exercise and rep range
                var maxWeightLiftedInSet = repSchemes.Where(x => x.NoOfReps == rep)
                    .MaxBy(x => x.WeightLifted).ToList();

                if(!maxWeightLiftedInSet.Any()) continue;
                
                var liftingStatExerciseWithRep = await _context.LiftingStat
                    .AsNoTracking().
                    FirstOrDefaultAsync(x => x.RepRange == rep, cancellationToken: cancellationToken);

                if (maxWeightLiftedInSet[0].WeightLifted > liftingStatExerciseWithRep.Weight || liftingStatExerciseWithRep.Weight == null)
                {
                    liftingStatExerciseWithRep.Weight = maxWeightLiftedInSet[0].WeightLifted;
                    liftingStatExerciseWithRep.LastUpdated = DateTime.UtcNow;
                    weightsThatWillPb.Add(liftingStatExerciseWithRep);

                    var personalBestRepScheme = maxWeightLiftedInSet[0];
                    personalBestRepScheme.PersonalBest = true;

                    var index = repSchemes.FindIndex(a => a.ProgramLogRepSchemeId == personalBestRepScheme.ProgramLogRepSchemeId);
                    repSchemes[index] = personalBestRepScheme; //replace the current program log rep scheme with the newly updated PB
                }
            }

            if (weightsThatWillPb.Any())
            {
                _context.LiftingStat.UpdateRange(weightsThatWillPb);
            }

            request.ProgramLogExerciseDTO.ProgramLogRepSchemes = repSchemes;
            var programLogExercise = _mapper.Map<ProgramLogExercise>(request.ProgramLogExerciseDTO);
            programLogExercise.PersonalBest = true;
            _context.ProgramLogExercise.Update(programLogExercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}