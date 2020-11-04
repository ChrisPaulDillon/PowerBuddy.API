using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class liftinglevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveQuotes",
                table: "UserSetting");

            migrationBuilder.DropColumn(
                name: "BodyWeight",
                table: "IdentityUser");

            migrationBuilder.DropColumn(
                name: "LiftingLevel",
                table: "IdentityUser");

            migrationBuilder.DropColumn(
                name: "QuotesEnabled",
                table: "IdentityUser");

            migrationBuilder.AddColumn<int>(
                name: "LiftingLevelId",
                table: "UserSetting",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "QuotesEnabled",
                table: "UserSetting",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "LiftingLevel",
                columns: table => new
                {
                    LiftingLevelId = table.Column<int>(nullable: false),
                    LiftingLevelStr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingLevel", x => x.LiftingLevelId);
                    table.ForeignKey(
                        name: "FK_LiftingLevel_UserSetting_LiftingLevelId",
                        column: x => x.LiftingLevelId,
                        principalTable: "UserSetting",
                        principalColumn: "UserSettingId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiftingLevel");

            migrationBuilder.DropColumn(
                name: "LiftingLevelId",
                table: "UserSetting");

            migrationBuilder.DropColumn(
                name: "QuotesEnabled",
                table: "UserSetting");

            migrationBuilder.AddColumn<bool>(
                name: "ActiveQuotes",
                table: "UserSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "BodyWeight",
                table: "IdentityUser",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LiftingLevel",
                table: "IdentityUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "QuotesEnabled",
                table: "IdentityUser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
