namespace PowerBuddy.Data.Entities
{
    public partial class LiftingStatAudit
    {
        public Exercise Exercise { get; set; }
        public User User { get; set; }
        public LiftingStat LiftingStat { get; set; }
    }
}
