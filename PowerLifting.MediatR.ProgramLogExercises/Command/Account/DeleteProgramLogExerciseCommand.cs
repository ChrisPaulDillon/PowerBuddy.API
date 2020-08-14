using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogExercises.Command.Account
{
    public class DeleteProgramLogExerciseCommand : IRequest<bool>
    {
        public int ProgramLogExerciseId { get; }
        public string UserId { get; }

        public DeleteProgramLogExerciseCommand(int programLogExerciseId, string userId)
        {
            ProgramLogExerciseId = programLogExerciseId;
            UserId = userId;
        }
    }
}