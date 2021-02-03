using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Exercises;
using OneOf;

namespace PowerBuddy.App.Commands.Exercises
{
    public class CreateExerciseCommand : IRequest<OneOf<ExerciseDTO, ExerciseAlreadyExists>>
    {
        public CExerciseDTO Exercise { get; }

        public CreateExerciseCommand(CExerciseDTO exercise)
        {
            Exercise = exercise;
        }
    }

    public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
    {
        public CreateExerciseCommandValidator()
        {
            RuleFor(x => x.Exercise).NotNull().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, OneOf<ExerciseDTO, ExerciseAlreadyExists>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<ExerciseDTO, ExerciseAlreadyExists>> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var doesExist = await _context.Exercise
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseName == request.Exercise.ExerciseName);

            if (doesExist)
            {
                return new ExerciseAlreadyExists();
            }

            var exercise = _mapper.Map<Exercise>(request.Exercise);
            _context.Add(exercise);
            await _context.SaveChangesAsync();

            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }
    }
}
