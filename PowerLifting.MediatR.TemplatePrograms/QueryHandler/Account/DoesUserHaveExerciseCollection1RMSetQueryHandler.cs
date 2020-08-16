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
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.MediatR.TemplatePrograms.Query.Account;
using PowerLifting.MediatR.TemplatePrograms.Query.Public;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.TemplatePrograms.QueryHandler.Account
{
    public class DoesUserHaveExerciseCollection1RMSetQueryHandler : IRequestHandler<DoesUserHaveExerciseCollection1RMSetQuery, IEnumerable<int>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public DoesUserHaveExerciseCollection1RMSetQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<int>> Handle(DoesUserHaveExerciseCollection1RMSetQuery request, CancellationToken cancellationToken)
        {
            var tec = _context.Set<TemplateExerciseCollection>().Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .AsNoTracking()
                .Select(x => x.ExerciseId)
                .ToList();

            var liftingStats = await _context.LiftingStat.Where(x => x.UserId == request.UserId && x.RepRange == 1)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            var liftingStatsToCreate = tec.Where(item1 => liftingStats.All(item2 => item1 != item2.ExerciseId));

            return liftingStatsToCreate;
        }
    }
}