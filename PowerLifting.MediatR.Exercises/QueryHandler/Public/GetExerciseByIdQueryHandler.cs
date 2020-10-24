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
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.Exercises.Query.Public;

namespace PowerLifting.MediatR.Exercises.QueryHandler.Public
{
    public class GetExerciseByIdQueryHandler : IRequestHandler<GetExerciseByIdQuery, ExerciseDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetExerciseByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExerciseDTO> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseId == request.ExerciseId)
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (exercise == null) throw new ExerciseNotFoundException();

            return exercise;
        }
    }
}
