using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Templates;

namespace PowerBuddy.App.Queries.TemplatePrograms
{
    public class GetTemplateActivityFeedQuery : IRequest<IEnumerable<TemplateProgramAuditDto>>
    {

    }

    internal class GetTemplateActivityFeedQueryHandler : IRequestHandler<GetTemplateActivityFeedQuery, IEnumerable<TemplateProgramAuditDto>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetTemplateActivityFeedQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateProgramAuditDto>> Handle(GetTemplateActivityFeedQuery request, CancellationToken cancellationToken)
        {
            return await _context.TemplateProgramAudit
                .AsNoTracking()
                .OrderByDescending(x => x.DateCreated)
                .Take(7)
                .ProjectTo<TemplateProgramAuditDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}