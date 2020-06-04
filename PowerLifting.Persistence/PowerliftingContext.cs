using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Service.Users.Model;
using PowerLifting.Service.LiftingStatsAudit.Model;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.TemplatePrograms.Model;
using PowerLifting.Service.UserSettings.Model;
using PowerLifting.Service.SystemServices.TemplateDifficultys.Model;
using PowerLifting.Service.SystemServices.RepSchemeTypes.Model;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Entity.System.ExerciseMuscleGroups.Models;
using PowerLifting.Entity.System.ExerciseTypes.Models;
using PowerLifting.Entity.System.Exercises.Models;

namespace PowerLifting.Persistence
{
    public class PowerliftingContext : DbContext
    {
        public PowerliftingContext(DbContextOptions<PowerliftingContext> options) : base(options)
        {


        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
         //   => options.UseSqlite("Data Source=app.db");

        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseType> ExerciseType { get; set; }
        public DbSet<ExerciseMuscleGroup> ExerciseMuscleGroup { get; set; }
        public DbSet<TemplateDifficulty> TemplateDifficulty { get; set; }
        public DbSet<RepSchemeType> RepSchemeType { get; set; }

        public DbSet<ProgramLog> ProgramLog { get; set; }
        public DbSet<ProgramLogWeek> ProgramLogWeek { get; set; }
        public DbSet<ProgramLogDay> ProgramLogDay { get; set; }
        public DbSet<ProgramLogExercise> ProgramLogExercise { get; set; }
        public DbSet<ProgramLogRepScheme> ProgramLogRepScheme { get; set; }
        public DbSet<LiftingStat> LiftingStat{ get; set; }
        public DbSet<LiftingStatAudit> LiftingStatAudit { get; set; }
        public DbSet<TemplateProgram> TemplateProgram { get; set; }
        public DbSet<TemplateWeek> TemplateWeek { get; set; }
        public DbSet<TemplateDay> TemplateDay { get; set; }
        public DbSet<TemplateExercise> TemplateExercise { get; set; }
        public DbSet<TemplateRepScheme> TemplateRepScheme { get; set; }
        public DbSet<TemplateExerciseCollection> TemplateExerciseCollection { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<IdentityRole> Role { get; set; }
        public DbSet<IdentityUserClaim<string>> UserClaim { get; set; }
        public DbSet<IdentityUserRole<string>> UserRole { get; set; }
        public DbSet<IdentityUserToken<string>> UserToken { get; set; }
        public DbSet<UserSetting> UserSetting { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().HasAlternateKey(u => u.ExerciseName);
            modelBuilder.Entity<Exercise>().ToTable("sysExercise");
            modelBuilder.Entity<ExerciseType>().HasAlternateKey(e => e.ExerciseTypeName);
            modelBuilder.Entity<ExerciseType>().ToTable("sysExerciseType");
            modelBuilder.Entity<ExerciseMuscleGroup>().ToTable("sysExerciseMuscleGroup");
            modelBuilder.Entity<TemplateDifficulty>().ToTable("sysTemplateDifficulty");
            modelBuilder.Entity<RepSchemeType>().ToTable("sysRepSchemeType");

            modelBuilder.Entity<ProgramLog>().ToTable("ProgramLog");
            modelBuilder.Entity<ProgramLogWeek>().ToTable("ProgramLogWeek");
            modelBuilder.Entity<ProgramLogDay>().ToTable("ProgramLogDay");
            modelBuilder.Entity<ProgramLogExercise>().ToTable("ProgramLogExercise");
            modelBuilder.Entity<ProgramLogRepScheme>().ToTable("ProgramLogRepScheme");

            modelBuilder.Entity<LiftingStat>().ToTable("LiftingStat");
            modelBuilder.Entity<LiftingStatAudit>().ToTable("LiftingStatAudit");

            modelBuilder.Entity<TemplateProgram>().ToTable("TemplateProgram");
            modelBuilder.Entity<TemplateWeek>().ToTable("TemplateWeek");
            modelBuilder.Entity<TemplateDay>().ToTable("TemplateDay");
            modelBuilder.Entity<TemplateExercise>().ToTable("TemplateExercise");
            modelBuilder.Entity<TemplateRepScheme>().ToTable("TemplateRepScheme");
            modelBuilder.Entity<TemplateExerciseCollection>().ToTable("TemplateExerciseCollection");

            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);
            modelBuilder.Entity<User>().ToTable("IdentityUser");
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey().ToTable("IdentityUserRole");
            modelBuilder.Entity<IdentityRole>().ToTable("IdentityRole");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("IdentityUserClaim");
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey().ToTable("IdentityUserToken");
            modelBuilder.Entity<UserSetting>().ToTable("UserSetting");
        }
    }
}
