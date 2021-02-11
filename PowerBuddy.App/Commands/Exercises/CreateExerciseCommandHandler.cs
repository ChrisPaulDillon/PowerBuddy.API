using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Exercises;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Exercises;
using OneOf;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Exercises
{
    public class CreateExerciseCommand : IRequest<OneOf<ExerciseDto, ExerciseAlreadyExists>>
    {
        public CExerciseDto Exercise { get; }

        public CreateExerciseCommand(CExerciseDto exercise)
        {
            Exercise = exercise;
        }
    }

    public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
    {
        public CreateExerciseCommandValidator()
        {
            RuleFor(x => x.Exercise).NotNull().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, OneOf<ExerciseDto, ExerciseAlreadyExists>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<ExerciseDto, ExerciseAlreadyExists>> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var doesExist = await _context.Exercise
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseName == request.Exercise.ExerciseName, cancellationToken: cancellationToken);

            if (doesExist)
            {
                return new ExerciseAlreadyExists();
            }

            var exercise = _mapper.Map<Exercise>(request.Exercise);
            _context.Add(exercise);
            await _context.SaveChangesAsync(cancellationToken);

            var exerciseDto = _mapper.Map<ExerciseDto>(exercise);
            return exerciseDto;
        }
    }
}
