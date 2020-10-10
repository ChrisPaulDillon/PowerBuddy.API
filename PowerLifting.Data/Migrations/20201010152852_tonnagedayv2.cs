using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class tonnagedayv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TonnageLogExercise",
                columns: table => new
                {
                    TonnageLogExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProgramLogId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    TotalTonnage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonnageLogExercise", x => x.TonnageLogExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "TonnageDayExercise",
                columns: table => new
                {
                    TonnageDayExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProgramLogId = table.Column<int>(nullable: false),
                    ProgramLogDayId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    DayTonnage = table.Column<decimal>(nullable: false),
                    TonnageLogExerciseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonnageDayExercise", x => x.TonnageDayExerciseId);
                    table.ForeignKey(
                        name: "FK_TonnageDayExercise_TonnageLogExercise_TonnageLogExerciseId",
                        column: x => x.TonnageLogExerciseId,
                        principalTable: "TonnageLogExercise",
                        principalColumn: "TonnageLogExerciseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TonnageWeekExercise",
                columns: table => new
                {
                    TonnageWeekExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProgramLogId = table.Column<int>(nullable: false),
                    ProgramLogWeekId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    WeekTonnage = table.Column<decimal>(nullable: false),
                    TonnageLogExerciseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonnageWeekExercise", x => x.TonnageWeekExerciseId);
                    table.ForeignKey(
                        name: "FK_TonnageWeekExercise_TonnageLogExercise_TonnageLogExerciseId",
                        column: x => x.TonnageLogExerciseId,
                        principalTable: "TonnageLogExercise",
                        principalColumn: "TonnageLogExerciseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TonnageDayExercise_TonnageLogExerciseId",
                table: "TonnageDayExercise",
                column: "TonnageLogExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TonnageWeekExercise_TonnageLogExerciseId",
                table: "TonnageWeekExercise",
                column: "TonnageLogExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TonnageDayExercise");

            migrationBuilder.DropTable(
                name: "TonnageWeekExercise");

            migrationBuilder.DropTable(
                name: "TonnageLogExercise");

            migrationBuilder.AddColumn<int>(
                name: "TonnageDayId",
                table: "ProgramLogDay",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TonnageLog",
                columns: table => new
                {
                    TonnageLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    ProgramLogId = table.Column<int>(type: "int", nullable: false),
                    TotalTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonnageLog", x => x.TonnageLogId);
                });

            migrationBuilder.CreateTable(
                name: "TonnageDay",
                columns: table => new
                {
                    TonnageDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    ProgramLogDayId = table.Column<int>(type: "int", nullable: false),
                    ProgramLogId = table.Column<int>(type: "int", nullable: false),
                    TonnageLogId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    TonnageWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    ProgramLogId = table.Column<int>(type: "int", nullable: false),
                    ProgramLogWeekId = table.Column<int>(type: "int", nullable: false),
                    TonnageLogId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
    }
}
