using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Context
{
    public class PowerLiftingContext : DbContext
    {
        public PowerLiftingContext(DbContextOptions<PowerLiftingContext> options) : base(options)
        {


        }

        //System
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseType> ExerciseType { get; set; }
        public DbSet<ExerciseMuscleGroupAssoc> ExerciseMuscleGroupAssoc { get; set; }
        public DbSet<ExerciseMuscleGroup> ExerciseMuscleGroup { get; set; }
        public DbSet<ExerciseSport> ExerciseSport { get; set; }
        public DbSet<TemplateDifficulty> TemplateDifficulty { get; set; }
        public DbSet<RepSchemeType> RepSchemeType { get; set; }
        public DbSet<Quote> Quote { get; set; }

        public DbSet<WorkoutLog> WorkoutLog { get; set; }
        public DbSet<WorkoutDay> WorkoutDay { get; set; }
        public DbSet<WorkoutExerciseAudit> WorkoutExerciseAudit { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercise { get; set; }
        public DbSet<WorkoutExerciseTonnage> WorkoutExerciseTonnage { get; set; }
        public DbSet<WorkoutSet> WorkoutSet { get; set; }
        public DbSet<WorkoutTemplate> WorkoutTemplate { get; set; }

        //Lifting Stats
        public DbSet<LiftingStatAudit> LiftingStatAudit { get; set; }
        public DbSet<TemplateProgram> TemplateProgram { get; set; }
        public DbSet<TemplateProgramAudit> TemplateProgramAudit { get; set; }
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
        public DbSet<RefreshToken> RefreshToken { get; set; }

        //System
        public DbSet<Gender> Gender { get; set; }
        public DbSet<MemberStatus> MemberStatus { get; set; }
        public DbSet<LiftingLevel> LiftingLevel { get; set; }
        public DbSet<EmailTemplate> EmailTemplate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //System
            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<MemberStatus>().ToTable("MemberStatus");
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey().ToTable("IdentityUserRole");
            modelBuilder.Entity<IdentityRole>().ToTable("IdentityRole");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("IdentityUserClaim");
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey().ToTable("IdentityUserToken");
            modelBuilder.Entity<User>().ToTable("IdentityUser");
            modelBuilder.Entity<UserSetting>().ToTable("UserSetting");
            modelBuilder.Entity<RefreshToken>().ToTable("RefreshTokens");

            modelBuilder.Entity<Exercise>().HasAlternateKey(u => u.ExerciseName);
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<ExerciseType>().HasAlternateKey(e => e.ExerciseTypeName);
            modelBuilder.Entity<ExerciseType>().ToTable("ExerciseType");
            modelBuilder.Entity<ExerciseSport>().ToTable("ExerciseSport");
            modelBuilder.Entity<ExerciseMuscleGroupAssoc>().ToTable("ExerciseMuscleGroupAssoc");
            modelBuilder.Entity<ExerciseMuscleGroup>().ToTable("ExerciseMuscleGroup");
            modelBuilder.Entity<TemplateDifficulty>().ToTable("TemplateDifficulty");
            modelBuilder.Entity<RepSchemeType>().ToTable("RepSchemeType");
            modelBuilder.Entity<Quote>().ToTable("Quote");
            modelBuilder.Entity<LiftingLevel>().ToTable("LiftingLevel");
            modelBuilder.Entity<EmailTemplate>().ToTable("EmailTemplate");

            modelBuilder.Entity<WorkoutLog>().ToTable("WorkoutLog");
            modelBuilder.Entity<WorkoutDay>().ToTable("WorkoutDay");
            modelBuilder.Entity<WorkoutExercise>().ToTable("WorkoutExercise");
            modelBuilder.Entity<WorkoutExerciseTonnage>().ToTable("WorkoutExerciseTonnage");
            modelBuilder.Entity<WorkoutExerciseAudit>().ToTable("WorkoutExerciseAudit");
            modelBuilder.Entity<WorkoutSet>().ToTable("WorkoutSet");
            modelBuilder.Entity<WorkoutTemplate>().ToTable("WorkoutTemplate");

            modelBuilder.Entity<TemplateProgramAudit>().ToTable("TemplateProgramAudit");


            modelBuilder.Entity<LiftingStatAudit>().ToTable("LiftingStatAudit");

            modelBuilder.Entity<TemplateProgram>().ToTable("TemplateProgram");
            modelBuilder.Entity<TemplateWeek>().ToTable("TemplateWeek");
            modelBuilder.Entity<TemplateDay>().ToTable("TemplateDay");
            modelBuilder.Entity<TemplateExercise>().ToTable("TemplateExercise");
            modelBuilder.Entity<TemplateRepScheme>().ToTable("TemplateRepScheme");
            modelBuilder.Entity<TemplateExerciseCollection>().ToTable("TemplateExerciseCollection");

            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);

            modelBuilder.Entity<WorkoutLog>()
                .HasMany(x => x.WorkoutDays)
                .WithOne(x => x.WorkoutLog)
                .HasForeignKey(x => x.WorkoutLogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkoutDay>()
                .HasMany(x => x.WorkoutExercises)
                .WithOne()
                .HasForeignKey(x => x.WorkoutDayId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkoutExercise>()
                .HasMany(x => x.WorkoutSets)
                .WithOne()
                .HasForeignKey(x => x.WorkoutExerciseId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TemplateProgram>()
                .HasMany(x => x.TemplateExerciseCollection)
                .WithOne()
                .HasForeignKey(x => x.TemplateProgramId)
                .IsRequired(false);

            modelBuilder.Entity<UserSetting>()
                .HasOne(x => x.LiftingLevel)
                .WithOne()
                .HasForeignKey<LiftingLevel>(x => x.LiftingLevelId)
                .IsRequired(false);

            modelBuilder.Entity<Exercise>()
                .HasMany(x => x.LiftingStatAudit)
                .WithOne(x => x.Exercise)
                .HasForeignKey(x => x.ExerciseId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(x => x.WorkoutExerciseTonnage)
                .WithOne(x => x.WorkoutExercise)
                .HasForeignKey<WorkoutExerciseTonnage>(x => x.WorkoutExerciseId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            modelBuilder.Entity<WorkoutSet>()
                .HasOne(x => x.LiftingStatAudit)
                .WithOne(x => x.WorkoutSet)
                .HasForeignKey<LiftingStatAudit>(x => x.WorkoutSetId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
