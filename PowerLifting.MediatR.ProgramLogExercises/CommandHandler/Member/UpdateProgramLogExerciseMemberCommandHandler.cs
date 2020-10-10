using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.LiftingStats.Command.Account;
using PowerLifting.MediatR.ProgramLogExercises.Command.Member;

namespace PowerLifting.MediatR.ProgramLogExercises.CommandHandler.Member
{
    public class UpdateProgramLogExerciseMemberCommandHandler : IRequestHandler<UpdateProgramLogExerciseMemberCommand, IEnumerable<LiftingStatDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateProgramLogExerciseMemberCommandHandler(PowerLiftingContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<LiftingStatDTO>> Handle(UpdateProgramLogExerciseMemberCommand request, CancellationToken cancellationToken)
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
            var existingWeightNewPbs = new List<LiftingStat>();
            var nonExistingWeightNewPbs = new List<LiftingStat>();

            foreach (var rep in noOfReps)
            {
                //Get the highest weight lifted for the given exercise and rep range
                var maxWeightLiftedInSet = repSchemes.Where(x => x.RepsCompleted == rep)
                    .MaxBy(x => x.WeightLifted).ToList();

                if (!maxWeightLiftedInSet.Any()) continue;

                var lsSpecificRep = await _context.LiftingStat
                    .FirstOrDefaultAsync(
                        x => x.RepRange == rep && x.ExerciseId == request.ProgramLogExerciseDTO.ExerciseId && x.UserId == request.UserId,
                        cancellationToken: cancellationToken);

                if (lsSpecificRep != null)
                {
                    if (maxWeightLiftedInSet[0].WeightLifted > lsSpecificRep.Weight ||
                        lsSpecificRep.Weight == null) //Pb was hit and lifting stat exists
                    {
                        lsSpecificRep.Weight = maxWeightLiftedInSet[0].WeightLifted;
                        lsSpecificRep.LastUpdated = DateTime.UtcNow;
                        existingWeightNewPbs.Add(lsSpecificRep);
                    }
                }
                else //Pb was hit, though no lifting stat exists for the current rep and exercise
                {
                    lsSpecificRep = new LiftingStat()
                    {
                        ExerciseId = request.ProgramLogExerciseDTO.ExerciseId,
                        Exercise = _mapper.Map<Exercise>(request.ProgramLogExerciseDTO.Exercise),
                        Weight = maxWeightLiftedInSet[0].WeightLifted,
                        RepRange = rep,
                        LastUpdated = DateTime.UtcNow,
                        UserId = request.UserId
                    };

                    nonExistingWeightNewPbs.Add(lsSpecificRep);
                    lsSpecificRep.Exercise = null;
                }
 
                var personalBestRepScheme = maxWeightLiftedInSet[0];
                personalBestRepScheme.PersonalBest = true;

                var index = repSchemes.FindIndex(a => a.ProgramLogRepSchemeId == personalBestRepScheme.ProgramLogRepSchemeId);
                repSchemes[index] = personalBestRepScheme; //replace the current program log rep scheme with the newly updated PB
            }

            if (existingWeightNewPbs.Any())
            {
                _context.LiftingStat.UpdateRange(existingWeightNewPbs);
            }

            if (nonExistingWeightNewPbs.Any())
            {
                _context.LiftingStat.AddRange(nonExistingWeightNewPbs);
            }

            request.ProgramLogExerciseDTO.ProgramLogRepSchemes = repSchemes;
            var programLogExercise = _mapper.Map<ProgramLogExercise>(request.ProgramLogExerciseDTO);
            programLogExercise.PersonalBest = true;

            _context.ProgramLogExercise.Update(programLogExercise);
            await _context.SaveChangesAsync(cancellationToken);

            var totalPersonalBests = new List<LiftingStatDTO>();
            if (existingWeightNewPbs.Any())
            {
                totalPersonalBests.AddRange(_mapper.Map<IEnumerable<LiftingStatDTO>>(existingWeightNewPbs));
            }
            if (nonExistingWeightNewPbs.Any())
            {
                totalPersonalBests.AddRange(_mapper.Map<IEnumerable<LiftingStatDTO>>(nonExistingWeightNewPbs));
            }

            //TODO Add lifting stat audit for all ls commands
            foreach (var liftingStat in totalPersonalBests)
            {
                await _mediator.Send(new CreateLiftingStatAuditCommand(liftingStat.LiftingStatId, liftingStat.ExerciseId, liftingStat.RepRange, (decimal)liftingStat.Weight, liftingStat.UserId), cancellationToken);
            }

            return totalPersonalBests;
        }
    }
}