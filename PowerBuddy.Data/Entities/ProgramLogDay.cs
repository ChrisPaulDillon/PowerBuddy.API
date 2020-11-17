using System;

namespace PowerBuddy.Data.Entities
{
    public partial class ProgramLogDay
    {
        public int ProgramLogDayId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool? PersonalBest { get; set; }
        public bool Completed { get; set; }
    }
}