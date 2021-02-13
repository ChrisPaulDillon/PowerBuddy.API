using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class repschemetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeightLifted",
                table: "TemplateRepScheme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WeightLifted",
                table: "TemplateRepScheme",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
