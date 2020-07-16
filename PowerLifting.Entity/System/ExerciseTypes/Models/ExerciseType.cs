using System.ComponentModel.DataAnnotations.Schema;

namespace PowerLifting.Entity.System.ExerciseTypes.Models
{
    public class ExerciseType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExerciseTypeId { get; set; }
        public string ExerciseTypeName { get; set; }
    }
}