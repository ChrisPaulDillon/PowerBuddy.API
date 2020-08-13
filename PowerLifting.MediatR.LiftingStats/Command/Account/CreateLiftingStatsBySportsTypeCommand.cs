using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.MediatR.LiftingStats.Command.Account
{
    public class CreateLiftingStatsBySportsTypeCommand : IRequest<bool>
    {
        public string UserId { get; }
        public IEnumerable<TopLevelExerciseDTO> Exercises { get; }

        public CreateLiftingStatsBySportsTypeCommand(string userId, IEnumerable<TopLevelExerciseDTO> exercises)
        {
            UserId = userId;
            Exercises = exercises;
        }
    }
}