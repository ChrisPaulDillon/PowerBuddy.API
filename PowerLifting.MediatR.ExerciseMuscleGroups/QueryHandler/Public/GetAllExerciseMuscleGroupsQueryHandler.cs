using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.ExerciseMuscleGroups.Query.Public;

namespace PowerLifting.MediatR.ExerciseMuscleGroups.QueryHandler.Public
{
    public class GetAllExerciseMuscleGroupsQueryHandler : IRequestHandler<GetAllExerciseMuscleGroupsQuery, IEnumerable<ExerciseMuscleGroupDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllExerciseMuscleGroupsQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseMuscleGroupDTO>> Handle(GetAllExerciseMuscleGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<ExerciseMuscleGroup>()
                .AsNoTracking()
                .ProjectTo<ExerciseMuscleGroupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
