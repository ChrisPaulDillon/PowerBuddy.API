using System;
using System.Collections.Generic;

namespace PowerLifting.Entities.Model.Programs
{
    public class ProgramTemplate
    {
        public int ProgramTemplateId { get; set; }
        public String Name { get; set; }

        public ICollection<ProgramExercise> ProgramExercises { get; set; }
        
    }
}
