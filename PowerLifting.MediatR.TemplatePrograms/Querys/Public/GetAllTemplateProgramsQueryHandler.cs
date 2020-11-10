using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;

namespace PowerLifting.MediatR.TemplatePrograms.Querys.Public
{
    public class GetAllTemplateProgramsQuery : IRequest<IEnumerable<TemplateProgramDTO>>
    {

    }

    public class GetAllTemplateProgramsQueryHandler : IRequestHandler<GetAllTemplateProgramsQuery, IEnumerable<TemplateProgramDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetAllTemplateProgramsQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateProgramDTO>> Handle(GetAllTemplateProgramsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<TemplateProgram>().AsNoTracking()
                .ProjectTo<TemplateProgramDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}