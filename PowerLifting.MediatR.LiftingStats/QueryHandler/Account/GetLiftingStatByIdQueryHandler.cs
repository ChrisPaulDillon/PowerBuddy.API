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
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Query.Account;
using PowerLifting.Service.ProgramLogs;

namespace PowerLifting.MediatR.LiftingStats.QueryHandler.Account
{
    public class GetLiftingStatByIdQueryHandler : IRequestHandler<GetLiftingStatByIdQuery, LiftingStatDetailedDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogService _programLogService;

        public GetLiftingStatByIdQueryHandler(PowerLiftingContext context, IMapper mapper, IProgramLogService programLogService)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
        }

        public async Task<LiftingStatDetailedDTO> Handle(GetLiftingStatByIdQuery request, CancellationToken cancellationToken)
        {
            var liftingStats = await _context.LiftingStat.Where(x => x.UserId == request.UserId && x.ExerciseId == request.ExerciseId)
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            var liftFeed = await _context.LiftingStatAudit.Where(x => x.UserId == request.UserId && x.ExerciseId == request.ExerciseId)
                .ProjectTo<LiftFeedDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            var lifetimeTonnage = await _programLogService.CalculateLifetimeTonnageForExercise(request.ExerciseId, request.UserId);

            var exerciseName = await _context.Exercise.AsNoTracking().Where(x => x.ExerciseId == request.ExerciseId).Select(x => x.ExerciseName).FirstOrDefaultAsync();

            if (liftingStats == null) throw new LiftingStatNotFoundException();

            var liftingStatDetailed = new LiftingStatDetailedDTO()
            {
                ExerciseName = exerciseName,
                LifeTimeTonnage = lifetimeTonnage,
                LiftingStats = liftingStats,
                LiftFeed = liftFeed
            };

            return liftingStatDetailed;
        }
    }
}
