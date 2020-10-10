using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities;
using PowerLifting.MediatR.Exercises.Query.Public;

namespace PowerLifting.MediatR.Exercises.QueryHandler.Public
{
    public class GetAllExercisesQueryHandler : IRequestHandler<GetAllExercisesQuery, IEnumerable<ExerciseDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllExercisesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDTO>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Exercise
                .Where(x => x.IsApproved == true)
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
