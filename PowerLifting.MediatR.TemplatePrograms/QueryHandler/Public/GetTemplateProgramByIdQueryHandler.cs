using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.MediatR.TemplatePrograms.Query.Public;

namespace PowerLifting.MediatR.TemplatePrograms.QueryHandler.Public
{
    public class GetTemplateProgramByIdQueryHandler : IRequestHandler<GetTemplateProgramByIdQuery, TemplateProgramDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetTemplateProgramByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TemplateProgramDTO> Handle(GetTemplateProgramByIdQuery request, CancellationToken cancellationToken)
        {
            var templateProgram = await _context.Set<TemplateProgram>().AsNoTracking()
                .Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .ProjectTo<TemplateProgramDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (templateProgram == null) throw new TemplateProgramNotFoundException();
            return templateProgram;
        }
    }
}