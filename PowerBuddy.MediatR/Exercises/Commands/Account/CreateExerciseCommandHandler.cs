using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Exercises;

namespace PowerBuddy.MediatR.Exercises.Commands.Account
{
    public class CreateExerciseCommand : IRequest<ExerciseDTO>
    {
        public CExerciseDTO Exercise { get; }

        public CreateExerciseCommand(CExerciseDTO exercise)
        {
            Exercise = exercise;
        }
    }
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, ExerciseDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExerciseDTO> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var doesExist = await _context.Exercise
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseName == request.Exercise.ExerciseName);

            if (doesExist) throw new ExerciseAlreadyExistsException();

            var exercise = _mapper.Map<Exercise>(request.Exercise);
            _context.Add(exercise);
            await _context.SaveChangesAsync();

            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }
    }
}
