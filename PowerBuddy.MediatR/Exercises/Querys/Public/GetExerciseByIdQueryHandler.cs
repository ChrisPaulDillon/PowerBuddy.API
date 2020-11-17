using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.Exceptions.Exercises;

namespace PowerBuddy.MediatR.Exercises.Querys.Public
{
    public class GetExerciseByIdQuery : IRequest<ExerciseDTO>
    {
        public int ExerciseId { get; }

        public GetExerciseByIdQuery(int exerciseId)
        {
            ExerciseId = exerciseId;
        }
    }

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
