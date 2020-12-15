using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.System;

namespace PowerBuddy.MediatR.Exercises.Querys.Public
{
    public class GetAllExercisesBySportQuery : IRequest<IEnumerable<TopLevelExerciseDTO>>
    {
        public string ExerciseSport { get; }
        public GetAllExercisesBySportQuery(string exerciseSport)
        {
            ExerciseSport = exerciseSport;
        }
    }

    public class GetAllExercisesBySportQueryHandler : IRequestHandler<GetAllExercisesBySportQuery, IEnumerable<TopLevelExerciseDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllExercisesBySportQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TopLevelExerciseDTO>> Handle(GetAllExercisesBySportQuery request, CancellationToken cancellationToken)
        {
            return await _context.Exercise
                .Where(x => x.ExerciseSports.Any(j => j.ExerciseSportStr == request.ExerciseSport) && x.IsApproved)
                .ProjectTo<TopLevelExerciseDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
