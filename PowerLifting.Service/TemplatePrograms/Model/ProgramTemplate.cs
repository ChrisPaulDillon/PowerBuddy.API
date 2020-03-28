using System.Collections.Generic;
using Powerlifting.Services.TemplateExercises.Model;

namespace Powerlifting.Services.TemplatePrograms.Model
{
    public class TemplateProgram
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public ICollection<TemplateExercise> TemplateExercises { get; set; }
    }
}
