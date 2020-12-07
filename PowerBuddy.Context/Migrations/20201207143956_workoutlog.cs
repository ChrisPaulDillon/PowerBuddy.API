using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class workoutlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercise_WorkoutDayId",
                table: "WorkoutExercise",
                column: "WorkoutDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_WorkoutDay_WorkoutDayId",
                table: "WorkoutExercise",
                column: "WorkoutDayId",
                principalTable: "WorkoutDay",
                principalColumn: "WorkoutDayId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_WorkoutDay_WorkoutDayId",
                table: "WorkoutExercise");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercise_WorkoutDayId",
                table: "WorkoutExercise");
        }
    }
}
