using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class tonnagedayv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TonnageDayExerciseId",
                table: "ProgramLogExercise",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogExercise_TonnageDayExerciseId",
                table: "ProgramLogExercise",
                column: "TonnageDayExerciseId",
                unique: true,
                filter: "[TonnageDayExerciseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLogExercise_TonnageDayExercise_TonnageDayExerciseId",
                table: "ProgramLogExercise",
                column: "TonnageDayExerciseId",
                principalTable: "TonnageDayExercise",
                principalColumn: "TonnageDayExerciseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLogExercise_TonnageDayExercise_TonnageDayExerciseId",
                table: "ProgramLogExercise");

            migrationBuilder.DropIndex(
                name: "IX_ProgramLogExercise_TonnageDayExerciseId",
                table: "ProgramLogExercise");

            migrationBuilder.DropColumn(
                name: "TonnageDayExerciseId",
                table: "ProgramLogExercise");
        }
    }
}
