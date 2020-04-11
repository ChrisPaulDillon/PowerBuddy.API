using System.Collections.Generic;
using Powerlifting.Service.TemplateExercises.Model;

namespace Powerlifting.Service.TemplatePrograms.Model
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
