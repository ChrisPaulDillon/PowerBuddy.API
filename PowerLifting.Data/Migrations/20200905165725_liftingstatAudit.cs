using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class liftingstatAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "LiftingStatAudit");

            migrationBuilder.AddColumn<int>(
                name: "LiftingStatId",
                table: "LiftingStatAudit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "LiftingStatAudit",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiftingStatId",
                table: "LiftingStatAudit");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "LiftingStatAudit");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "LiftingStatAudit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
