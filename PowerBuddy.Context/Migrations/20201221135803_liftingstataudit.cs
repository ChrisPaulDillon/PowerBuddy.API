using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class liftingstataudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiftingStatAudit_ProgramLogRepScheme_ProgramLogRepSchemeId",
                table: "LiftingStatAudit");

            migrationBuilder.DropIndex(
                name: "IX_LiftingStatAudit_ProgramLogRepSchemeId",
                table: "LiftingStatAudit");

            migrationBuilder.DropColumn(
                name: "ProgramLogRepSchemeId",
                table: "LiftingStatAudit");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogRepScheme_LiftingStatAuditId",
                table: "ProgramLogRepScheme",
                column: "LiftingStatAuditId",
                unique: true,
                filter: "[LiftingStatAuditId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLogRepScheme_LiftingStatAudit_LiftingStatAuditId",
                table: "ProgramLogRepScheme",
                column: "LiftingStatAuditId",
                principalTable: "LiftingStatAudit",
                principalColumn: "LiftingStatAuditId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLogRepScheme_LiftingStatAudit_LiftingStatAuditId",
                table: "ProgramLogRepScheme");

            migrationBuilder.DropIndex(
                name: "IX_ProgramLogRepScheme_LiftingStatAuditId",
                table: "ProgramLogRepScheme");

            migrationBuilder.AddColumn<int>(
                name: "ProgramLogRepSchemeId",
                table: "LiftingStatAudit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStatAudit_ProgramLogRepSchemeId",
                table: "LiftingStatAudit",
                column: "ProgramLogRepSchemeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LiftingStatAudit_ProgramLogRepScheme_ProgramLogRepSchemeId",
                table: "LiftingStatAudit",
                column: "ProgramLogRepSchemeId",
                principalTable: "ProgramLogRepScheme",
                principalColumn: "ProgramLogRepSchemeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
