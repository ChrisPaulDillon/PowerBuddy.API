using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Templates;

namespace PowerBuddy.MediatR.TemplatePrograms.Querys.Public
{
    public class GetTemplateActivityFeedQuery : IRequest<IEnumerable<TemplateProgramAuditDTO>>
    {

    }

    public class GetTemplateActivityFeedQueryHandler : IRequestHandler<GetTemplateActivityFeedQuery, IEnumerable<TemplateProgramAuditDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetTemplateActivityFeedQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateProgramAuditDTO>> Handle(GetTemplateActivityFeedQuery request, CancellationToken cancellationToken)
        {
            return await _context.TemplateProgramAudit
                .AsNoTracking()
                .OrderByDescending(x => x.DateCreated)
                .Take(3)
                .ProjectTo<TemplateProgramAuditDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}