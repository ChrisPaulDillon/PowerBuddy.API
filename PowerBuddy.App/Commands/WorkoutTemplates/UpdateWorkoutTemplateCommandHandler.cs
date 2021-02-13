using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Extensions.Validators;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.WorkoutTemplates;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.WorkoutTemplates
{
    public class UpdateWorkoutTemplateCommand : IRequest<bool>
    {
        public WorkoutTemplateDto WorkoutTemplateDto { get; }
        public string UserId { get; }

        public UpdateWorkoutTemplateCommand(WorkoutTemplateDto workoutTemplateDto, string userId)
        {
            WorkoutTemplateDto = workoutTemplateDto;
            UserId = userId;
        }
    }

    public class UpdateWorkoutTemplateCommandValidator : AbstractValidator<UpdateWorkoutTemplateCommand>
    {
        public UpdateWorkoutTemplateCommandValidator()
        {
            RuleFor(x => x.WorkoutTemplateDto.WorkoutName).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutTemplateDto.WorkoutTemplateId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).Must(x => x == null || x.Any()).WithMessage("'{PropertyName}' must have at least one exercise");
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).ValidWorkoutTemplateExerciseCollection();
        }
    }

    public class UpdateWorkoutTemplateCommandHandler : IRequestHandler<UpdateWorkoutTemplateCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateWorkoutTemplateCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateWorkoutTemplateCommand request, CancellationToken cancellationToken)
        {
            var workoutTemplate = await _context.WorkoutTemplate
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.WorkoutTemplateId == request.WorkoutTemplateDto.WorkoutTemplateId, cancellationToken: cancellationToken);

            if (workoutTemplate == null)
            {
                return false;
            }

            var doesNameAlreadyExists = await _context.WorkoutTemplate
                .AsNoTracking()
                .AnyAsync(x => x.WorkoutName.ToLower() == request.WorkoutTemplateDto.WorkoutName.ToLower() && 
                                x.UserId == request.UserId &&
                                x.WorkoutTemplateId != request.WorkoutTemplateDto.WorkoutTemplateId, cancellationToken: cancellationToken);

            if (doesNameAlreadyExists)
            {
                return false;
            }

            _mapper.Map(request.WorkoutTemplateDto, workoutTemplate);

            _context.WorkoutTemplate.Update(workoutTemplate);
            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

            return modifiedRows > 0;
        }
    }
}