using System;
using System.Collections.Generic;
using Powerlifting.Service.ProgramExercises.DTO;

namespace Powerlifting.Services.ProgramTemplates.DTO
{
    public class ProgramTemplateDTO
    {
        public int ProgramTemplateId { get; set; }
        public String Name { get; set; }
        public ICollection<ProgramExerciseDTO> ProgramExercises { get; set; }
    }
}
