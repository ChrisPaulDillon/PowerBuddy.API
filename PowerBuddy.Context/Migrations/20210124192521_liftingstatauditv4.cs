using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class liftingstatauditv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiftingStatAudit_WorkoutSet_WorkoutSetId",
                table: "LiftingStatAudit");

            migrationBuilder.AddForeignKey(
                name: "FK_LiftingStatAudit_WorkoutSet_WorkoutSetId",
                table: "LiftingStatAudit",
                column: "WorkoutSetId",
                principalTable: "WorkoutSet",
                principalColumn: "WorkoutSetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiftingStatAudit_WorkoutSet_WorkoutSetId",
                table: "LiftingStatAudit");

            migrationBuilder.AddForeignKey(
                name: "FK_LiftingStatAudit_WorkoutSet_WorkoutSetId",
                table: "LiftingStatAudit",
                column: "WorkoutSetId",
                principalTable: "WorkoutSet",
                principalColumn: "WorkoutSetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
