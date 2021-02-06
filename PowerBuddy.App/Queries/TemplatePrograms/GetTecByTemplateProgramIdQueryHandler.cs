using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;

namespace PowerBuddy.App.Queries.TemplatePrograms
{
    public class GetTecByTemplateProgramIdQuery : IRequest<IEnumerable<int>>
    {
        public int TemplateProgramId { get; }
        public GetTecByTemplateProgramIdQuery(int templateProgramId)
        {
            TemplateProgramId = templateProgramId;
        }
    }

    public class GetTecByTemplateProgramIdQueryValidator : AbstractValidator<GetTecByTemplateProgramIdQuery>
    {
        public GetTecByTemplateProgramIdQueryValidator()
        {
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class GetTecByTemplateProgramIdQueryHandler : IRequestHandler<GetTecByTemplateProgramIdQuery, IEnumerable<int>>
    {
        private readonly PowerLiftingContext _context;

        public GetTecByTemplateProgramIdQueryHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<int>> Handle(GetTecByTemplateProgramIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.TemplateExerciseCollection.Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .AsNoTracking()
                .Select(x => x.ExerciseId)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}