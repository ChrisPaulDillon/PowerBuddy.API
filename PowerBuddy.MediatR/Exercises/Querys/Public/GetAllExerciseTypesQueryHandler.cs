using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.MediatR.Exercises.Querys.Public
{
    public class GetAllExerciseTypesQuery : IRequest<IEnumerable<ExerciseTypeDTO>>
    {
    }

    public class GetAllExerciseTypesQueryHandler : IRequestHandler<GetAllExerciseTypesQuery, IEnumerable<ExerciseTypeDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllExerciseTypesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseTypeDTO>> Handle(GetAllExerciseTypesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<ExerciseType>()
                .ProjectTo<ExerciseTypeDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
