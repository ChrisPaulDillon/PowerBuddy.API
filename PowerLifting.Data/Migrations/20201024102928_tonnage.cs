using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class tonnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLogExercise_TonnageDayExercise_TonnageDayExerciseId",
                table: "ProgramLogExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLogRepScheme_ProgramLogExercise_ProgramLogExerciseId1",
                table: "ProgramLogRepScheme");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateExerciseCollection_TemplateProgram_TemplateProgramId",
                table: "TemplateExerciseCollection");

            migrationBuilder.DropTable(
                name: "TonnageDayExercise");

            migrationBuilder.DropTable(
                name: "TonnageWeekExercise");

            migrationBuilder.DropTable(
                name: "TonnageLogExercise");

            migrationBuilder.DropIndex(
                name: "IX_ProgramLogRepScheme_ProgramLogExerciseId1",
                table: "ProgramLogRepScheme");

            migrationBuilder.DropIndex(
                name: "IX_ProgramLogExercise_TonnageDayExerciseId",
                table: "ProgramLogExercise");

            migrationBuilder.DropColumn(
                name: "ProgramLogExerciseId1",
                table: "ProgramLogRepScheme");

            migrationBuilder.DropColumn(
                name: "TonnageDayExerciseId",
                table: "ProgramLogExercise");

            migrationBuilder.AddColumn<int>(
                name: "ProgramLogExerciseTonnageId",
                table: "ProgramLogExercise",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserToId",
                table: "FriendRequest",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserFromId",
                table: "FriendRequest",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProgramLogExerciseTonnage",
                columns: table => new
                {
                    ProgramLogExerciseTonnageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLogExerciseId = table.Column<int>(nullable: false),
                    ExerciseTonnage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLogExerciseTonnage", x => x.ProgramLogExerciseTonnageId);
                    table.ForeignKey(
                        name: "FK_ProgramLogExerciseTonnage_ProgramLogExercise_ProgramLogExerciseId",
                        column: x => x.ProgramLogExerciseId,
                        principalTable: "ProgramLogExercise",
                        principalColumn: "ProgramLogExerciseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExerciseCollection_ExerciseId",
                table: "TemplateExerciseCollection",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_UserFromId",
                table: "FriendRequest",
                column: "UserFromId",
                unique: true,
                filter: "[UserFromId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_UserToId",
                table: "FriendRequest",
                column: "UserToId",
                unique: true,
                filter: "[UserToId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogExerciseTonnage_ProgramLogExerciseId",
                table: "ProgramLogExerciseTonnage",
                column: "ProgramLogExerciseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequest_IdentityUser_UserFromId",
                table: "FriendRequest",
                column: "UserFromId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequest_IdentityUser_UserToId",
                table: "FriendRequest",
                column: "UserToId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateExerciseCollection_Exercise_ExerciseId",
                table: "TemplateExerciseCollection",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateExerciseCollection_TemplateProgram_TemplateProgramId",
                table: "TemplateExerciseCollection",
                column: "TemplateProgramId",
                principalTable: "TemplateProgram",
                principalColumn: "TemplateProgramId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequest_IdentityUser_UserFromId",
                table: "FriendRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequest_IdentityUser_UserToId",
                table: "FriendRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateExerciseCollection_Exercise_ExerciseId",
                table: "TemplateExerciseCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateExerciseCollection_TemplateProgram_TemplateProgramId",
                table: "TemplateExerciseCollection");

            migrationBuilder.DropTable(
                name: "ProgramLogExerciseTonnage");

            migrationBuilder.DropIndex(
                name: "IX_TemplateExerciseCollection_ExerciseId",
                table: "TemplateExerciseCollection");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequest_UserFromId",
                table: "FriendRequest");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequest_UserToId",
                table: "FriendRequest");

            migrationBuilder.DropColumn(
                name: "ProgramLogExerciseTonnageId",
                table: "ProgramLogExercise");

            migrationBuilder.AddColumn<int>(
                name: "ProgramLogExerciseId1",
                table: "ProgramLogRepScheme",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TonnageDayExerciseId",
                table: "ProgramLogExercise",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserToId",
                table: "FriendRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserFromId",
                table: "FriendRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TonnageLogExercise",
                columns: table => new
                {
                    TonnageLogExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    ProgramLogId = table.Column<int>(type: "int", nullable: false),
                    TotalTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonnageLogExercise", x => x.TonnageLogExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "TonnageDayExercise",
                columns: table => new
                {
                    TonnageDayExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    ProgramLogDayId = table.Column<int>(type: "int", nullable: false),
                    ProgramLogId = table.Column<int>(type: "int", nullable: false),
                    TonnageLogExerciseId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    TonnageWeekExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    ProgramLogId = table.Column<int>(type: "int", nullable: false),
                    ProgramLogWeekId = table.Column<int>(type: "int", nullable: false),
                    TonnageLogExerciseId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                name: "IX_ProgramLogRepScheme_ProgramLogExerciseId1",
                table: "ProgramLogRepScheme",
                column: "ProgramLogExerciseId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogExercise_TonnageDayExerciseId",
                table: "ProgramLogExercise",
                column: "TonnageDayExerciseId",
                unique: true,
                filter: "[TonnageDayExerciseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TonnageDayExercise_TonnageLogExerciseId",
                table: "TonnageDayExercise",
                column: "TonnageLogExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TonnageWeekExercise_TonnageLogExerciseId",
                table: "TonnageWeekExercise",
                column: "TonnageLogExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLogExercise_TonnageDayExercise_TonnageDayExerciseId",
                table: "ProgramLogExercise",
                column: "TonnageDayExerciseId",
                principalTable: "TonnageDayExercise",
                principalColumn: "TonnageDayExerciseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLogRepScheme_ProgramLogExercise_ProgramLogExerciseId1",
                table: "ProgramLogRepScheme",
                column: "ProgramLogExerciseId1",
                principalTable: "ProgramLogExercise",
                principalColumn: "ProgramLogExerciseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateExerciseCollection_TemplateProgram_TemplateProgramId",
                table: "TemplateExerciseCollection",
                column: "TemplateProgramId",
                principalTable: "TemplateProgram",
                principalColumn: "TemplateProgramId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
