using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerBuddy.Data.Context.Migrations
{
    public partial class templateprogramrework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_TemplateDay_TemplateWeek_TemplateWeekId",
            //    table: "TemplateDay");

            //migrationBuilder.DropTable(
            //    name: "TemplateWeek");

            //migrationBuilder.DropIndex( **
            //    name: "IX_TemplateDay_TemplateWeekId",
            //    table: "TemplateDay");

            //migrationBuilder.RenameColumn(
            //    name: "TemplateWeekId",
            //    table: "TemplateDay",
            //    newName: "WeekNo");

            //migrationBuilder.AddColumn<int>(
            //    name: "TemplateProgramId",
            //    table: "TemplateDay",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_TemplateDay_TemplateProgramId",
            //    table: "TemplateDay",
            //    column: "TemplateProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateDay_TemplateProgram_TemplateProgramId",
                table: "TemplateDay",
                column: "TemplateProgramId",
                principalTable: "TemplateProgram",
                principalColumn: "TemplateProgramId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateDay_TemplateProgram_TemplateProgramId",
                table: "TemplateDay");

            migrationBuilder.DropIndex(
                name: "IX_TemplateDay_TemplateProgramId",
                table: "TemplateDay");

            migrationBuilder.DropColumn(
                name: "TemplateProgramId",
                table: "TemplateDay");

            migrationBuilder.RenameColumn(
                name: "WeekNo",
                table: "TemplateDay",
                newName: "TemplateWeekId");

            migrationBuilder.CreateTable(
                name: "TemplateWeek",
                columns: table => new
                {
                    TemplateWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateProgramId = table.Column<int>(type: "int", nullable: false),
                    WeekNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateWeek", x => x.TemplateWeekId);
                    table.ForeignKey(
                        name: "FK_TemplateWeek_TemplateProgram_TemplateProgramId",
                        column: x => x.TemplateProgramId,
                        principalTable: "TemplateProgram",
                        principalColumn: "TemplateProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateDay_TemplateWeekId",
                table: "TemplateDay",
                column: "TemplateWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateWeek_TemplateProgramId",
                table: "TemplateWeek",
                column: "TemplateProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateDay_TemplateWeek_TemplateWeekId",
                table: "TemplateDay",
                column: "TemplateWeekId",
                principalTable: "TemplateWeek",
                principalColumn: "TemplateWeekId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
