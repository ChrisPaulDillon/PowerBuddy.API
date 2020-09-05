using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogExercises.Command.Account;

namespace PowerLifting.MediatR.ProgramLogExercises.CommandHandler.Account
{
    public class CreateProgramLogExerciseAuditCommandHandler : IRequestHandler<CreateProgramLogExerciseAuditCommand, Unit>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateProgramLogExerciseAuditCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProgramLogExerciseAuditCommand request, CancellationToken cancellationToken)
        {
            var exerciseAudit = await _context.ProgramLogExerciseAudit
                .Where(x => x.UserId == request.UserId && x.ExerciseId == request.ExerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (exerciseAudit == null)
            {
                exerciseAudit = new ProgramLogExerciseAudit()
                {
                    ExerciseId = request.ExerciseId,
                    UserId = request.UserId,
                    SelectedCount = 1
                };
                _context.ProgramLogExerciseAudit.Add(exerciseAudit);
            }
            else
            {
                exerciseAudit.SelectedCount++;
            }
            return Unit.Value;
        }
    }
}