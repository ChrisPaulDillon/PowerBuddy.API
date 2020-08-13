using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.Exercises.Command.Admin;
using PowerLifting.MediatR.Exercises.Query.Public;
using PowerLifting.Persistence;

namespace PowerLifting.Mediatr.QueryHandler.Exercises.Public
{
    public class GetExerciseByIdQueryHandler : IRequestHandler<GetExerciseByIdQuery, Exercise>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetExerciseByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Exercise> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.ExerciseId <= 0) throw new ExerciseValidationException("ExerciseId must be greater than zero");

            var exercise = await _context.Set<Exercise>()
                .Where(x => x.ExerciseId == request.ExerciseId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (exercise == null) throw new ExerciseNotFoundException();

            return exercise;
        }
    }
}
