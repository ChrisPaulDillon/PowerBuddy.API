using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class repscheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProgramLogId",
                table: "ProgramLogRepScheme",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLogRepScheme_ProgramLogId",
                table: "ProgramLogRepScheme",
                column: "ProgramLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProgramLogRepScheme_ProgramLogId",
                table: "ProgramLogRepScheme");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramLogId",
                table: "ProgramLogRepScheme",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
