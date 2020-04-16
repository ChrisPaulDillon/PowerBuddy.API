using System.Collections.Generic;
using Powerlifting.Service.TemplateExercises.Model;
using PowerLifting.Service.TemplateWeek.Model;

namespace Powerlifting.Service.TemplatePrograms.Model
{
    public class TemplateProgram
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public ICollection<TemplateWeek> TemplateWeeks { get; set; }
    }
}
