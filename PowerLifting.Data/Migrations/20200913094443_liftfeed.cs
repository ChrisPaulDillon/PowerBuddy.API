using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class liftfeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LiftingStatAudit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "LiftingStatAudit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStatAudit_ExerciseId",
                table: "LiftingStatAudit",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStatAudit_UserId",
                table: "LiftingStatAudit",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LiftingStatAudit_Exercise_ExerciseId",
                table: "LiftingStatAudit",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LiftingStatAudit_IdentityUser_UserId",
                table: "LiftingStatAudit",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiftingStatAudit_Exercise_ExerciseId",
                table: "LiftingStatAudit");

            migrationBuilder.DropForeignKey(
                name: "FK_LiftingStatAudit_IdentityUser_UserId",
                table: "LiftingStatAudit");

            migrationBuilder.DropIndex(
                name: "IX_LiftingStatAudit_ExerciseId",
                table: "LiftingStatAudit");

            migrationBuilder.DropIndex(
                name: "IX_LiftingStatAudit_UserId",
                table: "LiftingStatAudit");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "LiftingStatAudit");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LiftingStatAudit",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
