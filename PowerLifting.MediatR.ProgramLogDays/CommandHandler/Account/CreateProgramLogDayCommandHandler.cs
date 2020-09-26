using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogDays.Command.Account;

namespace PowerLifting.MediatR.ProgramLogDays.CommandHandler.Account
{
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
                .Select(x => new ProgramLogWeek()
                {
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();

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
