using System;
using System.Collections.Generic;
using Powerlifting.Service.ProgramExercises.DTO;

namespace Powerlifting.Services.ProgramTemplates.DTO
{
    //Used for showing all program templates as a general overview
    public class TopLevelProgramTemplateDTO
    {
        public int ProgramTemplateId { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
    }
}
