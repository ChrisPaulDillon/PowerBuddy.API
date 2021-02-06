using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Models.TemplatePrograms;

namespace PowerBuddy.App.Queries.TemplatePrograms
{
    public class GetTemplateProgramByIdQuery : IRequest<OneOf<TemplateProgramExtendedDto, TemplateProgramNotFound>>
    {
        public int TemplateProgramId { get; }

        public GetTemplateProgramByIdQuery(int templateProgramId)
        {
            TemplateProgramId = templateProgramId;
        }
    }

    public class GetTemplateProgramByIdQueryValidator : AbstractValidator<GetTemplateProgramByIdQuery>
    {
        public GetTemplateProgramByIdQueryValidator()
        {
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class GetTemplateProgramByIdQueryHandler : IRequestHandler<GetTemplateProgramByIdQuery, OneOf<TemplateProgramExtendedDto, TemplateProgramNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetTemplateProgramByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<TemplateProgramExtendedDto, TemplateProgramNotFound>> Handle(GetTemplateProgramByIdQuery request, CancellationToken cancellationToken)
        {
            var templateProgram = await _context.TemplateProgram.AsNoTracking()
                .Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .ProjectTo<TemplateProgramExtendedDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (templateProgram == null)
            {
                return new TemplateProgramNotFound();
            }

            return templateProgram;
        }
    }
}