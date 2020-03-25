using Microsoft.EntityFrameworkCore;
using PowerLifting.Entities.Model;
using PowerLifting.Entities.Model.Lookups;
using PowerLifting.Entities.Model.Programs;

namespace PowerLifting.Persistence
{
    public class PowerliftingContext : DbContext
    {
        public PowerliftingContext(DbContextOptions<PowerliftingContext> options) : base(options)
        {

        }

        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategory { get; set; }
        public DbSet<ExerciseMarkup> ExerciseMarkup { get; set; }
        public DbSet<IndividualSet> IndividualSet { get; set; }
        public DbSet<LiftingStat> LiftingStat{ get; set; }
        public DbSet<ProgramLog> ProgramLog { get; set; }
        public DbSet<ProgramTemplate> ProgramTemplate { get; set; }
        public DbSet<ProgramExercise> ProgramExercise { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().HasAlternateKey(u => u.ExerciseName);
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<ExerciseCategory>().HasAlternateKey(e => e.CategoryName);
            modelBuilder.Entity<ExerciseCategory>().ToTable("ExerciseCategory");
            modelBuilder.Entity<ExerciseMarkup>().ToTable("ExerciseMarkup");
            modelBuilder.Entity<IndividualSet>().ToTable("IndividualSet");
            modelBuilder.Entity<LiftingStat>().ToTable("LiftingStat");
            modelBuilder.Entity<ProgramLog>().ToTable("ProgramLog");
            modelBuilder.Entity<ProgramTemplate>().ToTable("ProgramTemplate");
            modelBuilder.Entity<ProgramExercise>().ToTable("ProgramExercise");

            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
