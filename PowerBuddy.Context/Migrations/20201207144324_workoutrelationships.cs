using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class workoutrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_WorkoutDay_WorkoutDayId",
                table: "WorkoutExercise");

            migrationBuilder.RenameColumn(
                name: "ProgramLogId",
                table: "WorkoutDay",
                newName: "WorkoutLogId");

            migrationBuilder.CreateTable(
                name: "WorkoutLog",
                columns: table => new
                {
                    WorkoutLogId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_WorkoutLog", x => x.WorkoutLogId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDay_WorkoutLogId",
                table: "WorkoutDay",
                column: "WorkoutLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDay_WorkoutLog_WorkoutLogId",
                table: "WorkoutDay",
                column: "WorkoutLogId",
                principalTable: "WorkoutLog",
                principalColumn: "WorkoutLogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_WorkoutDay_WorkoutDayId",
                table: "WorkoutExercise",
                column: "WorkoutDayId",
                principalTable: "WorkoutDay",
                principalColumn: "WorkoutDayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDay_WorkoutLog_WorkoutLogId",
                table: "WorkoutDay");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_WorkoutDay_WorkoutDayId",
                table: "WorkoutExercise");

            migrationBuilder.DropTable(
                name: "WorkoutLog");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutDay_WorkoutLogId",
                table: "WorkoutDay");

            migrationBuilder.RenameColumn(
                name: "WorkoutLogId",
                table: "WorkoutDay",
                newName: "ProgramLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_WorkoutDay_WorkoutDayId",
                table: "WorkoutExercise",
                column: "WorkoutDayId",
                principalTable: "WorkoutDay",
                principalColumn: "WorkoutDayId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
