using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class testttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiftingStatAudit_Exercise_ExerciseId",
                table: "LiftingStatAudit");

            migrationBuilder.AddForeignKey(
                name: "FK_LiftingStatAudit_Exercise_ExerciseId",
                table: "LiftingStatAudit",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiftingStatAudit_Exercise_ExerciseId",
                table: "LiftingStatAudit");

            migrationBuilder.AddForeignKey(
                name: "FK_LiftingStatAudit_Exercise_ExerciseId",
                table: "LiftingStatAudit",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
