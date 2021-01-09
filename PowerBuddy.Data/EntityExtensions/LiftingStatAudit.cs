namespace PowerBuddy.Data.Entities
{
    public partial class LiftingStatAudit
    {
        public virtual Exercise Exercise { get; set; }
        public virtual User User { get; set; }
        public virtual ProgramLogRepScheme ProgramLogRepScheme { get; set; }
        public virtual WorkoutSet WorkoutSet { get; set; }
    }
}
