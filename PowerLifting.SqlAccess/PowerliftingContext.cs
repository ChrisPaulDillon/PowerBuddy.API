using Microsoft.EntityFrameworkCore;
using PowerLifting.Entities.NetStandard.Entities;
using PowerLifting.Entities.NetStandard.Entities.Lookups;

namespace PowerLifting.SqlAccess
{
    public class PowerliftingContext : DbContext
    {
        public PowerliftingContext(DbContextOptions<PowerliftingContext> options) : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseMarkup> ExerciseMarkups { get; set; }
        public DbSet<IndividualSet> IndividualSets { get; set; }
        public DbSet<LiftingStats> LiftingStats { get; set; }
        public DbSet<ProgramLog> ProgramLogs { get; set; }
        public DbSet<ProgramType> ProgramTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().ToTable("Exercises");
            modelBuilder.Entity<ExerciseMarkup>().ToTable("ExerciseMarkups");
            modelBuilder.Entity<IndividualSet>().ToTable("IndividualSets");
            modelBuilder.Entity<LiftingStats>().ToTable("LiftingStats");
            modelBuilder.Entity<ProgramLog>().ToTable("ProgramLogs");
            modelBuilder.Entity<ProgramType>().ToTable("ProgramTypes");
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Username);
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
