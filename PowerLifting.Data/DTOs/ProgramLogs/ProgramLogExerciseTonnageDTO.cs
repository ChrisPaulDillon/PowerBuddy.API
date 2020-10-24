using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.DTOs.ProgramLogs
{
    public class ProgramLogExerciseTonnageDTO
    {
        public int ProgramLogExerciseTonnageId { get; set; }
        public int ProgramLogExerciseId { get; set; }
        public decimal ExerciseTonnage { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
    }
}
