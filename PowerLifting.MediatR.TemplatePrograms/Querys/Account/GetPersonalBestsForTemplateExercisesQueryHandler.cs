using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;
using PowerLifting.MediatR.TemplatePrograms.Commands.Admin;

namespace PowerLifting.MediatR.TemplatePrograms.Querys.Account
{
    public class GetPersonalBestsForTemplateExercisesQuery : IRequest<IEnumerable<TemplateWeightInputDTO>>
    {
        public int TemplateProgramId { get; }
        public string UserId { get; }
        public GetPersonalBestsForTemplateExercisesQuery(int templateProgramId, string userId)
        {
            TemplateProgramId = templateProgramId;
            UserId = userId;
            new GetPersonalBestsForTemplateExercisesQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetPersonalBestsForTemplateExercisesQueryValidator : AbstractValidator<GetPersonalBestsForTemplateExercisesQuery>
    {
        public GetPersonalBestsForTemplateExercisesQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class GetPersonalBestsForTemplateExercisesQueryHandler : IRequestHandler<GetPersonalBestsForTemplateExercisesQuery, IEnumerable<TemplateWeightInputDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetPersonalBestsForTemplateExercisesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateWeightInputDTO>> Handle(GetPersonalBestsForTemplateExercisesQuery request, CancellationToken cancellationToken)
        {
            var tec = _context.Set<TemplateExerciseCollection>().Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .AsNoTracking()
                .Select(x => x.ExerciseId)
                .ToList();

            var personalBests = await _context.LiftingStat.Where(x => x.RepRange == 1 && x.Weight != null && x.UserId == request.UserId &&
                tec.Any(j => j == x.ExerciseId))
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            var templateWeightInput = new List<TemplateWeightInputDTO>();

            foreach (var templateExercise in tec)
            {
                var weightInput = new TemplateWeightInputDTO()
                {
                    ExerciseId = templateExercise,
                    ExerciseName = await _context.Exercise.AsNoTracking().Where(x => x.ExerciseId == templateExercise).Select(x => x.ExerciseName).FirstOrDefaultAsync(),
                    Weight = personalBests.Where(x => x.ExerciseId == templateExercise).Select(x => x.Weight).FirstOrDefault()
                };
                templateWeightInput.Add(weightInput);
            }
            return templateWeightInput;
        }
    }
}