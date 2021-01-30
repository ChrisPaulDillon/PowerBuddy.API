using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Exercises;

namespace PowerBuddy.MediatR.Queries.Exercises.Querys
{
    public class GetAllExerciseMuscleGroupsQuery : IRequest<IEnumerable<ExerciseMuscleGroupDTO>>
    {
 
    }

    internal class GetAllExerciseMuscleGroupsQueryHandler : IRequestHandler<GetAllExerciseMuscleGroupsQuery, IEnumerable<ExerciseMuscleGroupDTO>>
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
            return await _context.ExerciseMuscleGroup
                .AsNoTracking()
                .ProjectTo<ExerciseMuscleGroupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
