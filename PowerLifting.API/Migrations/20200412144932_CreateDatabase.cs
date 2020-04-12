using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.API.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseType",
                columns: table => new
                {
                    ExerciseTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExerciseTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseType", x => x.ExerciseTypeId);
                    table.UniqueConstraint("AK_ExerciseType_ExerciseTypeName", x => x.ExerciseTypeName);
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
                    AccessFailedCount = table.Column<int>(nullable: false)
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true),
                    DateChange = table.Column<DateTime>(nullable: false),
                    Squat = table.Column<string>(nullable: true),
                    Bench = table.Column<string>(nullable: true),
                    Deadlift = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingStatAudit", x => x.LiftingStatAuditId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateProgram",
                columns: table => new
                {
                    TemplateProgramId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Difficulty = table.Column<string>(nullable: true),
                    NoOfWeeks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProgram", x => x.TemplateProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExerciseName = table.Column<string>(nullable: false),
                    ExerciseTypeId = table.Column<int>(nullable: false)
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
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRole_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LiftingStat",
                columns: table => new
                {
                    LiftingStatId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true),
                    Percentage = table.Column<double>(nullable: true),
                    BenchWeight = table.Column<double>(nullable: false),
                    SquatWeight = table.Column<double>(nullable: false),
                    DeadliftWeight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingStat", x => x.LiftingStatId);
                    table.ForeignKey(
                        name: "FK_LiftingStat_IdentityUser_UserId",
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
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true),
                    TemplateProgramId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    NoOfDaysLifting = table.Column<int>(nullable: false),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLog", x => x.ProgramLogId);
                    table.ForeignKey(
                        name: "FK_ProgramLog_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateExercise",
                columns: table => new
                {
                    TemplateExerciseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemplateProgramId = table.Column<int>(nullable: false),
                    ExerciseName = table.Column<string>(nullable: true),
                    Percentage = table.Column<double>(nullable: true),
                    WeekNumber = table.Column<int>(nullable: false),
                    DayNumber = table.Column<int>(nullable: false),
                    NoOfSets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateExercise", x => x.TemplateExerciseId);
                    table.ForeignKey(
                        name: "FK_TemplateExercise_TemplateProgram_TemplateProgramId",
                        column: x => x.TemplateProgramId,
                        principalTable: "TemplateProgram",
                        principalColumn: "TemplateProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroup",
                columns: table => new
                {
                    ExerciseMuscleGroupId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExerciseMuscleGroupName = table.Column<string>(nullable: true),
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
                name: "ProgramLogExercise",
                columns: table => new
                {
                    ProgramLogExerciseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramLogId = table.Column<int>(nullable: false),
                    ExerciseName = table.Column<string>(nullable: true),
                    LiftingDate = table.Column<DateTime>(nullable: false),
                    NumOfSets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLogExercise", x => x.ProgramLogExerciseId);
                    table.ForeignKey(
                        name: "FK_ProgramLogExercise_ProgramLog_ProgramLogId",
                        column: x => x.ProgramLogId,
                        principalTable: "ProgramLog",
                        principalColumn: "ProgramLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateRepScheme",
                columns: table => new
                {
                    TemplateRepSchemeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemplateExerciseId = table.Column<int>(nullable: false),
                    Percentage = table.Column<double>(nullable: false),
                    SetNo = table.Column<int>(nullable: false),
                    NumOfReps = table.Column<int>(nullable: false),
                    WeightLifted = table.Column<double>(nullable: false)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramLogExerciseId = table.Column<int>(nullable: true),
                    Percentage = table.Column<double>(nullable: true),
                    SetNo = table.Column<int>(nullable: false),
                    NumOfReps = table.Column<int>(nullable: false),
                    WeightLifted = table.Column<double>(nullable: false)
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
                name: "IX_IdentityRole_UserId",
                table: "IdentityRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStat_UserId",
                table: "LiftingStat",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLog_UserId",
                table: "ProgramLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogExercise_ProgramLogId",
                table: "ProgramLogExercise",
                column: "ProgramLogId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogRepScheme_ProgramLogExerciseId",
                table: "ProgramLogRepScheme",
                column: "ProgramLogExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExercise_TemplateProgramId",
                table: "TemplateExercise",
                column: "TemplateProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateRepScheme_TemplateExerciseId",
                table: "TemplateRepScheme",
                column: "TemplateExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroup");

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
                name: "ProgramLogRepScheme");

            migrationBuilder.DropTable(
                name: "TemplateRepScheme");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "ProgramLogExercise");

            migrationBuilder.DropTable(
                name: "TemplateExercise");

            migrationBuilder.DropTable(
                name: "ExerciseType");

            migrationBuilder.DropTable(
                name: "ProgramLog");

            migrationBuilder.DropTable(
                name: "TemplateProgram");

            migrationBuilder.DropTable(
                name: "IdentityUser");
        }
    }
}
