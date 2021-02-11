using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Templates;

namespace PowerBuddy.App.Queries.TemplatePrograms
{
    public class GetPersonalBestsForTemplateExercisesQuery : IRequest<IEnumerable<TemplateWeightInputDto>>
    {
        public int TemplateProgramId { get; }
        public string UserId { get; }
        public GetPersonalBestsForTemplateExercisesQuery(int templateProgramId, string userId)
        {
            TemplateProgramId = templateProgramId;
            UserId = userId;
        }
    }

    public class GetPersonalBestsForTemplateExercisesQueryValidator : AbstractValidator<GetPersonalBestsForTemplateExercisesQuery>
    {
        public GetPersonalBestsForTemplateExercisesQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class GetPersonalBestsForTemplateExercisesQueryHandler : IRequestHandler<GetPersonalBestsForTemplateExercisesQuery, IEnumerable<TemplateWeightInputDto>>
    {
        private readonly PowerLiftingContext _context;

        public GetPersonalBestsForTemplateExercisesQueryHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TemplateWeightInputDto>> Handle(GetPersonalBestsForTemplateExercisesQuery request, CancellationToken cancellationToken)
        {
            var tec = _context.TemplateExerciseCollection.Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .AsNoTracking()
                .Select(x => x.ExerciseId)
                .ToList();

            var templateWeightInput = new List<TemplateWeightInputDto>();

            foreach (var templateExercise in tec)
            {
                var weightInput = new TemplateWeightInputDto()
                {
                    ExerciseId = templateExercise,
                    ExerciseName = await _context.Exercise.AsNoTracking().Where(x => x.ExerciseId == templateExercise).Select(x => x.ExerciseName).FirstOrDefaultAsync(),
                    //Weight = personalBests.Where(x => x.ExerciseId == templateExercise).Select(x => x.Weight).FirstOrDefault() ?? 0
                };
                templateWeightInput.Add(weightInput);
            }
            return templateWeightInput;
        }
    }
}