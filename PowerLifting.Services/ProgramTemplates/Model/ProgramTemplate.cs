using System.Collections.Generic;
using Powerlifting.Service.ProgramExercises.Model;

namespace Powerlifting.Services.ProgramTemplates.Model
{
    public class ProgramTemplate
    {
        public int ProgramTemplateId { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public ICollection<ProgramExercise> ProgramExercises { get; set; }
    }
}
