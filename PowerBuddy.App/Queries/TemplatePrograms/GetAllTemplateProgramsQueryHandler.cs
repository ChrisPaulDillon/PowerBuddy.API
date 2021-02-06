using System.Collections.Generic;
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
    public class GetAllTemplateProgramsQuery : IRequest<IEnumerable<TemplateProgramDto>>
    {

    }

    public class GetAllTemplateProgramsQueryHandler : IRequestHandler<GetAllTemplateProgramsQuery, IEnumerable<TemplateProgramDto>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetAllTemplateProgramsQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateProgramDto>> Handle(GetAllTemplateProgramsQuery request, CancellationToken cancellationToken)
        {
            return await _context.TemplateProgram
                .AsNoTracking()
                .ProjectTo<TemplateProgramDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}