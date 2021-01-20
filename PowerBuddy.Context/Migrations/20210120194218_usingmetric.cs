using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class usingmetric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkoutDay",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDay_UserId",
                table: "WorkoutDay",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDay_IdentityUser_UserId",
                table: "WorkoutDay",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDay_IdentityUser_UserId",
                table: "WorkoutDay");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutDay_UserId",
                table: "WorkoutDay");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkoutDay",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
