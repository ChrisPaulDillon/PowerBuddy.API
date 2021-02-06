﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Exercises;

namespace PowerBuddy.App.Commands.Exercises
{
    public class UpdateExerciseCommand : IRequest<OneOf<bool, ExerciseNotFound>>
    {
        public ExerciseDTO Exercise { get; }
        public string UserId { get; }

        public UpdateExerciseCommand(ExerciseDTO exercise, string userId)
        {
            Exercise = exercise;
            UserId = userId;
        }
    }

    public class UpdateExerciseCommandValidator : AbstractValidator<UpdateExerciseCommand>
    {
        public UpdateExerciseCommandValidator()
        {
            RuleFor(x => x.Exercise).NotNull().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand, OneOf<bool, ExerciseNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public UpdateExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<bool, ExerciseNotFound>> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var doesExerciseExist = await _context.Exercise.AsNoTracking().AnyAsync(x => x.ExerciseId == request.Exercise.ExerciseId, cancellationToken: cancellationToken);

            if (!doesExerciseExist)
            {
                return new ExerciseNotFound();
            }

            var exercise = _mapper.Map<Exercise>(request.Exercise);
            _context.Exercise.Update(exercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
