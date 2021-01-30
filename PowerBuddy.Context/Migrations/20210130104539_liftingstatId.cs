using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class liftingstatId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProgramLogRepScheme_LiftingStatAuditId",
                table: "ProgramLogRepScheme");

            migrationBuilder.DropColumn(
                name: "LiftingStatId",
                table: "IdentityUser");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogRepScheme_LiftingStatAuditId",
                table: "ProgramLogRepScheme",
                column: "LiftingStatAuditId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProgramLogRepScheme_LiftingStatAuditId",
                table: "ProgramLogRepScheme");

            migrationBuilder.AddColumn<int>(
                name: "LiftingStatId",
                table: "IdentityUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogRepScheme_LiftingStatAuditId",
                table: "ProgramLogRepScheme",
                column: "LiftingStatAuditId",
                unique: true,
                filter: "[LiftingStatAuditId] IS NOT NULL");
        }
    }
}
