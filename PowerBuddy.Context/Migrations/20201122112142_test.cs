using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LiftingStatAudit_ExerciseId",
                table: "LiftingStatAudit");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStatAudit_ExerciseId",
                table: "LiftingStatAudit",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LiftingStatAudit_ExerciseId",
                table: "LiftingStatAudit");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStatAudit_ExerciseId",
                table: "LiftingStatAudit",
                column: "ExerciseId",
                unique: true);
        }
    }
}
