using System;

namespace PowerLifting.Data.Entities
{
    /// <summary>
    /// ProgramLog details information based on that specific weightlifting cycle
    /// Such as start, end date, the type of program and the days of the week the user is doing it
    /// </summary>
    public partial class ProgramLog
    {
        public int ProgramLogId { get; set; }
        public string CustomName { get; set; }
        public string UserId { get; set; }
        public int? TemplateProgramId { get; set; }
        public int NoOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}