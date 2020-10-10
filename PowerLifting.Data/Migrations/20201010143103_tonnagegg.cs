using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class tonnagegg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TonnageDayId",
                table: "ProgramLogDay",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TonnageLog",
                columns: table => new
                {
                    TonnageLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProgramLogId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    TotalTonnage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonnageLog", x => x.TonnageLogId);
                });

            migrationBuilder.CreateTable(
                name: "TonnageDay",
                columns: table => new
                {
                    TonnageDayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProgramLogId = table.Column<int>(nullable: false),
                    ProgramLogDayId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    DayTonnage = table.Column<decimal>(nullable: false),
                    TonnageLogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonnageDay", x => x.TonnageDayId);
                    table.ForeignKey(
                        name: "FK_TonnageDay_TonnageLog_TonnageLogId",
                        column: x => x.TonnageLogId,
                        principalTable: "TonnageLog",
                        principalColumn: "TonnageLogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TonnageWeek",
                columns: table => new
                {
                    TonnageWeekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProgramLogId = table.Column<int>(nullable: false),
                    ProgramLogWeekId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    WeekTonnage = table.Column<decimal>(nullable: false),
                    TonnageLogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonnageWeek", x => x.TonnageWeekId);
                    table.ForeignKey(
                        name: "FK_TonnageWeek_TonnageLog_TonnageLogId",
                        column: x => x.TonnageLogId,
                        principalTable: "TonnageLog",
                        principalColumn: "TonnageLogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogDay_TonnageDayId",
                table: "ProgramLogDay",
                column: "TonnageDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TonnageDay_TonnageLogId",
                table: "TonnageDay",
                column: "TonnageLogId");

            migrationBuilder.CreateIndex(
                name: "IX_TonnageWeek_TonnageLogId",
                table: "TonnageWeek",
                column: "TonnageLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLogDay_TonnageDay_TonnageDayId",
                table: "ProgramLogDay",
                column: "TonnageDayId",
                principalTable: "TonnageDay",
                principalColumn: "TonnageDayId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLogDay_TonnageDay_TonnageDayId",
                table: "ProgramLogDay");

            migrationBuilder.DropTable(
                name: "TonnageDay");

            migrationBuilder.DropTable(
                name: "TonnageWeek");

            migrationBuilder.DropTable(
                name: "TonnageLog");

            migrationBuilder.DropIndex(
                name: "IX_ProgramLogDay_TonnageDayId",
                table: "ProgramLogDay");

            migrationBuilder.DropColumn(
                name: "TonnageDayId",
                table: "ProgramLogDay");

            migrationBuilder.DropColumn(
                name: "TonnageDayId",
                table: "ProgramLogDay");

            migrationBuilder.AddColumn<int>(
                name: "ProgramLogId",
                table: "ProgramLogRepScheme",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLogRepScheme_ProgramLog_ProgramLogId",
                table: "ProgramLogRepScheme",
                column: "ProgramLogId",
                principalTable: "ProgramLog",
                principalColumn: "ProgramLogId");
        }
    }
}
