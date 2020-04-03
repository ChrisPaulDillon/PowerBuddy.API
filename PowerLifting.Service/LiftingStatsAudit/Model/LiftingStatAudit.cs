using System;
namespace PowerLifting.Service.LiftingStatsAudit.Model
{
    /// <summary>
    /// Used to record when a user updates their lifting stats to show a timeline
    /// </summary>
    public class LiftingStatAudit
    {
       public int LiftingStatAuditId { get; set; }
       public string UserId { get; set; }
       public DateTime DateChange { get; set; }
       public string Squat { get; set; }
       public string Bench { get; set; }
       public string Deadlift { get; set; }
    }
}
