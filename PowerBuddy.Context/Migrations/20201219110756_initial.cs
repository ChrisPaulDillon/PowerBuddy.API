using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroup",
                columns: table => new
                {
                    ExerciseMuscleGroupId = table.Column<int>(type: "int", nullable: false),
                    ExerciseMuscleGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleGroup", x => x.ExerciseMuscleGroupId);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseType",
                columns: table => new
                {
                    ExerciseTypeId = table.Column<int>(type: "int", nullable: false),
                    ExerciseTypeName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseType", x => x.ExerciseTypeId);
                    table.UniqueConstraint("AK_ExerciseType_ExerciseTypeName", x => x.ExerciseTypeName);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MemberStatus",
                columns: table => new
                {
                    MemberStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberStatus", x => x.MemberStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLogExerciseAudit",
                columns: table => new
                {
                    ProgramLogExerciseAuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    ExerciseTypeId = table.Column<int>(type: "int", nullable: false),
                    SelectedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLogExerciseAudit", x => x.ProgramLogExerciseAuditId);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteStr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<short>(type: "smallint", nullable: true),
                    QuoteCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.QuoteId);
                });

            migrationBuilder.CreateTable(
                name: "RepSchemeType",
                columns: table => new
                {
                    RepSchemeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepSchemeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepSchemeType", x => x.RepSchemeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateDifficulty",
                columns: table => new
                {
                    TemplateDifficultyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateDifficultyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateDifficulty", x => x.TemplateDifficultyId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateProgram",
                columns: table => new
                {
                    TemplateProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfWeeks = table.Column<int>(type: "int", nullable: false),
                    NoOfDaysPerWeek = table.Column<int>(type: "int", nullable: false),
                    TemplateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightProgressionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    ActiveUsersCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProgram", x => x.TemplateProgramId);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExerciseAudit",
                columns: table => new
                {
                    WorkoutExerciseAuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    SelectedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExerciseAudit", x => x.WorkoutExerciseAuditId);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutTemplate",
                columns: table => new
                {
                    WorkoutTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTemplate", x => x.WorkoutTemplateId);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseTypeId = table.Column<int>(type: "int", nullable: true),
                    ExerciseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    AdminApprover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMainExercise = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseId);
                    table.UniqueConstraint("AK_Exercise_ExerciseName", x => x.ExerciseName);
                    table.ForeignKey(
                        name: "FK_Exercise_ExerciseType_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseType",
                        principalColumn: "ExerciseTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LiftingStatId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false),
                    SportType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstVisit = table.Column<bool>(type: "bit", nullable: false),
                    MemberStatusId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                    table.UniqueConstraint("AK_IdentityUser_Email", x => x.Email);
                    table.ForeignKey(
                        name: "FK_IdentityUser_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentityUser_MemberStatus_MemberStatusId",
                        column: x => x.MemberStatusId,
                        principalTable: "MemberStatus",
                        principalColumn: "MemberStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLog",
                columns: table => new
                {
                    ProgramLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProgramId = table.Column<int>(type: "int", nullable: true),
                    NoOfWeeks = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    Saturday = table.Column<bool>(type: "bit", nullable: false),
                    Sunday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLog", x => x.ProgramLogId);
                    table.ForeignKey(
                        name: "FK_ProgramLog_TemplateProgram_TemplateProgramId",
                        column: x => x.TemplateProgramId,
                        principalTable: "TemplateProgram",
                        principalColumn: "TemplateProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateWeek",
                columns: table => new
                {
                    TemplateWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateProgramId = table.Column<int>(type: "int", nullable: false),
                    WeekNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateWeek", x => x.TemplateWeekId);
                    table.ForeignKey(
                        name: "FK_TemplateWeek_TemplateProgram_TemplateProgramId",
                        column: x => x.TemplateProgramId,
                        principalTable: "TemplateProgram",
                        principalColumn: "TemplateProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutLog",
                columns: table => new
                {
                    WorkoutLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProgramId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    Saturday = table.Column<bool>(type: "bit", nullable: false),
                    Sunday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLog", x => x.WorkoutLogId);
                    table.ForeignKey(
                        name: "FK_WorkoutLog_TemplateProgram_TemplateProgramId",
                        column: x => x.TemplateProgramId,
                        principalTable: "TemplateProgram",
                        principalColumn: "TemplateProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroupAssoc",
                columns: table => new
                {
                    ExerciseMuscleGroupAssocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseMuscleGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleGroupAssoc", x => x.ExerciseMuscleGroupAssocId);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroupAssoc_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSport",
                columns: table => new
                {
                    ExerciseSportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseSportStr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSport", x => x.ExerciseSportId);
                    table.ForeignKey(
                        name: "FK_ExerciseSport_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateExerciseCollection",
                columns: table => new
                {
                    TemplateExerciseCollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateProgramId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateExerciseCollection", x => x.TemplateExerciseCollectionId);
                    table.ForeignKey(
                        name: "FK_TemplateExerciseCollection_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateExerciseCollection_TemplateProgram_TemplateProgramId",
                        column: x => x.TemplateProgramId,
                        principalTable: "TemplateProgram",
                        principalColumn: "TemplateProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateProgramAudit",
                columns: table => new
                {
                    TemplateProgramAuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateProgramId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProgramAudit", x => x.TemplateProgramAuditId);
                    table.ForeignKey(
                        name: "FK_TemplateProgramAudit_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateProgramAudit_TemplateProgram_TemplateProgramId",
                        column: x => x.TemplateProgramId,
                        principalTable: "TemplateProgram",
                        principalColumn: "TemplateProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSetting",
                columns: table => new
                {
                    UserSettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsingMetric = table.Column<bool>(type: "bit", nullable: false),
                    BodyWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuotesEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LiftingLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSetting", x => x.UserSettingId);
                    table.ForeignKey(
                        name: "FK_UserSetting_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLogWeek",
                columns: table => new
                {
                    ProgramLogWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekNo = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLogWeek", x => x.ProgramLogWeekId);
                    table.ForeignKey(
                        name: "FK_ProgramLogWeek_ProgramLog_ProgramLogId",
                        column: x => x.ProgramLogId,
                        principalTable: "ProgramLog",
                        principalColumn: "ProgramLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateDay",
                columns: table => new
                {
                    TemplateDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateWeekId = table.Column<int>(type: "int", nullable: false),
                    DayNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateDay", x => x.TemplateDayId);
                    table.ForeignKey(
                        name: "FK_TemplateDay_TemplateWeek_TemplateWeekId",
                        column: x => x.TemplateWeekId,
                        principalTable: "TemplateWeek",
                        principalColumn: "TemplateWeekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutDay",
                columns: table => new
                {
                    WorkoutDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutLogId = table.Column<int>(type: "int", nullable: true),
                    WeekNo = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDay", x => x.WorkoutDayId);
                    table.ForeignKey(
                        name: "FK_WorkoutDay_WorkoutLog_WorkoutLogId",
                        column: x => x.WorkoutLogId,
                        principalTable: "WorkoutLog",
                        principalColumn: "WorkoutLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiftingLevel",
                columns: table => new
                {
                    LiftingLevelId = table.Column<int>(type: "int", nullable: false),
                    LiftingLevelStr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingLevel", x => x.LiftingLevelId);
                    table.ForeignKey(
                        name: "FK_LiftingLevel_UserSetting_LiftingLevelId",
                        column: x => x.LiftingLevelId,
                        principalTable: "UserSetting",
                        principalColumn: "UserSettingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLogDay",
                columns: table => new
                {
                    ProgramLogDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogWeekId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLogDay", x => x.ProgramLogDayId);
                    table.ForeignKey(
                        name: "FK_ProgramLogDay_ProgramLogWeek_ProgramLogWeekId",
                        column: x => x.ProgramLogWeekId,
                        principalTable: "ProgramLogWeek",
                        principalColumn: "ProgramLogWeekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateExercise",
                columns: table => new
                {
                    TemplateExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateDayId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    NoOfSets = table.Column<int>(type: "int", nullable: false),
                    RepSchemeFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepSchemeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasBackOffSets = table.Column<bool>(type: "bit", nullable: false),
                    BackOffSetFormat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateExercise", x => x.TemplateExerciseId);
                    table.ForeignKey(
                        name: "FK_TemplateExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateExercise_TemplateDay_TemplateDayId",
                        column: x => x.TemplateDayId,
                        principalTable: "TemplateDay",
                        principalColumn: "TemplateDayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercise",
                columns: table => new
                {
                    WorkoutExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutDayId = table.Column<int>(type: "int", nullable: false),
                    WorkoutTemplateId = table.Column<int>(type: "int", nullable: true),
                    WorkoutExerciseTonnageId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercise", x => x.WorkoutExerciseId);
                    table.ForeignKey(
                        name: "FK_WorkoutExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutExercise_WorkoutDay_WorkoutDayId",
                        column: x => x.WorkoutDayId,
                        principalTable: "WorkoutDay",
                        principalColumn: "WorkoutDayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLogExercise",
                columns: table => new
                {
                    ProgramLogExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogDayId = table.Column<int>(type: "int", nullable: false),
                    WorkoutTemplateId = table.Column<int>(type: "int", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    NoOfSets = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalBest = table.Column<bool>(type: "bit", nullable: true),
                    ProgramLogExerciseTonnageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLogExercise", x => x.ProgramLogExerciseId);
                    table.ForeignKey(
                        name: "FK_ProgramLogExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramLogExercise_ProgramLogDay_ProgramLogDayId",
                        column: x => x.ProgramLogDayId,
                        principalTable: "ProgramLogDay",
                        principalColumn: "ProgramLogDayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramLogExercise_WorkoutTemplate_WorkoutTemplateId",
                        column: x => x.WorkoutTemplateId,
                        principalTable: "WorkoutTemplate",
                        principalColumn: "WorkoutTemplateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateRepScheme",
                columns: table => new
                {
                    TemplateRepSchemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateExerciseId = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SetNo = table.Column<int>(type: "int", nullable: false),
                    NoOfReps = table.Column<int>(type: "int", nullable: false),
                    WeightLifted = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsBackOffSet = table.Column<bool>(type: "bit", nullable: false),
                    AMRAP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateRepScheme", x => x.TemplateRepSchemeId);
                    table.ForeignKey(
                        name: "FK_TemplateRepScheme_TemplateExercise_TemplateExerciseId",
                        column: x => x.TemplateExerciseId,
                        principalTable: "TemplateExercise",
                        principalColumn: "TemplateExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExerciseTonnage",
                columns: table => new
                {
                    WorkoutExerciseTonnageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutExerciseId = table.Column<int>(type: "int", nullable: false),
                    ExerciseTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExerciseTonnage", x => x.WorkoutExerciseTonnageId);
                    table.ForeignKey(
                        name: "FK_WorkoutExerciseTonnage_WorkoutExercise_WorkoutExerciseId",
                        column: x => x.WorkoutExerciseId,
                        principalTable: "WorkoutExercise",
                        principalColumn: "WorkoutExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSet",
                columns: table => new
                {
                    WorkoutSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutExerciseId = table.Column<int>(type: "int", nullable: false),
                    NoOfReps = table.Column<int>(type: "int", nullable: false),
                    WeightLifted = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMRAP = table.Column<bool>(type: "bit", nullable: false),
                    RepsCompleted = table.Column<int>(type: "int", nullable: true),
                    LiftingStatAuditId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSet", x => x.WorkoutSetId);
                    table.ForeignKey(
                        name: "FK_WorkoutSet_WorkoutExercise_WorkoutExerciseId",
                        column: x => x.WorkoutExerciseId,
                        principalTable: "WorkoutExercise",
                        principalColumn: "WorkoutExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLogExerciseTonnage",
                columns: table => new
                {
                    ProgramLogExerciseTonnageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogExerciseId = table.Column<int>(type: "int", nullable: false),
                    ExerciseTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLogExerciseTonnage", x => x.ProgramLogExerciseTonnageId);
                    table.ForeignKey(
                        name: "FK_ProgramLogExerciseTonnage_ProgramLogExercise_ProgramLogExerciseId",
                        column: x => x.ProgramLogExerciseId,
                        principalTable: "ProgramLogExercise",
                        principalColumn: "ProgramLogExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLogRepScheme",
                columns: table => new
                {
                    ProgramLogRepSchemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogExerciseId = table.Column<int>(type: "int", nullable: false),
                    SetNo = table.Column<int>(type: "int", nullable: false),
                    NoOfReps = table.Column<int>(type: "int", nullable: false),
                    WeightLifted = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMRAP = table.Column<bool>(type: "bit", nullable: false),
                    RepsCompleted = table.Column<int>(type: "int", nullable: true),
                    LiftingStatAuditId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLogRepScheme", x => x.ProgramLogRepSchemeId);
                    table.ForeignKey(
                        name: "FK_ProgramLogRepScheme_ProgramLogExercise_ProgramLogExerciseId",
                        column: x => x.ProgramLogExerciseId,
                        principalTable: "ProgramLogExercise",
                        principalColumn: "ProgramLogExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiftingStatAudit",
                columns: table => new
                {
                    LiftingStatAuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RepRange = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgramLogRepSchemeId = table.Column<int>(type: "int", nullable: false),
                    WorkoutSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingStatAudit", x => x.LiftingStatAuditId);
                    table.ForeignKey(
                        name: "FK_LiftingStatAudit_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId");
                    table.ForeignKey(
                        name: "FK_LiftingStatAudit_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiftingStatAudit_ProgramLogRepScheme_ProgramLogRepSchemeId",
                        column: x => x.ProgramLogRepSchemeId,
                        principalTable: "ProgramLogRepScheme",
                        principalColumn: "ProgramLogRepSchemeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiftingStatAudit_WorkoutSet_WorkoutSetId",
                        column: x => x.WorkoutSetId,
                        principalTable: "WorkoutSet",
                        principalColumn: "WorkoutSetId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseTypeId",
                table: "Exercise",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscleGroupAssoc_ExerciseId",
                table: "ExerciseMuscleGroupAssoc",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSport_ExerciseId",
                table: "ExerciseSport",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_GenderId",
                table: "IdentityUser",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_MemberStatusId",
                table: "IdentityUser",
                column: "MemberStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStatAudit_ExerciseId",
                table: "LiftingStatAudit",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStatAudit_ProgramLogRepSchemeId",
                table: "LiftingStatAudit",
                column: "ProgramLogRepSchemeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStatAudit_UserId",
                table: "LiftingStatAudit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStatAudit_WorkoutSetId",
                table: "LiftingStatAudit",
                column: "WorkoutSetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLog_TemplateProgramId",
                table: "ProgramLog",
                column: "TemplateProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogDay_ProgramLogWeekId",
                table: "ProgramLogDay",
                column: "ProgramLogWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogExercise_ExerciseId",
                table: "ProgramLogExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogExercise_ProgramLogDayId",
                table: "ProgramLogExercise",
                column: "ProgramLogDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogExercise_WorkoutTemplateId",
                table: "ProgramLogExercise",
                column: "WorkoutTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogExerciseTonnage_ProgramLogExerciseId",
                table: "ProgramLogExerciseTonnage",
                column: "ProgramLogExerciseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogRepScheme_ProgramLogExerciseId",
                table: "ProgramLogRepScheme",
                column: "ProgramLogExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogWeek_ProgramLogId",
                table: "ProgramLogWeek",
                column: "ProgramLogId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateDay_TemplateWeekId",
                table: "TemplateDay",
                column: "TemplateWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExercise_ExerciseId",
                table: "TemplateExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExercise_TemplateDayId",
                table: "TemplateExercise",
                column: "TemplateDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExerciseCollection_ExerciseId",
                table: "TemplateExerciseCollection",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExerciseCollection_TemplateProgramId",
                table: "TemplateExerciseCollection",
                column: "TemplateProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProgramAudit_TemplateProgramId",
                table: "TemplateProgramAudit",
                column: "TemplateProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProgramAudit_UserId",
                table: "TemplateProgramAudit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateRepScheme_TemplateExerciseId",
                table: "TemplateRepScheme",
                column: "TemplateExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateWeek_TemplateProgramId",
                table: "TemplateWeek",
                column: "TemplateProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetting_UserId",
                table: "UserSetting",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDay_WorkoutLogId",
                table: "WorkoutDay",
                column: "WorkoutLogId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercise_ExerciseId",
                table: "WorkoutExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercise_WorkoutDayId",
                table: "WorkoutExercise",
                column: "WorkoutDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExerciseTonnage_WorkoutExerciseId",
                table: "WorkoutExerciseTonnage",
                column: "WorkoutExerciseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLog_TemplateProgramId",
                table: "WorkoutLog",
                column: "TemplateProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSet_WorkoutExerciseId",
                table: "WorkoutSet",
                column: "WorkoutExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroup");

            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroupAssoc");

            migrationBuilder.DropTable(
                name: "ExerciseSport");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim");

            migrationBuilder.DropTable(
                name: "IdentityUserRole");

            migrationBuilder.DropTable(
                name: "IdentityUserToken");

            migrationBuilder.DropTable(
                name: "LiftingLevel");

            migrationBuilder.DropTable(
                name: "LiftingStatAudit");

            migrationBuilder.DropTable(
                name: "ProgramLogExerciseAudit");

            migrationBuilder.DropTable(
                name: "ProgramLogExerciseTonnage");

            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DropTable(
                name: "RepSchemeType");

            migrationBuilder.DropTable(
                name: "TemplateDifficulty");

            migrationBuilder.DropTable(
                name: "TemplateExerciseCollection");

            migrationBuilder.DropTable(
                name: "TemplateProgramAudit");

            migrationBuilder.DropTable(
                name: "TemplateRepScheme");

            migrationBuilder.DropTable(
                name: "WorkoutExerciseAudit");

            migrationBuilder.DropTable(
                name: "WorkoutExerciseTonnage");

            migrationBuilder.DropTable(
                name: "UserSetting");

            migrationBuilder.DropTable(
                name: "ProgramLogRepScheme");

            migrationBuilder.DropTable(
                name: "WorkoutSet");

            migrationBuilder.DropTable(
                name: "TemplateExercise");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "ProgramLogExercise");

            migrationBuilder.DropTable(
                name: "WorkoutExercise");

            migrationBuilder.DropTable(
                name: "TemplateDay");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "MemberStatus");

            migrationBuilder.DropTable(
                name: "ProgramLogDay");

            migrationBuilder.DropTable(
                name: "WorkoutTemplate");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "WorkoutDay");

            migrationBuilder.DropTable(
                name: "TemplateWeek");

            migrationBuilder.DropTable(
                name: "ProgramLogWeek");

            migrationBuilder.DropTable(
                name: "ExerciseType");

            migrationBuilder.DropTable(
                name: "WorkoutLog");

            migrationBuilder.DropTable(
                name: "ProgramLog");

            migrationBuilder.DropTable(
                name: "TemplateProgram");
        }
    }
}
