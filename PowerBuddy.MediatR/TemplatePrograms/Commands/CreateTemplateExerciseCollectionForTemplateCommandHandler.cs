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
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.MediatR.TemplatePrograms.Commands
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
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class CreateTemplateExerciseCollectionForTemplateCommandHandler : IRequestHandler<CreateTemplateExerciseCollectionForTemplateCommand, bool>
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
            //var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2, cancellationToken: cancellationToken);

            //if (!isUserAdmin) throw new UserNotFoundException();

            var exercisesAlreadyExist = await _context.TemplateExerciseCollection.AsNoTracking().AnyAsync(x => x.TemplateProgramId == request.TemplateProgramId);

            if (exercisesAlreadyExist) return false;

            var templateProgram = await _context.TemplateProgram.ProjectTo<TemplateProgramExtendedDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.TemplateProgramId == request.TemplateProgramId, cancellationToken: cancellationToken);

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