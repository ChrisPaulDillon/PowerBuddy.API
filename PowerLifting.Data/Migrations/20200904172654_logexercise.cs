using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class logexercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramLogExerciseId1",
                table: "ProgramLogRepScheme",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogRepScheme_ProgramLogExerciseId1",
                table: "ProgramLogRepScheme",
                column: "ProgramLogExerciseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLogRepScheme_ProgramLogExercise_ProgramLogExerciseId1",
                table: "ProgramLogRepScheme",
                column: "ProgramLogExerciseId1",
                principalTable: "ProgramLogExercise",
                principalColumn: "ProgramLogExerciseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLogRepScheme_ProgramLogExercise_ProgramLogExerciseId1",
                table: "ProgramLogRepScheme");

            migrationBuilder.DropIndex(
                name: "IX_ProgramLogRepScheme_ProgramLogExerciseId1",
                table: "ProgramLogRepScheme");

            migrationBuilder.DropColumn(
                name: "ProgramLogExerciseId1",
                table: "ProgramLogRepScheme");
        }
    }
}
