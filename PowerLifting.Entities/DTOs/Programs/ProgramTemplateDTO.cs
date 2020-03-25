using System;
using System.Collections.Generic;

namespace PowerLifting.Entities.DTOs.Programs
{
    public class ProgramTemplateDTO
    {
        public int ProgramTemplateId { get; set; }
        public String Name { get; set; }
        public ICollection<ProgramExerciseDTO> ProgramExercises { get; set; }
    }
}
