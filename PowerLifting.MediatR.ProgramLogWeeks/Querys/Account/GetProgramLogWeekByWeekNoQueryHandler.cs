using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogWeeks.Querys.Account
{
    public class GetProgramLogWeekByWeekNoQuery : IRequest<ProgramLogWeekDTO>
    {
        public int ProgramLogId { get; }
        public int WeekNo { get; }

        public GetProgramLogWeekByWeekNoQuery(int programLogId, int weekNo)
        {
            ProgramLogId = programLogId;
            WeekNo = weekNo;
        }
    }

    public class GetProgramLogWeekByWeekNoQueryHandler : IRequestHandler<GetProgramLogWeekByWeekNoQuery, ProgramLogWeekDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetProgramLogWeekByWeekNoQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogWeekDTO> Handle(GetProgramLogWeekByWeekNoQuery request, CancellationToken cancellationToken)
        {
            var programLogWeek = await _context.ProgramLogWeek
                .AsNoTracking()
                .Where(x => x.ProgramLogId == request.ProgramLogId && x.WeekNo == request.WeekNo)
                .ProjectTo<ProgramLogWeekDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();
            return programLogWeek;
        }
    }
}

