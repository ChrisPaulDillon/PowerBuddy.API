using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogs.Querys.Account
{
    public class GetActiveProgramLogByUserIdQuery : IRequest<ProgramLogDTO>
    {
        public string UserId { get; }

        public GetActiveProgramLogByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetActiveProgramLogByUserIdQueryHandler : IRequestHandler<GetActiveProgramLogByUserIdQuery, ProgramLogDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetActiveProgramLogByUserIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDTO> Handle(GetActiveProgramLogByUserIdQuery request, CancellationToken cancellationToken)
        {
            var programLogDTO = await _context.ProgramLog.Where(x => x.UserId == request.UserId)
                .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .OrderByDescending(x => x.StartDate)
                .ToListAsync(cancellationToken: cancellationToken);

            if (!programLogDTO.Any()) throw new ProgramLogNotFoundException();

            return programLogDTO[0];
        }
    }
}
