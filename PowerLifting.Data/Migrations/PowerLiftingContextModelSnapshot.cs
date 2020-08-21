﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Migrations
{
    [DbContext(typeof(PowerLiftingContext))]
    partial class PowerLiftingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("IdentityUserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("IdentityUserToken");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Account.FriendRequest", b =>
                {
                    b.Property<int>("FriendRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("HasAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("UserFromId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserToId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FriendRequestId");

                    b.ToTable("FriendRequest");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Account.FriendsListAssoc", b =>
                {
                    b.Property<int>("FriendsListAssocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OtherUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FriendsListAssocId");

                    b.ToTable("FriendsListAssoc");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Account.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NotificationText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Account.NotificationInteraction", b =>
                {
                    b.Property<int>("NotificationInteractionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasRead")
                        .HasColumnType("bit");

                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationInteractionId");

                    b.ToTable("NotificationInteraction");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Account.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LiftingStatId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Rights")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SportType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Account.UserSetting", b =>
                {
                    b.Property<int>("UserSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ActiveQuotes")
                        .HasColumnType("bit");

                    b.Property<decimal>("BodyWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("UsingMetric")
                        .HasColumnType("bit");

                    b.HasKey("UserSettingId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("UserSetting");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Exercises.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("AdminApprover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.HasKey("ExerciseId");

                    b.HasAlternateKey("ExerciseName");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Exercises.ExerciseMuscleGroup", b =>
                {
                    b.Property<int>("ExerciseMuscleGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseMuscleGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.HasKey("ExerciseMuscleGroupId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseMuscleGroup");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Exercises.ExerciseSport", b =>
                {
                    b.Property<int>("ExerciseSportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseSportStr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseSportId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseSport");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Exercises.ExerciseType", b =>
                {
                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ExerciseTypeId");

                    b.HasAlternateKey("ExerciseTypeName");

                    b.ToTable("ExerciseType");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.LiftingStats.LiftingStat", b =>
                {
                    b.Property<int>("LiftingStatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<decimal?>("GoalWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("PercentageToGoal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RepRange")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LiftingStatId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("LiftingStat");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.LiftingStats.LiftingStatAudit", b =>
                {
                    b.Property<int>("LiftingStatAuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateChanged")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("RepRange")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LiftingStatAuditId");

                    b.ToTable("LiftingStatAudit");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLog", b =>
                {
                    b.Property<int>("ProgramLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Friday")
                        .HasColumnType("bit");

                    b.Property<bool>("Monday")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfWeeks")
                        .HasColumnType("int");

                    b.Property<bool>("Saturday")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Sunday")
                        .HasColumnType("bit");

                    b.Property<int?>("TemplateProgramId")
                        .HasColumnType("int");

                    b.Property<bool>("Thursday")
                        .HasColumnType("bit");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("bit");

                    b.HasKey("ProgramLogId");

                    b.HasIndex("TemplateProgramId")
                        .IsUnique()
                        .HasFilter("[TemplateProgramId] IS NOT NULL");

                    b.ToTable("ProgramLog");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLogDay", b =>
                {
                    b.Property<int>("ProgramLogDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("PersonalBest")
                        .HasColumnType("bit");

                    b.Property<int>("ProgramLogWeekId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramLogDayId");

                    b.HasIndex("ProgramLogWeekId");

                    b.ToTable("ProgramLogDay");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLogExercise", b =>
                {
                    b.Property<int>("ProgramLogExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfSets")
                        .HasColumnType("int");

                    b.Property<bool?>("PersonalBest")
                        .HasColumnType("bit");

                    b.Property<int>("ProgramLogDayId")
                        .HasColumnType("int");

                    b.HasKey("ProgramLogExerciseId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("ProgramLogDayId");

                    b.ToTable("ProgramLogExercise");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLogExerciseAudit", b =>
                {
                    b.Property<int>("ProgramLogExerciseAuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SelectedCount")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramLogExerciseAuditId");

                    b.ToTable("ProgramLogExerciseAudit");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLogRepScheme", b =>
                {
                    b.Property<int>("ProgramLogRepSchemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AMRAP")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfReps")
                        .HasColumnType("int");

                    b.Property<decimal?>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("PersonalBest")
                        .HasColumnType("bit");

                    b.Property<int>("ProgramLogExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("RepsCompleted")
                        .HasColumnType("int");

                    b.Property<int>("SetNo")
                        .HasColumnType("int");

                    b.Property<decimal>("WeightLifted")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProgramLogRepSchemeId");

                    b.HasIndex("ProgramLogExerciseId");

                    b.ToTable("ProgramLogRepScheme");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLogWeek", b =>
                {
                    b.Property<int>("ProgramLogWeekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProgramLogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekNo")
                        .HasColumnType("int");

                    b.HasKey("ProgramLogWeekId");

                    b.HasIndex("ProgramLogId");

                    b.ToTable("ProgramLogWeek");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.System.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("QuoteCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuoteStr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("QuoteId");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.System.RepSchemeType", b =>
                {
                    b.Property<int>("RepSchemeTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RepSchemeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RepSchemeTypeId");

                    b.ToTable("RepSchemeType");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.System.TemplateDifficulty", b =>
                {
                    b.Property<int>("TemplateDifficultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TemplateDifficultyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateDifficultyId");

                    b.ToTable("TemplateDifficulty");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateDay", b =>
                {
                    b.Property<int>("TemplateDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayNo")
                        .HasColumnType("int");

                    b.Property<int>("TemplateWeekId")
                        .HasColumnType("int");

                    b.HasKey("TemplateDayId");

                    b.HasIndex("TemplateWeekId");

                    b.ToTable("TemplateDay");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateExercise", b =>
                {
                    b.Property<int>("TemplateExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackOffSetFormat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<bool>("HasBackOffSets")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfSets")
                        .HasColumnType("int");

                    b.Property<string>("RepSchemeFormat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepSchemeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateDayId")
                        .HasColumnType("int");

                    b.HasKey("TemplateExerciseId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("TemplateDayId");

                    b.ToTable("TemplateExercise");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateExerciseCollection", b =>
                {
                    b.Property<int>("TemplateExerciseCollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateProgramId")
                        .HasColumnType("int");

                    b.HasKey("TemplateExerciseCollectionId");

                    b.HasIndex("TemplateProgramId");

                    b.ToTable("TemplateExerciseCollection");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateProgram", b =>
                {
                    b.Property<int>("TemplateProgramId")
                        .HasColumnType("int");

                    b.Property<string>("Difficulty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfDaysPerWeek")
                        .HasColumnType("int");

                    b.Property<int>("NoOfWeeks")
                        .HasColumnType("int");

                    b.Property<string>("TemplateType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeightProgressionType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateProgramId");

                    b.ToTable("TemplateProgram");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateRepScheme", b =>
                {
                    b.Property<int>("TemplateRepSchemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AMRAP")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBackOffSet")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfReps")
                        .HasColumnType("int");

                    b.Property<decimal?>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SetNo")
                        .HasColumnType("int");

                    b.Property<int>("TemplateExerciseId")
                        .HasColumnType("int");

                    b.Property<decimal>("WeightLifted")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TemplateRepSchemeId");

                    b.HasIndex("TemplateExerciseId");

                    b.ToTable("TemplateRepScheme");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateWeek", b =>
                {
                    b.Property<int>("TemplateWeekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<int?>("TemplateProgramId")
                        .HasColumnType("int");

                    b.Property<int>("WeekNo")
                        .HasColumnType("int");

                    b.HasKey("TemplateWeekId");

                    b.HasIndex("TemplateProgramId");

                    b.ToTable("TemplateWeek");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Account.UserSetting", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Account.User", null)
                        .WithOne("UserSetting")
                        .HasForeignKey("PowerLifting.Data.Entities.Account.UserSetting", "UserId");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Exercises.Exercise", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Exercises.ExerciseType", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Exercises.ExerciseMuscleGroup", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Exercises.Exercise", null)
                        .WithMany("ExerciseMuscleGroups")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Exercises.ExerciseSport", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Exercises.Exercise", null)
                        .WithMany("ExerciseSports")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.LiftingStats.LiftingStat", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Exercises.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLog", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Templates.TemplateProgram", "TemplateProgram")
                        .WithOne("ProgramLog")
                        .HasForeignKey("PowerLifting.Data.Entities.ProgramLogs.ProgramLog", "TemplateProgramId");
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLogDay", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.ProgramLogs.ProgramLogWeek", null)
                        .WithMany("ProgramLogDays")
                        .HasForeignKey("ProgramLogWeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLogExercise", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Exercises.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PowerLifting.Data.Entities.ProgramLogs.ProgramLogDay", "ProgramLogDay")
                        .WithMany("ProgramLogExercises")
                        .HasForeignKey("ProgramLogDayId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLogRepScheme", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.ProgramLogs.ProgramLogExercise", "ProgramLogExercise")
                        .WithMany("ProgramLogRepSchemes")
                        .HasForeignKey("ProgramLogExerciseId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.ProgramLogs.ProgramLogWeek", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.ProgramLogs.ProgramLog", null)
                        .WithMany("ProgramLogWeeks")
                        .HasForeignKey("ProgramLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateDay", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Templates.TemplateWeek", null)
                        .WithMany("TemplateDays")
                        .HasForeignKey("TemplateWeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateExercise", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Exercises.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PowerLifting.Data.Entities.Templates.TemplateDay", null)
                        .WithMany("TemplateExercises")
                        .HasForeignKey("TemplateDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateExerciseCollection", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Templates.TemplateProgram", null)
                        .WithMany("TemplateExerciseCollection")
                        .HasForeignKey("TemplateProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateRepScheme", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Templates.TemplateExercise", null)
                        .WithMany("TemplateRepSchemes")
                        .HasForeignKey("TemplateExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerLifting.Data.Entities.Templates.TemplateWeek", b =>
                {
                    b.HasOne("PowerLifting.Data.Entities.Templates.TemplateProgram", null)
                        .WithMany("TemplateWeeks")
                        .HasForeignKey("TemplateProgramId");
                });
#pragma warning restore 612, 618
        }
    }
}
