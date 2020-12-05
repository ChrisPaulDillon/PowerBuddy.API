using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutTemplate
    {
        public IEnumerable<ProgramLogExercise> WorkoutExercises { get; set; }
    }
}
