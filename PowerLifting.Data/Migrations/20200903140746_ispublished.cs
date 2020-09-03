using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class ispublished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "TemplateProgram",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "TemplateProgram");
        }
    }
}
