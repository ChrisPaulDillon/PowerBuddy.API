using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class workouttemplatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkoutTemplateId",
                table: "ProgramLogExercise",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogExercise_WorkoutTemplateId",
                table: "ProgramLogExercise",
                column: "WorkoutTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLogExercise_WorkoutTemplate_WorkoutTemplateId",
                table: "ProgramLogExercise",
                column: "WorkoutTemplateId",
                principalTable: "WorkoutTemplate",
                principalColumn: "WorkoutTemplateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLogExercise_WorkoutTemplate_WorkoutTemplateId",
                table: "ProgramLogExercise");

            migrationBuilder.DropIndex(
                name: "IX_ProgramLogExercise_WorkoutTemplateId",
                table: "ProgramLogExercise");

            migrationBuilder.DropColumn(
                name: "WorkoutTemplateId",
                table: "ProgramLogExercise");
        }
    }
}
