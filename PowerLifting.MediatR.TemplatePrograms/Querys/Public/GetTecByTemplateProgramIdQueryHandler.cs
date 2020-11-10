using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;

namespace PowerLifting.MediatR.TemplatePrograms.Querys.Public
{
    public class GetTecByTemplateProgramIdQuery : IRequest<IEnumerable<int>>
    {
        public int TemplateProgramId { get; }
        public GetTecByTemplateProgramIdQuery(int templateProgramId)
        {
            TemplateProgramId = templateProgramId;
        }
    }

    public class GetTecByTemplateProgramIdQueryHandler : IRequestHandler<GetTecByTemplateProgramIdQuery, IEnumerable<int>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetTecByTemplateProgramIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<int>> Handle(GetTecByTemplateProgramIdQuery request, CancellationToken cancellationToken)
        {
            return _context.TemplateExerciseCollection.Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .AsNoTracking()
                .Select(x => x.ExerciseId)
                .ToList();
        }
    }
}