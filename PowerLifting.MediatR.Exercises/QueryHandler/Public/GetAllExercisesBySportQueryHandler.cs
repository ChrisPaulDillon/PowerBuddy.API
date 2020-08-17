using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.MediatR.Exercises.Query.Public;

namespace PowerLifting.MediatR.Exercises.QueryHandler.Public
{
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
            return await _context.Set<Exercise>()
                .Where(x => x.ExerciseSports.Any(j => j.ExerciseSportStr == request.ExerciseSport) && x.IsApproved)
                .ProjectTo<TopLevelExerciseDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
