using System;
using System.Collections.Generic;
using Powerlifting.Service.ProgramExercises.Model;

namespace Powerlifting.Services.ProgramTemplates
{
    public class ProgramTemplate
    {
        public int ProgramTemplateId { get; set; }
        public String Name { get; set; }
        public String Difficulty { get; set; }
        public int NoOfWeeks { get; set; }

        public ICollection<ProgramExercise> ProgramExercises { get; set; }
        
    }
}
