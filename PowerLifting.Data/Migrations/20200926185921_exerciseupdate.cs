using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class exerciseupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainExercise",
                table: "Exercise",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainExercise",
                table: "Exercise");
        }
    }
}
