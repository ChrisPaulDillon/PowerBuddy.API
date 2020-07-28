using System.ComponentModel.DataAnnotations.Schema;

namespace PowerLifting.Data.Entities.Exercises
{
    public class ExerciseType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExerciseTypeId { get; set; }
        public string ExerciseTypeName { get; set; }
    }
}