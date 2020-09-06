using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Common.Util;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogs.Command.Account;

namespace PowerLifting.MediatR.ProgramLogs.CommandHandler.Account
{
    public class CreateProgramLogFromScratchCommandHandler : IRequestHandler<CreateProgramLogFromScratchCommand, ProgramLog>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateProgramLogFromScratchCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLog> Handle(CreateProgramLogFromScratchCommand request, CancellationToken cancellationToken)
        {
            if (request.ProgramLogDTO.UserId != request.UserId) throw new UnauthorisedUserException();

            var doesExist = await _context.Set<ProgramLog>().AsNoTracking().AnyAsync(x => x.Active && x.UserId == request.UserId, cancellationToken: cancellationToken);
            if (doesExist) throw new ProgramLogAlreadyActiveException();

            request.ProgramLogDTO.ProgramDayOrder = ProgramLogHelper.CalculateDayOrder(request.ProgramLogDTO);
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            var startDate = request.ProgramLogDTO.StartDate;

            for (var i = 1; i < request.ProgramLogDTO.NoOfWeeks + 1; i++)
            {
                //ds.StartDate = ds.StartDate.AddDays(7);
                var programLogWeek = new ProgramLogWeekDTO()
                {
                    StartDate = startDate,
                    EndDate = startDate.AddDays(7),
                    WeekNo = i,
                    UserId = request.UserId,
                    ProgramLogDays = new List<ProgramLogDayDTO>()
                };

                for (var j = 1; j < request.ProgramLogDTO.DayCount + 1; j++)
                {
                    var dayOfWeek = request.ProgramLogDTO.ProgramDayOrder[j];

                    if (dayOfWeek == DayOfWeek.Monday.ToString())
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Monday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (dayOfWeek == DayOfWeek.Tuesday.ToString())
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Tuesday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (dayOfWeek == DayOfWeek.Wednesday.ToString())
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Wednesday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (dayOfWeek == DayOfWeek.Thursday.ToString())
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Thursday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (dayOfWeek == DayOfWeek.Friday.ToString())
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Friday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (dayOfWeek == DayOfWeek.Saturday.ToString())
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Saturday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (dayOfWeek == DayOfWeek.Sunday.ToString())
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Sunday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                }
                startDate = startDate.AddDays(7);
                listOfProgramWeeks.Add(programLogWeek);
            }

            request.ProgramLogDTO.ProgramLogWeeks = listOfProgramWeeks;
            request.ProgramLogDTO.CustomName = "Custom Program";
            request.ProgramLogDTO.EndDate =
                request.ProgramLogDTO.StartDate.AddDays(request.ProgramLogDTO.NoOfWeeks * 7);

            var programLogEntity = _mapper.Map<ProgramLog>(request.ProgramLogDTO);
            _context.ProgramLog.Add(programLogEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return programLogEntity;
        }
    }
}
