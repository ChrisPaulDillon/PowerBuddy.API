using Microsoft.EntityFrameworkCore;
using Powerlifting.Service.Exercises.Model;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Services.ExerciseCategories.Model;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramLogRepSchemes.Model;
using Powerlifting.Services.TemplatePrograms.Model;
using Powerlifting.Services.TemplateExercises.Model;
using PowerLifting.ProgramLogExercises.Model;
using PowerLifting.Service.Users.Model;
using PowerLifting.Services.TemplateRepSchemes.Model;

namespace PowerLifting.Persistence
{
    public class PowerliftingContext : DbContext
    {
        public PowerliftingContext(DbContextOptions<PowerliftingContext> options) : base(options)
        {

        }

        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategory { get; set; }
        public DbSet<ProgramLogExercise> ProgramLogExercise { get; set; }
        public DbSet<ProgramLogRepScheme> ProgramLogRepScheme { get; set; }
        public DbSet<LiftingStat> LiftingStat{ get; set; }
        public DbSet<ProgramLog> ProgramLog { get; set; }
        public DbSet<TemplateProgram> TemplateProgram { get; set; }
        public DbSet<TemplateExercise> TemplateExercise { get; set; }
        public DbSet<TemplateRepScheme> TemplateRepScheme { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().HasAlternateKey(u => u.ExerciseName);
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<ExerciseCategory>().HasAlternateKey(e => e.CategoryName);
            modelBuilder.Entity<ExerciseCategory>().ToTable("ExerciseCategory");
            modelBuilder.Entity<ProgramLogExercise>().ToTable("ProgramLogExercise");
            modelBuilder.Entity<ProgramLogRepScheme>().ToTable("ProgramLogRepScheme");
            modelBuilder.Entity<LiftingStat>().ToTable("LiftingStat");
            modelBuilder.Entity<ProgramLog>().ToTable("ProgramLog");
            modelBuilder.Entity<TemplateProgram>().ToTable("TemplateProgram");
            modelBuilder.Entity<TemplateExercise>().ToTable("TemplateExercise");
            modelBuilder.Entity<TemplateRepScheme>().ToTable("TemplateRepScheme");
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email); //This is a unique value two emails can't have the same email
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
