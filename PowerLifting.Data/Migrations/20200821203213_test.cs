using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseType",
                columns: table => new
                {
                    ExerciseTypeId = table.Column<int>(nullable: false),
                    ExerciseTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseType", x => x.ExerciseTypeId);
                    table.UniqueConstraint("AK_ExerciseType_ExerciseTypeName", x => x.ExerciseTypeName);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequest",
                columns: table => new
                {
                    FriendRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFromId = table.Column<string>(nullable: true),
                    UserToId = table.Column<string>(nullable: true),
                    HasAccepted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequest", x => x.FriendRequestId);
                });

            migrationBuilder.CreateTable(
                name: "FriendsListAssoc",
                columns: table => new
                {
                    FriendsListAssocId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    OtherUserId = table.Column<string>(nullable: true),
                    OtherUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendsListAssoc", x => x.FriendsListAssocId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LiftingStatId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    IsBanned = table.Column<bool>(nullable: false),
                    SportType = table.Column<string>(nullable: true),
                    Rights = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                    table.UniqueConstraint("AK_IdentityUser_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: true),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "LiftingStatAudit",
                columns: table => new
                {
                    LiftingStatAuditId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ExerciseId = table.Column<int>(nullable: false),
                    DateChanged = table.Column<DateTime>(nullable: false),
                    RepRange = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingStatAudit", x => x.LiftingStatAuditId);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "NotificationInteraction",
                columns: table => new
                {
                    NotificationInteractionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    HasRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationInteraction", x => x.NotificationInteractionId);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLogExerciseAudit",
                columns: table => new
                {
                    ProgramLogExerciseAuditId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ExerciseId = table.Column<int>(nullable: false),
                    ExerciseTypeId = table.Column<int>(nullable: false),
                    SelectedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLogExerciseAudit", x => x.ProgramLogExerciseAuditId);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteStr = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Year = table.Column<short>(nullable: true),
                    QuoteCategory = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.QuoteId);
                });

            migrationBuilder.CreateTable(
                name: "RepSchemeType",
                columns: table => new
                {
                    RepSchemeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepSchemeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepSchemeType", x => x.RepSchemeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateDifficulty",
                columns: table => new
                {
                    TemplateDifficultyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateDifficultyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateDifficulty", x => x.TemplateDifficultyId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateProgram",
                columns: table => new
                {
                    TemplateProgramId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Difficulty = table.Column<string>(nullable: true),
                    NoOfWeeks = table.Column<int>(nullable: false),
                    NoOfDaysPerWeek = table.Column<int>(nullable: false),
                    TemplateType = table.Column<string>(nullable: true),
                    WeightProgressionType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProgram", x => x.TemplateProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false),
                    ExerciseTypeId = table.Column<int>(nullable: false),
                    ExerciseName = table.Column<string>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    AdminApprover = table.Column<string>(nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSetting",
                columns: table => new
                {
                    UserSettingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    UsingMetric = table.Column<bool>(nullable: false),
                    BodyWeight = table.Column<decimal>(nullable: false),
                    ActiveQuotes = table.Column<bool>(nullable: false)
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
                name: "ProgramLog",
                columns: table => new
                {
                    ProgramLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    TemplateProgramId = table.Column<int>(nullable: true),
                    NoOfWeeks = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
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
                name: "TemplateExerciseCollection",
                columns: table => new
                {
                    TemplateExerciseCollectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateProgramId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateExerciseCollection", x => x.TemplateExerciseCollectionId);
                    table.ForeignKey(
                        name: "FK_TemplateExerciseCollection_TemplateProgram_TemplateProgramId",
                        column: x => x.TemplateProgramId,
                        principalTable: "TemplateProgram",
                        principalColumn: "TemplateProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateWeek",
                columns: table => new
                {
                    TemplateWeekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(nullable: false),
                    WeekNo = table.Column<int>(nullable: false),
                    TemplateProgramId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateWeek", x => x.TemplateWeekId);
                    table.ForeignKey(
                        name: "FK_TemplateWeek_TemplateProgram_TemplateProgramId",
                        column: x => x.TemplateProgramId,
                        principalTable: "TemplateProgram",
                        principalColumn: "TemplateProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroup",
                columns: table => new
                {
                    ExerciseMuscleGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseMuscleGroupName = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleGroup", x => x.ExerciseMuscleGroupId);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroup_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSport",
                columns: table => new
                {
                    ExerciseSportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseSportStr = table.Column<string>(nullable: true),
                    ExerciseId = table.Column<int>(nullable: false)
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
                name: "LiftingStat",
                columns: table => new
                {
                    LiftingStatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ExerciseId = table.Column<int>(nullable: false),
                    RepRange = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: true),
                    GoalWeight = table.Column<decimal>(nullable: true),
                    PercentageToGoal = table.Column<decimal>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingStat", x => x.LiftingStatId);
                    table.ForeignKey(
                        name: "FK_LiftingStat_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLogWeek",
                columns: table => new
                {
                    ProgramLogWeekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    WeekNo = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
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
                    TemplateDayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateWeekId = table.Column<int>(nullable: false),
                    DayNo = table.Column<int>(nullable: false)
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
                name: "ProgramLogDay",
                columns: table => new
                {
                    ProgramLogDayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogWeekId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    PersonalBest = table.Column<bool>(nullable: true)
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
                    TemplateExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateDayId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    NoOfSets = table.Column<int>(nullable: false),
                    RepSchemeFormat = table.Column<string>(nullable: true),
                    RepSchemeType = table.Column<string>(nullable: true),
                    HasBackOffSets = table.Column<bool>(nullable: false),
                    BackOffSetFormat = table.Column<string>(nullable: true)
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
                name: "ProgramLogExercise",
                columns: table => new
                {
                    ProgramLogExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogDayId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    NoOfSets = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    PersonalBest = table.Column<bool>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateRepScheme",
                columns: table => new
                {
                    TemplateRepSchemeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateExerciseId = table.Column<int>(nullable: false),
                    Percentage = table.Column<decimal>(nullable: true),
                    SetNo = table.Column<int>(nullable: false),
                    NoOfReps = table.Column<int>(nullable: false),
                    WeightLifted = table.Column<decimal>(nullable: false),
                    IsBackOffSet = table.Column<bool>(nullable: false),
                    AMRAP = table.Column<bool>(nullable: false)
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
                name: "ProgramLogRepScheme",
                columns: table => new
                {
                    ProgramLogRepSchemeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogExerciseId = table.Column<int>(nullable: false),
                    SetNo = table.Column<int>(nullable: false),
                    NoOfReps = table.Column<int>(nullable: false),
                    WeightLifted = table.Column<decimal>(nullable: false),
                    Percentage = table.Column<decimal>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    AMRAP = table.Column<bool>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    RepsCompleted = table.Column<int>(nullable: true),
                    PersonalBest = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLogRepScheme", x => x.ProgramLogRepSchemeId);
                    table.ForeignKey(
                        name: "FK_ProgramLogRepScheme_ProgramLogExercise_ProgramLogExerciseId",
                        column: x => x.ProgramLogExerciseId,
                        principalTable: "ProgramLogExercise",
                        principalColumn: "ProgramLogExerciseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseTypeId",
                table: "Exercise",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscleGroup_ExerciseId",
                table: "ExerciseMuscleGroup",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSport_ExerciseId",
                table: "ExerciseSport",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStat_ExerciseId",
                table: "LiftingStat",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLog_TemplateProgramId",
                table: "ProgramLog",
                column: "TemplateProgramId",
                unique: true,
                filter: "[TemplateProgramId] IS NOT NULL");

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
                name: "IX_TemplateExerciseCollection_TemplateProgramId",
                table: "TemplateExerciseCollection",
                column: "TemplateProgramId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroup");

            migrationBuilder.DropTable(
                name: "ExerciseSport");

            migrationBuilder.DropTable(
                name: "FriendRequest");

            migrationBuilder.DropTable(
                name: "FriendsListAssoc");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim");

            migrationBuilder.DropTable(
                name: "IdentityUserRole");

            migrationBuilder.DropTable(
                name: "IdentityUserToken");

            migrationBuilder.DropTable(
                name: "LiftingStat");

            migrationBuilder.DropTable(
                name: "LiftingStatAudit");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "NotificationInteraction");

            migrationBuilder.DropTable(
                name: "ProgramLogExerciseAudit");

            migrationBuilder.DropTable(
                name: "ProgramLogRepScheme");

            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DropTable(
                name: "RepSchemeType");

            migrationBuilder.DropTable(
                name: "TemplateDifficulty");

            migrationBuilder.DropTable(
                name: "TemplateExerciseCollection");

            migrationBuilder.DropTable(
                name: "TemplateRepScheme");

            migrationBuilder.DropTable(
                name: "UserSetting");

            migrationBuilder.DropTable(
                name: "ProgramLogExercise");

            migrationBuilder.DropTable(
                name: "TemplateExercise");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "ProgramLogDay");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "TemplateDay");

            migrationBuilder.DropTable(
                name: "ProgramLogWeek");

            migrationBuilder.DropTable(
                name: "ExerciseType");

            migrationBuilder.DropTable(
                name: "TemplateWeek");

            migrationBuilder.DropTable(
                name: "ProgramLog");

            migrationBuilder.DropTable(
                name: "TemplateProgram");
        }
    }
}
