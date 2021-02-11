using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.TemplatePrograms
{
    public class CreateTemplateExerciseCollectionForTemplateCommand : IRequest<bool>
    {
        public int TemplateProgramId { get; }
        public string UserId { get; }

        public CreateTemplateExerciseCollectionForTemplateCommand(int templateProgramId, string userId)
        {
            TemplateProgramId = templateProgramId;
            UserId = userId;
        }
    }

    public class CreateTemplateExerciseCollectionForTemplateCommandValidator : AbstractValidator<CreateTemplateExerciseCollectionForTemplateCommand>
    {
        public CreateTemplateExerciseCollectionForTemplateCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
        }
    }

    public class CreateTemplateExerciseCollectionForTemplateCommandHandler : IRequestHandler<CreateTemplateExerciseCollectionForTemplateCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateTemplateExerciseCollectionForTemplateCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateTemplateExerciseCollectionForTemplateCommand request, CancellationToken cancellationToken)
        {
            var exercisesAlreadyExist = await _context.TemplateExerciseCollection.AsNoTracking().AnyAsync(x => x.TemplateProgramId == request.TemplateProgramId, cancellationToken: cancellationToken);

            if (exercisesAlreadyExist) return false;

            var templateProgram = await _context.TemplateProgram.ProjectTo<TemplateProgramExtendedDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.TemplateProgramId == request.TemplateProgramId, cancellationToken: cancellationToken);

            var exercisesToAdd = new List<int>();
            foreach (var week in templateProgram.TemplateWeeks)
            {
                foreach (var day in week.TemplateDays)
                {
                    foreach (var exercise in day.TemplateExercises)
                    {
                        if (!exercisesToAdd.Contains(exercise.ExerciseId))
                        {
                            exercisesToAdd.Add(exercise.ExerciseId);
                        }
                    }
                }
            }

            var templateExerciseCollections = exercisesToAdd.Select(exerciseId => new TemplateExerciseCollection() { ExerciseId = exerciseId, TemplateProgramId = request.TemplateProgramId }).ToList();

            _context.TemplateExerciseCollection.AddRange(templateExerciseCollections);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}