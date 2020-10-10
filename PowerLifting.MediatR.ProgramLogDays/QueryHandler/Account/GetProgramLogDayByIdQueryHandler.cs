using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogDays.Query.Account;

namespace PowerLifting.MediatR.ProgramLogDays.QueryHandler.Account
{
    public class GetProgramLogDayByIdQueryHandler : IRequestHandler<GetProgramLogDayByIdQuery, ProgramLogDayDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetProgramLogDayByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDayDTO> Handle(GetProgramLogDayByIdQuery request, CancellationToken cancellationToken)
        {
            var programLogDayDTO = await _context.Set<ProgramLogDay>().Where(x => x.ProgramLogDayId == request.ProgramLogDayId && x.UserId == request.UserId)
                .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }
    }
}
