using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class tecremoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateExerciseCollection");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemplateExerciseCollection",
                columns: table => new
                {
                    TemplateExerciseCollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    TemplateProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateExerciseCollection", x => x.TemplateExerciseCollectionId);
                    table.ForeignKey(
                        name: "FK_TemplateExerciseCollection_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateExerciseCollection_TemplateProgram_TemplateProgramId",
                        column: x => x.TemplateProgramId,
                        principalTable: "TemplateProgram",
                        principalColumn: "TemplateProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExerciseCollection_ExerciseId",
                table: "TemplateExerciseCollection",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExerciseCollection_TemplateProgramId",
                table: "TemplateExerciseCollection",
                column: "TemplateProgramId");
        }
    }
}
