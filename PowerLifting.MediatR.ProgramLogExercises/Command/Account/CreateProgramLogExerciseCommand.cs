using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogExercises.Command.Account
{
    public class CreateProgramLogExerciseCommand : IRequest<ProgramLogExerciseDTO>
    {
        public CProgramLogExerciseDTO ProgramLogExerciseDTO { get; }
        public string UserId { get; }

        public CreateProgramLogExerciseCommand(CProgramLogExerciseDTO programLogExerciseDTO, string userId)
        {
            ProgramLogExerciseDTO = programLogExerciseDTO;
            UserId = userId;
        }
    }
}
