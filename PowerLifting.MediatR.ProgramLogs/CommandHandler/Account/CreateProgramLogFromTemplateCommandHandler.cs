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
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogs.Command.Account;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Service.Util;

namespace PowerLifting.MediatR.ProgramLogs.CommandHandler.Account
{
    public class CreateProgramLogFromTemplateCommandHandler : IRequestHandler<CreateProgramLogFromTemplateCommand, ProgramLog>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateProgramLogFromTemplateCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLog> Handle(CreateProgramLogFromTemplateCommand request, CancellationToken cancellationToken)
        {
            var doesExist = await _context.Set<ProgramLog>().AnyAsync(x => x.Active && x.UserId == request.UserId);
            if (doesExist) throw new ProgramLogAlreadyActiveException();

            request.ProgramLogDTO.ProgramDayOrder = ProgramLogHelper.CalculateDayOrder(request.ProgramLogDTO);

            var liftingStats = await _context.LiftingStat.Where(x => x.UserId == request.UserId && x.RepRange == 1).AsNoTracking().ToListAsync();

            var createdLog = new ProgramLogDTO
            {
                TemplateProgramId = request.TemplateProgramDTO.TemplateProgramId,
                UserId = request.UserId,
                Monday = request.ProgramLogDTO.Monday,
                Tuesday = request.ProgramLogDTO.Tuesday,
                Wednesday = request.ProgramLogDTO.Wednesday,
                Thursday = request.ProgramLogDTO.Thursday,
                Friday = request.ProgramLogDTO.Friday,
                Saturday = request.ProgramLogDTO.Saturday,
                Sunday = request.ProgramLogDTO.Sunday,
                StartDate = request.ProgramLogDTO.StartDate,
                EndDate = request.ProgramLogDTO.StartDate.AddDays(request.TemplateProgramDTO.NoOfWeeks * 7),
                NoOfWeeks = request.TemplateProgramDTO.NoOfWeeks,
                Active = true,
                ProgramLogWeeks = ProgramLogHelper.GenerateProgramWeekDates(request.ProgramLogDTO, request.TemplateProgramDTO, liftingStats, request.UserId)
            };

            var programLog = _mapper.Map<ProgramLog>(createdLog);
            _context.ProgramLog.Add(programLog);

            await _context.SaveChangesAsync(cancellationToken);
            return programLog;
        }
    }
}
