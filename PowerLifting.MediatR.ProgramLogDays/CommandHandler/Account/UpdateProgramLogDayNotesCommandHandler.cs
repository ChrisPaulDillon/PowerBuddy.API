using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogDays.Command.Account;

namespace PowerLifting.MediatR.ProgramLogDays.CommandHandler.Account
{
    public class UpdateProgramLogDayNotesCommandHandler : IRequestHandler<UpdateProgramLogDayNotesCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateProgramLogDayNotesCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProgramLogDayNotesCommand request, CancellationToken cancellationToken)
        {
            var programLogDay = await _context.ProgramLogDay
                .FirstOrDefaultAsync(x => x.ProgramLogDayId == request.ProgramLogDayId && x.UserId == request.UserId,
                    cancellationToken: cancellationToken);

            if (programLogDay == null) throw new ProgramLogDayNotFoundException();

            programLogDay.Comment = request.Notes;

            _context.ProgramLogDay.Update(programLogDay);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}