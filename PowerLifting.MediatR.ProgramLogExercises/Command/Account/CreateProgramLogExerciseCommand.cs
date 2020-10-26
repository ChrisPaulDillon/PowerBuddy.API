using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogExercises.Command.Account
{
    public class CreateProgramLogExerciseCommand : IRequest<ProgramLogExerciseDTO>
    {
        public ProgramLogExerciseDTO ProgramLogExerciseDTO { get; }
        public string UserId { get; }

        public CreateProgramLogExerciseCommand(ProgramLogExerciseDTO programLogExerciseDTO, string userId)
        {
            ProgramLogExerciseDTO = programLogExerciseDTO;
            UserId = userId;
        }
    }
}
