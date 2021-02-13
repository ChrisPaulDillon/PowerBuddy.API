using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class exercisetemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateExercise_Exercise_ExerciseId",
                table: "TemplateExercise");

            migrationBuilder.DropIndex(
                name: "IX_TemplateExercise_ExerciseId",
                table: "TemplateExercise");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Exercise",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_TemplateExercise_ExerciseId",
                table: "Exercise",
                column: "ExerciseId",
                principalTable: "TemplateExercise",
                principalColumn: "TemplateExerciseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_TemplateExercise_ExerciseId",
                table: "Exercise");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Exercise",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExercise_ExerciseId",
                table: "TemplateExercise",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateExercise_Exercise_ExerciseId",
                table: "TemplateExercise",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
