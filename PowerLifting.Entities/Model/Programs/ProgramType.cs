using PowerLifting.Entities.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Entities.Model.Programs
{
    public class ProgramType
    {
        public int ProgramTypeId { get; set; }
        public String Name { get; set; }

        public ICollection<ProgramExercise> ProgramExercises { get; set; }
        
    }
}
