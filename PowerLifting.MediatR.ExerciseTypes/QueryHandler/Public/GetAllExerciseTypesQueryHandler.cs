using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.ExerciseTypes.Query.Public;

namespace PowerLifting.MediatR.ExerciseTypes.QueryHandler.Public
{
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
