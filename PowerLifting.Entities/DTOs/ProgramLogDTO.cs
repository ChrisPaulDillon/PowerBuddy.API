﻿using System;
using System.Collections.Generic;
using PowerLifting.Entities.DTOs.Programs;

namespace PowerLifting.Entities.DTOs
{
    public class ProgramLogDTO
    {
        public int ProgramLogId { get; set; }
        public int ProgramTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfDaysLifting { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public virtual ProgramTypeDTO ProgramType { get; set; }
        public ICollection<ExerciseMarkupDTO> ExeciseMarkups { get; set; }

    }
}
