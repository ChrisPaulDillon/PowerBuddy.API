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
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.MediatR.TemplatePrograms.Query.Account;
using PowerLifting.MediatR.TemplatePrograms.Query.Public;

namespace PowerLifting.MediatR.TemplatePrograms.QueryHandler.Account
{
    public class DoesUserHaveExerciseCollection1RMSetQueryHandler : IRequestHandler<DoesUserHaveExerciseCollection1RMSetQuery, IEnumerable<LiftingStatDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public DoesUserHaveExerciseCollection1RMSetQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LiftingStatDTO>> Handle(DoesUserHaveExerciseCollection1RMSetQuery request, CancellationToken cancellationToken)
        {
            var tec = _context.Set<TemplateExerciseCollection>().Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .AsNoTracking()
                .Select(x => x.ExerciseId)
                .ToList();

            var liftingStatsToCreate = await _context.LiftingStat.Where(x => x.RepRange == 1 && x.Weight == null && x.UserId == request.UserId &&
                tec.Any(j => j == x.ExerciseId))
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            //var liftingStats = await _context.LiftingStat.Where(x => x.UserId == request.UserId && x.RepRange == 1 && x.Weight != null)
            //    .AsNoTracking()
            //    .ToListAsync(cancellationToken: cancellationToken);

            //var liftingStatsToCreate = tec.Where(item1 => !liftingStats.Any(liftingStat => item1 != liftingStat.ExerciseId));

            return liftingStatsToCreate;
        }
    }
}