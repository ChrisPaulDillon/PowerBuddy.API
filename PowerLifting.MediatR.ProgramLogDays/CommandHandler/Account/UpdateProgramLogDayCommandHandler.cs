using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogDays.Command.Account;

namespace PowerLifting.MediatR.ProgramLogDays.CommandHandler.Account
{
    public class UpdateProgramLogDayCommandHandler : IRequestHandler<UpdateProgramLogDayCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateProgramLogDayCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProgramLogDayCommand request, CancellationToken cancellationToken)
        {
            if(request.ProgramLogDayDTO.UserId != request.UserId) throw new UnauthorisedUserException();

            var doesProgramLogDayExist = await _context.ProgramLogDay.AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == request.ProgramLogDayDTO.ProgramLogDayId && x.UserId == request.UserId,
                    cancellationToken: cancellationToken);

            if (!doesProgramLogDayExist) throw new ProgramLogDayNotFoundException();

            var programLogExercises = request.ProgramLogDayDTO.ProgramLogExercises.ToList();

            foreach (var programLogExercise in programLogExercises)
            {
                programLogExercise.Completed = true;
                programLogExercise.Exercise = null;
            }

            request.ProgramLogDayDTO.Completed = true;
            request.ProgramLogDayDTO.ProgramLogExercises = programLogExercises;

            var programLogDay = _mapper.Map<ProgramLogDay>(request.ProgramLogDayDTO);
            _context.ProgramLogDay.Update(programLogDay);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
