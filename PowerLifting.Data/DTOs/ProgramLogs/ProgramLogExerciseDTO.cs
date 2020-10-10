﻿using System.Collections.Generic;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.DTOs.Tonnage;

namespace PowerLifting.Data.DTOs.ProgramLogs
{
    /// <summary>
    /// Represents a given lift, its sets, weight and reps lifted on a given day for that particular exercise.
    /// Always unique to the user as this will allow customisation
    /// </summary>
    public class ProgramLogExerciseDTO
    {
        public int ProgramLogExerciseId { get; set; }
        public int ProgramLogDayId { get; set; }
        public int ExerciseId { get; set; }
        public int NoOfSets { get; set; }
        public string Comment { get; set; }
        public bool Completed { get; set; }
        public bool? PersonalBest { get; set; }
        public int? TonnageDayExerciseId { get; set; }

        public TopLevelExerciseDTO Exercise { get; set; }
        public ICollection<ProgramLogRepSchemeDTO> ProgramLogRepSchemes { get; set; } //Stores the number of reps for each set
        public virtual TonnageDayExerciseDTO TonnageDayExercise { get; set; }
    }
}