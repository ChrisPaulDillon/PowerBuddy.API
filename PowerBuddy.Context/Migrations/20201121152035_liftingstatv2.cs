using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class liftingstat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiftingStatAudit_LiftingStat_LiftingStatId",
                table: "LiftingStatAudit");

            //migrationBuilder.DropTable(
            //    name: "LiftingStat");

            migrationBuilder.DropIndex(
                name: "IX_LiftingStatAudit_LiftingStatId",
                table: "LiftingStatAudit");

            migrationBuilder.DropColumn(
                name: "LiftingStatId",
                table: "LiftingStatAudit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LiftingStatId",
                table: "LiftingStatAudit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LiftingStat",
                columns: table => new
                {
                    LiftingStatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    GoalWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PercentageToGoal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RepRange = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingStat", x => x.LiftingStatId);
                    table.ForeignKey(
                        name: "FK_LiftingStat_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStatAudit_LiftingStatId",
                table: "LiftingStatAudit",
                column: "LiftingStatId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingStat_ExerciseId",
                table: "LiftingStat",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_LiftingStatAudit_LiftingStat_LiftingStatId",
                table: "LiftingStatAudit",
                column: "LiftingStatId",
                principalTable: "LiftingStat",
                principalColumn: "LiftingStatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
