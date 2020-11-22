using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class repScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "ProgramLogRepScheme");

            migrationBuilder.AddColumn<int>(
                name: "LiftingStatAuditId",
                table: "ProgramLogRepScheme",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgramLogRepSchemeId",
                table: "LiftingStatAudit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiftingStatAuditId",
                table: "ProgramLogRepScheme");

            migrationBuilder.DropColumn(
                name: "ProgramLogRepSchemeId",
                table: "LiftingStatAudit");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "ProgramLogRepScheme",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
