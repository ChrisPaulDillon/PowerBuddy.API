using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class pbprogramlogrepscheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalBest",
                table: "ProgramLogRepScheme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PersonalBest",
                table: "ProgramLogRepScheme",
                type: "bit",
                nullable: true);
        }
    }
}
