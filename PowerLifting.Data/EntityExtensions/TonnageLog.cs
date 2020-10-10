using System.Collections.Generic;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Entities
{
    public partial class TonnageLogExercise
    {
        public IEnumerable<TonnageWeekExercise> TonnageWeeks { get; set; }
        public IEnumerable<TonnageDayExercise> TonnageDays { get; set; }
    }
}
