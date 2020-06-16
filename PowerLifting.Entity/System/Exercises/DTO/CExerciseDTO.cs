using System;
namespace PowerLifting.Entity.System.Exercises.DTO
{
    public class CExerciseDTO
    {
        public int ExerciseTypeId { get; set; }
        public string ExerciseName { get; set; }
        public bool IsProgrammable { get; set; } //Is this a main lift / can numbers be generated using this lift
    }
}
