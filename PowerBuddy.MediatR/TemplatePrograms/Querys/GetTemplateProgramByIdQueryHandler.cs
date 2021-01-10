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
using PowerBuddy.Data.Exceptions.TemplatePrograms;

namespace PowerBuddy.MediatR.TemplatePrograms.Querys
{
    public class GetTemplateProgramByIdQuery : IRequest<TemplateProgramExtendedDTO>
    {
        public int TemplateProgramId { get; }

        public GetTemplateProgramByIdQuery(int templateProgramId)
        {
            TemplateProgramId = templateProgramId;
            new GetTemplateProgramByIdQueryValidator().ValidateAndThrow(this);
        }
    }

    internal class GetTemplateProgramByIdQueryValidator : AbstractValidator<GetTemplateProgramByIdQuery>
    {
        public GetTemplateProgramByIdQueryValidator()
        {
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class GetTemplateProgramByIdQueryHandler : IRequestHandler<GetTemplateProgramByIdQuery, TemplateProgramExtendedDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetTemplateProgramByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TemplateProgramExtendedDTO> Handle(GetTemplateProgramByIdQuery request, CancellationToken cancellationToken)
        {
            var templateProgram = await _context.TemplateProgram.AsNoTracking()
                .Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .ProjectTo<TemplateProgramExtendedDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (templateProgram == null) throw new TemplateProgramNotFoundException();
            return templateProgram;
        }
    }
}