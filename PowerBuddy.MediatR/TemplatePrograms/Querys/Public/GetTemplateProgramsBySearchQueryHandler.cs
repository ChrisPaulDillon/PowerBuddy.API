using System.Collections;
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

namespace PowerBuddy.MediatR.TemplatePrograms.Querys.Public
{
    public class GetTemplateProgramsBySearchQuery : IRequest<IEnumerable<TemplateKeyValuePairDTO>>
    {
        public string SearchTerm { get; }

        public GetTemplateProgramsBySearchQuery(string searchTerm)
        {
            SearchTerm = searchTerm;
            new GetTemplateProgramsBySearchQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetTemplateProgramsBySearchQueryValidator : AbstractValidator<GetTemplateProgramsBySearchQuery>
    {
        public GetTemplateProgramsBySearchQueryValidator()
        {
            RuleFor(x => x.SearchTerm).NotNull().NotEmpty().WithMessage("'{PropertyName}' must be greater not be empty");
        }
    }

    public class GetTemplateProgramsBySearchQueryHandler : IRequestHandler<GetTemplateProgramsBySearchQuery, IEnumerable<TemplateKeyValuePairDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetTemplateProgramsBySearchQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateKeyValuePairDTO>> Handle(GetTemplateProgramsBySearchQuery request, CancellationToken cancellationToken)
        {
            var searchResults = await _context.TemplateProgram.AsNoTracking()
                .Where(x => x.Name.ToLower().Contains(request.SearchTerm.ToLower()))
                .ProjectTo<TemplateKeyValuePairDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return searchResults;
        }
    }
}