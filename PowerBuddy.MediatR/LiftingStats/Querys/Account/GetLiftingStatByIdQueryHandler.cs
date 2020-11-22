using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.Exceptions.LiftingStats;
using PowerBuddy.Services.LiftingStats;
using PowerBuddy.Services.ProgramLogs;

namespace PowerBuddy.MediatR.LiftingStats.Querys.Account
{
    public class GetLiftingStatByIdQuery : IRequest<LiftingStatDetailedDTO>
    {
        public int ExerciseId { get; set; }
        public string UserId { get; }

        public GetLiftingStatByIdQuery(int exerciseId, string userId)
        {
            ExerciseId = exerciseId;
            UserId = userId;
        }
    }
    public class GetLiftingStatByIdQueryHandler : IRequestHandler<GetLiftingStatByIdQuery, LiftingStatDetailedDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogService _programLogService;
        private readonly ILiftingStatService _liftingStatService;

        public GetLiftingStatByIdQueryHandler(PowerLiftingContext context, IMapper mapper, IProgramLogService programLogService, ILiftingStatService liftingStatService)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
            _liftingStatService = liftingStatService;
        }

        public async Task<LiftingStatDetailedDTO> Handle(GetLiftingStatByIdQuery request, CancellationToken cancellationToken)
        {
            //TODO FIX

            var liftingStats = await _liftingStatService.GetTopLiftingStatForExercise(request.ExerciseId, request.UserId);

            var liftingStatsMapped = _mapper.Map<IEnumerable<LiftingStatAuditDTO>>(liftingStats);

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
                LiftingStats = liftingStatsMapped,
                LiftFeed = liftFeed
            };

            return liftingStatDetailed;
        }
    }
}
