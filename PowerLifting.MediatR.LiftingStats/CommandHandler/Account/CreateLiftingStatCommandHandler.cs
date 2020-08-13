using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Command.Account;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.LiftingStats.CommandHandler.Account
{
    public class CreateLiftingStatCommandHandler : IRequestHandler<CreateLiftingStatCommand, LiftingStatDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateLiftingStatCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LiftingStatDTO> Handle(CreateLiftingStatCommand request, CancellationToken cancellationToken)
        {
            var userId = request.LiftingStat.UserId;
            var repRange = request.LiftingStat.RepRange;

            var doesLiftingStatExist = await _context.LiftingStat.Where(x => x.UserId == userId && x.ExerciseId == request.LiftingStat.ExerciseId && x.RepRange == repRange)
                .AsNoTracking()
                .AnyAsync();

            if (doesLiftingStatExist) throw new LiftingStatAlreadyExistsException();

            var createdLiftingStat = new LiftingStat()
            {
                UserId = request.LiftingStat.UserId,
                ExerciseId = request.LiftingStat.ExerciseId,
                RepRange = request.LiftingStat.RepRange,
                Weight = request.LiftingStat.Weight,
                GoalWeight = request.LiftingStat.GoalWeight,
                PercentageToGoal = request.LiftingStat.GoalWeight != null ? (request.LiftingStat.Weight / request.LiftingStat.GoalWeight) * 100 : null,
                LastUpdated = request.LiftingStat.LastUpdated,
            };

            _context.Add(createdLiftingStat);

            createdLiftingStat.Exercise = new Exercise()
            {
                ExerciseId = request.LiftingStat.Exercise.ExerciseId,
                ExerciseName = request.LiftingStat.Exercise.ExerciseName
            };

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChanged = DateTime.UtcNow,
                RepRange = request.LiftingStat.RepRange,
                ExerciseId = request.LiftingStat.ExerciseId,
                UserId = request.LiftingStat.UserId,
            };
            //var createdAudit = await _repo.LiftingStatAudit.CreateLiftingStatAudit(liftingStatAudit);

            return request.LiftingStat;
        }
    }
}
