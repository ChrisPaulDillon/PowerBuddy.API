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
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogDays.Commands.Account
{
    public class CreateProgramLogDayCommand : IRequest<ProgramLogDayDTO>
    {
        public ProgramLogDayDTO ProgramLogDayDTO { get; }
        public string UserId { get; }

        public CreateProgramLogDayCommand(ProgramLogDayDTO programLogDayDTO, string userId)
        {
            ProgramLogDayDTO = programLogDayDTO;
            UserId = userId;
        }
    }

    public class CreateProgramLogDayCommandHandler : IRequestHandler<CreateProgramLogDayCommand, ProgramLogDayDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateProgramLogDayCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDayDTO> Handle(CreateProgramLogDayCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId != request.ProgramLogDayDTO.UserId) throw new UnauthorisedUserException();

            var programLogWeek = await _context.ProgramLogWeek.Where(x => x.ProgramLogWeekId == request.ProgramLogDayDTO.ProgramLogWeekId)
                .AsNoTracking()
                .ProjectTo<ProgramLogWeekDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();

            var hasDayOnDate = programLogWeek.ProgramLogDays.Any(x => x.Date.Date.CompareTo(request.ProgramLogDayDTO.Date) == 0);

            if (hasDayOnDate) throw new ProgramLogDayOnDateAlreadyActiveException();

            if (request.ProgramLogDayDTO.Date >= programLogWeek.StartDate.AddDays(-1) && request.ProgramLogDayDTO.Date <= programLogWeek.EndDate.AddDays(1))
            {
                var programLogDay = _mapper.Map<ProgramLogDay>(request.ProgramLogDayDTO);
                _context.ProgramLogDay.Add(programLogDay);

                await _context.SaveChangesAsync(cancellationToken);

                var mappedProgramLogDayDTO = _mapper.Map<ProgramLogDayDTO>(programLogDay);
                return mappedProgramLogDayDTO;
            }
            throw new ProgramLogDayNotWithinWeekException();
        }
    }
}
