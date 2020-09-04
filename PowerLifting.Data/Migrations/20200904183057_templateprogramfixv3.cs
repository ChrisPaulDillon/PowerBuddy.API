using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class templateprogramfixv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProgramLog_TemplateProgramId",
                table: "ProgramLog");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLog_TemplateProgramId",
                table: "ProgramLog",
                column: "TemplateProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProgramLog_TemplateProgramId",
                table: "ProgramLog");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLog_TemplateProgramId",
                table: "ProgramLog",
                column: "TemplateProgramId",
                unique: true,
                filter: "[TemplateProgramId] IS NOT NULL");
        }
    }
}
