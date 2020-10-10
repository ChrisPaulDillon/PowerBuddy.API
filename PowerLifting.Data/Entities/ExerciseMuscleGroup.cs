using System.ComponentModel.DataAnnotations.Schema;

namespace PowerLifting.Data.Entities
{
    /// <summary>
    /// Represents all exercise muscle groups that can be worked
    /// </summary>
    public partial class ExerciseMuscleGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExerciseMuscleGroupId { get; set; }
        public string ExerciseMuscleGroupName { get; set; }
        public string Region { get; set; }
    }
}
