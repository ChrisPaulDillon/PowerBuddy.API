using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Context
{
    public class PowerLiftingContext : DbContext
    {
        public PowerLiftingContext(DbContextOptions<PowerLiftingContext> options) : base(options)
        {


        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //   => options.UseSqlite("Data Source=app.db");

        //System
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseType> ExerciseType { get; set; }
        public DbSet<ExerciseMuscleGroupAssoc> ExerciseMuscleGroupAssoc { get; set; }
        public DbSet<ExerciseMuscleGroup> ExerciseMuscleGroup { get; set; }
        public DbSet<ExerciseSport> ExerciseSport { get; set; }
        public DbSet<TemplateDifficulty> TemplateDifficulty { get; set; }
        public DbSet<RepSchemeType> RepSchemeType { get; set; }
        public DbSet<Quote> Quote { get; set; }

        public DbSet<ProgramLog> ProgramLog { get; set; }
        public DbSet<ProgramLogWeek> ProgramLogWeek { get; set; }
        public DbSet<ProgramLogDay> ProgramLogDay { get; set; }
        public DbSet<ProgramLogExercise> ProgramLogExercise { get; set; }
        public DbSet<ProgramLogExerciseAudit> ProgramLogExerciseAudit { get; set; }
        public DbSet<ProgramLogExerciseTonnage> ProgramLogExerciseTonnage { get; set; }
        public DbSet<ProgramLogRepScheme> ProgramLogRepScheme { get; set; }

        public DbSet<WorkoutLog> WorkoutLog { get; set; }
        public DbSet<WorkoutDay> WorkoutDay { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercise { get; set; }
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

        public DbSet<FriendRequest> FriendRequest { get; set; }
        public DbSet<FriendsListAssoc> FriendsListAssoc { get; set; }
        public DbSet<UserSetting> UserSetting { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotificationInteraction> NotificationInteraction { get; set; }

        //System
        public DbSet<Gender> Gender { get; set; }
        public DbSet<MemberStatus> MemberStatus { get; set; }
        public DbSet<LiftingLevel> LiftingLevel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramLogExerciseTonnage>().ToTable("ProgramLogExerciseTonnage");

            //System
            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<MemberStatus>().ToTable("MemberStatus");
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey().ToTable("IdentityUserRole");
            modelBuilder.Entity<IdentityRole>().ToTable("IdentityRole");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("IdentityUserClaim");
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey().ToTable("IdentityUserToken");

            modelBuilder.Entity<FriendRequest>().ToTable("FriendRequest");
            modelBuilder.Entity<FriendsListAssoc>().ToTable("FriendsListAssoc");
            modelBuilder.Entity<UserSetting>().ToTable("UserSetting");
            modelBuilder.Entity<Notification>().ToTable("Notification");
            modelBuilder.Entity<NotificationInteraction>().ToTable("NotificationInteraction");

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

            modelBuilder.Entity<ProgramLog>().ToTable("ProgramLog");
            modelBuilder.Entity<ProgramLogWeek>().ToTable("ProgramLogWeek");
            modelBuilder.Entity<ProgramLogDay>().ToTable("ProgramLogDay");
            modelBuilder.Entity<ProgramLogExercise>().ToTable("ProgramLogExercise");
            modelBuilder.Entity<ProgramLogRepScheme>().ToTable("ProgramLogRepScheme");

            modelBuilder.Entity<WorkoutLog>().ToTable("WorkoutLog");
            modelBuilder.Entity<WorkoutDay>().ToTable("WorkoutDay");
            modelBuilder.Entity<WorkoutExercise>().ToTable("WorkoutExercise");
            modelBuilder.Entity<WorkoutSet>().ToTable("WorkoutSet");
            modelBuilder.Entity<WorkoutTemplate>().ToTable("WorkoutTemplate");

            modelBuilder.Entity<TemplateProgramAudit>().ToTable("TemplateProgramAudit");

            modelBuilder.Entity<User>().ToTable("IdentityUser");


            modelBuilder.Entity<ProgramLogExerciseAudit>().ToTable("ProgramLogExerciseAudit");
            modelBuilder.Entity<LiftingStatAudit>().ToTable("LiftingStatAudit");
            modelBuilder.Entity<TemplateProgram>().ToTable("TemplateProgram");
            modelBuilder.Entity<TemplateWeek>().ToTable("TemplateWeek");
            modelBuilder.Entity<TemplateDay>().ToTable("TemplateDay");
            modelBuilder.Entity<TemplateExercise>().ToTable("TemplateExercise");
            modelBuilder.Entity<TemplateRepScheme>().ToTable("TemplateRepScheme");
            modelBuilder.Entity<TemplateExerciseCollection>().ToTable("TemplateExerciseCollection");

            modelBuilder.Entity<ProgramLog>()
                .HasMany(x => x.ProgramLogWeeks)
                .WithOne(x => x.ProgramLog)
                .HasForeignKey(x => x.ProgramLogId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ProgramLog>()
            //    .HasOne(x => x.TemplateProgram)
            //    .WithOne()
            //    .IsRequired(false);

            modelBuilder.Entity<ProgramLogWeek>()
                .HasMany(x => x.ProgramLogDays)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProgramLogDay>()
                .HasMany(x => x.ProgramLogExercises)
                .WithOne()
                .HasForeignKey(x => x.ProgramLogDayId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProgramLogExercise>()
                .HasMany(x => x.ProgramLogRepSchemes)
                .WithOne()
                .HasForeignKey(x => x.ProgramLogExerciseId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProgramLogExercise>() // This one should always be the table with the foreign key inside of it, NOT the primary key
              .HasOne(x => x.WorkoutTemplate)
              .WithMany(x => x.WorkoutExercises)
              .HasForeignKey(x => x.WorkoutTemplateId)
              .IsRequired(false);

            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);

            modelBuilder.Entity<WorkoutLog>()
                .HasMany(x => x.WorkoutDays)
                .WithOne()
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

            //modelBuilder.Entity<Gender>()
            //    .HasMany(x => x.Users)
            //    .WithOne(x => x.Gender)
            //    .IsRequired(false);

            //modelBuilder.Entity<MemberStatus>()
            //    .HasMany(x => x.Users)
            //    .WithOne(x => x.MemberStatus)
            //    .IsRequired(false);

            modelBuilder.Entity<ProgramLogExercise>()
                .HasOne(x => x.ProgramLogExerciseTonnage)
                .WithOne()
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .HasOne(x => x.FriendRequestTo)
                .WithOne()
                .HasForeignKey<FriendRequest>(x => x.UserToId)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .HasOne(x => x.FriendRequestFrom)
                .WithOne()
                .HasForeignKey<FriendRequest>(x => x.UserFromId)
                .IsRequired(false);

            modelBuilder.Entity<TemplateProgram>()
                .HasMany(x => x.TemplateExerciseCollection)
                .WithOne()
                .HasForeignKey(x => x.TemplateProgramId)
                .IsRequired(false);

            modelBuilder.Entity<ProgramLogExercise>()
                .HasOne(x => x.ProgramLogExerciseTonnage)
                .WithOne(x => x.ProgramLogExercise)
                .HasForeignKey<ProgramLogExerciseTonnage>(x => x.ProgramLogExerciseId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            modelBuilder.Entity<UserSetting>()
                .HasOne(x => x.LiftingLevel)
                .WithOne()
                .HasForeignKey<LiftingLevel>(x => x.LiftingLevelId)
                .IsRequired(false);

            modelBuilder.Entity<ProgramLogRepScheme>()
                .HasOne(x => x.LiftingStatAudit)
                .WithOne(x => x.ProgramLogRepScheme)
                .HasForeignKey<LiftingStatAudit>(x => x.ProgramLogRepSchemeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            modelBuilder.Entity<Exercise>()
                .HasMany(x => x.LiftingStatAudit)
                .WithOne(x => x.Exercise)
                .HasForeignKey(x => x.ExerciseId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
