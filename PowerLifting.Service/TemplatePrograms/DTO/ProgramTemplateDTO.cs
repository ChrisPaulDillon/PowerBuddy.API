using System.Collections.Generic;
using Powerlifting.Service.TemplateExercises.DTO;

namespace Powerlifting.Service.TemplatePrograms.DTO
{
    public class TemplateProgramDTO
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public ICollection<TemplateExerciseDTO> TemplateExercises { get; set; }
    }
}
