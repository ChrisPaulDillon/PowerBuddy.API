using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class testtttv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiftingStatId",
                table: "LiftingStatAudit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LiftingStatId",
                table: "LiftingStatAudit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
