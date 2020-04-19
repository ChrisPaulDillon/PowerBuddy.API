﻿namespace PowerLifting.Service.ProgramLogs.Model
{
    /// <summary>
    /// Received by the client to determine what days the user will using for their log
    /// </summary>
    public class DaySelected
    {
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}

