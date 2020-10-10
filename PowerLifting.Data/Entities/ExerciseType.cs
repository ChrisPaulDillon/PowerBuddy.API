﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PowerLifting.Data.Entities
{
    public partial class ExerciseType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExerciseTypeId { get; set; }
        public string ExerciseTypeName { get; set; }
    }
}