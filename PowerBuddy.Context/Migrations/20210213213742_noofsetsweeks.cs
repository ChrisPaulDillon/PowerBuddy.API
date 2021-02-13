using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class noofsetsweeks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfWeeks",
                table: "TemplateProgram");

            migrationBuilder.DropColumn(
                name: "NoOfSets",
                table: "TemplateExercise");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoOfWeeks",
                table: "TemplateProgram",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoOfSets",
                table: "TemplateExercise",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
