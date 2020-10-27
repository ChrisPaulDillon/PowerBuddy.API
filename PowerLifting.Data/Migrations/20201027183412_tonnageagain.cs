using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class tonnageagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLogExerciseTonnage_ProgramLogExercise_ProgramLogExerciseId",
                table: "ProgramLogExerciseTonnage");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLogExerciseTonnage_ProgramLogExercise_ProgramLogExerciseId",
                table: "ProgramLogExerciseTonnage",
                column: "ProgramLogExerciseId",
                principalTable: "ProgramLogExercise",
                principalColumn: "ProgramLogExerciseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLogExerciseTonnage_ProgramLogExercise_ProgramLogExerciseId",
                table: "ProgramLogExerciseTonnage");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLogExerciseTonnage_ProgramLogExercise_ProgramLogExerciseId",
                table: "ProgramLogExerciseTonnage",
                column: "ProgramLogExerciseId",
                principalTable: "ProgramLogExercise",
                principalColumn: "ProgramLogExerciseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
