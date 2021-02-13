using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Extensions.Validators;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.WorkoutTemplates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Workouts;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.WorkoutTemplates
{
    public class CreateWorkoutTemplateCommand : IRequest<OneOf<WorkoutTemplate, WorkoutNameAlreadyExists>>
    {
        public WorkoutTemplateDto WorkoutTemplateDto { get; }
        public string UserId { get; }

        public CreateWorkoutTemplateCommand(WorkoutTemplateDto workoutTemplateDto, string userId)
        {
            WorkoutTemplateDto = workoutTemplateDto;
            UserId = userId;
        }
    }

    public class CreateWorkoutTemplateCommandValidator : AbstractValidator<CreateWorkoutTemplateCommand>
    {
        public CreateWorkoutTemplateCommandValidator()
        {
            RuleFor(x => x.WorkoutTemplateDto.WorkoutName).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutTemplateDto.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).Must(x => x == null || x.Any()).WithMessage("'{PropertyName}' must have at least one exercise");
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).ValidWorkoutTemplateExerciseCollection();
        }
    }

    public class CreateWorkoutTemplateCommandHandler : IRequestHandler<CreateWorkoutTemplateCommand, OneOf<WorkoutTemplate, WorkoutNameAlreadyExists>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateWorkoutTemplateCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<WorkoutTemplate, WorkoutNameAlreadyExists>> Handle(CreateWorkoutTemplateCommand request, CancellationToken cancellationToken)
        {
            var doesNameExist = await _context.WorkoutTemplate
                .AsNoTracking()
                .AnyAsync(x => x.WorkoutName.ToLower() == request.WorkoutTemplateDto.WorkoutName.ToLower() &&
                    x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (doesNameExist)
            {
                return new WorkoutNameAlreadyExists();
            }

            var workoutTemplate = _mapper.Map<WorkoutTemplate>(request.WorkoutTemplateDto);

            await _context.WorkoutTemplate.AddAsync(workoutTemplate, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return workoutTemplate;
        }
    }
}