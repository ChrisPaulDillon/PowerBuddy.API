using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Factories;
using PowerLifting.MediatR.ProgramLogs.Command.Account;
using PowerLifting.Service.ProgramLogs;
using PowerLifting.Service.ProgramLogs.Factories;
using PowerLifting.Service.ProgramLogs.Util;

namespace PowerLifting.MediatR.ProgramLogs.CommandHandler.Account
{
    public class CreateProgramLogFromScratchCommandHandler : IRequestHandler<CreateProgramLogFromScratchCommand, ProgramLog>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogService _programLogService;
        private readonly IDTOFactory _dtoFactory;
        public CreateProgramLogFromScratchCommandHandler(PowerLiftingContext context, IMapper mapper, IProgramLogService programLogService, IDTOFactory dtoFactory)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
            _dtoFactory = dtoFactory;
        }

        public async Task<ProgramLog> Handle(CreateProgramLogFromScratchCommand request, CancellationToken cancellationToken)
        {
            if (request.ProgramLogDTO.UserId != request.UserId) throw new UnauthorisedUserException();
            await _programLogService.IsProgramLogAlreadyActive(request.UserId);

            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            var startDate = request.ProgramLogDTO.StartDate;

            for (var i = 0; i < request.ProgramLogDTO.NoOfWeeks; i++)
            {
                var programLogWeek = _dtoFactory.CreateProgramLogWeekDTO(startDate, i + 1, request.UserId);

                //for (var j = 1; j < request.ProgramLogDTO.DayCount + 1; j++)
                //{
                //    var dayOfWeek = request.ProgramLogDTO.ProgramDayOrder[j];

                //    if (dayOfWeek == DayOfWeek.Monday.ToString())
                //    {
                //        var daysUntilSpecificDay = ((int)DayOfWeek.Monday - (int)startDate.DayOfWeek + 7) % 7;
                //        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                //        var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, request.UserId);
                //        programLogWeek.ProgramLogDays.Add(programLogDay);
                //    }
                //    else if (dayOfWeek == DayOfWeek.Tuesday.ToString())
                //    {
                //        var daysUntilSpecificDay = ((int)DayOfWeek.Tuesday - (int)startDate.DayOfWeek + 7) % 7;
                //        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                //        var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, request.UserId);
                //        programLogWeek.ProgramLogDays.Add(programLogDay);
                //    }
                //    else if (dayOfWeek == DayOfWeek.Wednesday.ToString())
                //    {
                //        var daysUntilSpecificDay = ((int)DayOfWeek.Wednesday - (int)startDate.DayOfWeek + 7) % 7;
                //        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                //        var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, request.UserId);
                //        programLogWeek.ProgramLogDays.Add(programLogDay);
                //    }
                //    else if (dayOfWeek == DayOfWeek.Thursday.ToString())
                //    {
                //        var daysUntilSpecificDay = ((int)DayOfWeek.Thursday - (int)startDate.DayOfWeek + 7) % 7;
                //        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                //        var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, request.UserId);
                //        programLogWeek.ProgramLogDays.Add(programLogDay);
                //    }
                //    else if (dayOfWeek == DayOfWeek.Friday.ToString())
                //    {
                //        var daysUntilSpecificDay = ((int)DayOfWeek.Friday - (int)startDate.DayOfWeek + 7) % 7;
                //        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                //        var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, request.UserId);
                //        programLogWeek.ProgramLogDays.Add(programLogDay);
                //    }
                //    else if (dayOfWeek == DayOfWeek.Saturday.ToString())
                //    {
                //        var daysUntilSpecificDay = ((int)DayOfWeek.Saturday - (int)startDate.DayOfWeek + 7) % 7;
                //        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                //        var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, request.UserId);
                //        programLogWeek.ProgramLogDays.Add(programLogDay);
                //    }
                //    else if (dayOfWeek == DayOfWeek.Sunday.ToString())
                //    {
                //        var daysUntilSpecificDay = ((int)DayOfWeek.Sunday - (int)startDate.DayOfWeek + 7) % 7;
                //        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                //        var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, request.UserId);
                //        programLogWeek.ProgramLogDays.Add(programLogDay);
                //    }
                //}
                startDate = startDate.AddDays(7);
                listOfProgramWeeks.Add(programLogWeek);
            }

            request.ProgramLogDTO.ProgramLogWeeks = listOfProgramWeeks;
            request.ProgramLogDTO.CustomName = "Custom Program";

            var programLogEntity = _mapper.Map<ProgramLog>(request.ProgramLogDTO);
            _context.ProgramLog.Add(programLogEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return programLogEntity;
        }
    }
}
