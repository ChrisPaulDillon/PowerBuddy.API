using Microsoft.EntityFrameworkCore;
using Powerlifting.Service.Exercises.Model;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Service.ProgramExercises.Model;
using Powerlifting.Services.ExerciseCategories.Model;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramLogSets.Model;
using Powerlifting.Services.ProgramTemplates.Model;
using Powerlifting.Services.Users.Model;
using PowerLifting.ExerciseMarkups.Model;
using PowerLifting.Services.ProgramRepSchemes.Model;

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
        public DbSet<ProgramLogSet> ProgramLogSet { get; set; }
        public DbSet<LiftingStat> LiftingStat{ get; set; }
        public DbSet<ProgramLog> ProgramLog { get; set; }
        public DbSet<ProgramTemplate> ProgramTemplate { get; set; }
        public DbSet<ProgramExercise> ProgramExercise { get; set; }
        public DbSet<ProgramRepScheme> ProgramRepScheme { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().HasAlternateKey(u => u.ExerciseName);
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<ExerciseCategory>().HasAlternateKey(e => e.CategoryName);
            modelBuilder.Entity<ExerciseCategory>().ToTable("ExerciseCategory");
            modelBuilder.Entity<ExerciseMarkup>().ToTable("ExerciseMarkup");
            modelBuilder.Entity<ProgramLogSet>().ToTable("IndividualSet");
            modelBuilder.Entity<LiftingStat>().ToTable("ProgramLogSet");
            modelBuilder.Entity<ProgramLog>().ToTable("ProgramLog");
            modelBuilder.Entity<ProgramTemplate>().ToTable("ProgramTemplate");
            modelBuilder.Entity<ProgramExercise>().ToTable("ProgramExercise");
            modelBuilder.Entity<ProgramRepScheme>().ToTable("ProgramRepScheme");
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
