using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.TemplatePrograms;

namespace PowerLifting.MediatR.TemplatePrograms.Querys.Public
{
    public class GetTemplateProgramNameByIdQuery : IRequest<string>
    {
        public int TemplateProgramId { get; }
        public GetTemplateProgramNameByIdQuery(int templateProgramId)
        {
            TemplateProgramId = templateProgramId;
        }
    }

    public class GetTemplateProgramNameByIdQueryHandler : IRequestHandler<GetTemplateProgramNameByIdQuery, string>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetTemplateProgramNameByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(GetTemplateProgramNameByIdQuery request, CancellationToken cancellationToken)
        {
            var template = await _context.Set<TemplateProgram>().Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .Select(x => x.Name)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (string.IsNullOrEmpty(template)) throw new TemplateProgramNotFoundException();

            return template;
        }
    }
}