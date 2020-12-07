using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class workoutexercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "WorkoutDay",
                columns: table => new
                {
                    WorkoutDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogId = table.Column<int>(type: "int", nullable: true),
                    WeekNo = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDay", x => x.WorkoutDayId);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercise",
                columns: table => new
                {
                    WorkoutExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutDayId = table.Column<int>(type: "int", nullable: true),
                    WorkoutTemplateId = table.Column<int>(type: "int", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    NoOfSets = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercise", x => x.WorkoutExerciseId);
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
                    LiftingStatAuditId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSet_WorkoutExerciseId",
                table: "WorkoutSet",
                column: "WorkoutExerciseId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "WorkoutDay");

            migrationBuilder.DropTable(
                name: "WorkoutSet");

            migrationBuilder.DropTable(
                name: "WorkoutExercise");
        }
    }
}
