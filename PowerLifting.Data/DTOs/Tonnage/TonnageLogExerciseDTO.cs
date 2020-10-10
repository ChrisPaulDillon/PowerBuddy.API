using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.DTOs.Tonnage
{
    public class TonnageLogExerciseDTO
    {
        public int TonnageLogExerciseId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogId { get; set; }
        public int ExerciseId { get; set; }
        public decimal TotalTonnage { get; set; }
    }
}
