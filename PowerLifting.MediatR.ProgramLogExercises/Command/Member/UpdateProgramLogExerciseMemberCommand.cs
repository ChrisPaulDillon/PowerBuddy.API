using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.LiftingStats;

namespace PowerLifting.MediatR.ProgramLogExercises.Command.Member
{
    public class UpdateProgramLogExerciseMemberCommand : IRequest<IEnumerable<LiftingStatDTO>>
    {
        public ProgramLogExerciseDTO ProgramLogExerciseDTO { get; }
        public string UserId { get; }

        public UpdateProgramLogExerciseMemberCommand(ProgramLogExerciseDTO programLogExerciseDTO, string userId)
        {
            ProgramLogExerciseDTO = programLogExerciseDTO;
            UserId = userId;
        }
    }
}