﻿namespace PowerLifting.Data.Entities
{
    public class ProgramLogExerciseTonnage
    {
        public int ProgramLogExerciseTonnageId { get; set; }
        public int ProgramLogExerciseId { get; set; }
        public decimal ExerciseTonnage { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
    }
}
