using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerLifting.Data.Migrations
{
    public partial class test2225 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "IdentityUser");

            migrationBuilder.DropColumn(
                name: "Rights",
                table: "IdentityUser");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "IdentityUser",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberStatusId",
                table: "IdentityUser",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "MemberStatus",
                columns: table => new
                {
                    MemberStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberStatus", x => x.MemberStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_GenderId",
                table: "IdentityUser",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_MemberStatusId",
                table: "IdentityUser",
                column: "MemberStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_Gender_GenderId",
                table: "IdentityUser",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_MemberStatus_MemberStatusId",
                table: "IdentityUser",
                column: "MemberStatusId",
                principalTable: "MemberStatus",
                principalColumn: "MemberStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUser_Gender_GenderId",
                table: "IdentityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUser_MemberStatus_MemberStatusId",
                table: "IdentityUser");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "MemberStatus");

            migrationBuilder.DropIndex(
                name: "IX_IdentityUser_GenderId",
                table: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_IdentityUser_MemberStatusId",
                table: "IdentityUser");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "IdentityUser");

            migrationBuilder.DropColumn(
                name: "MemberStatusId",
                table: "IdentityUser");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "IdentityUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rights",
                table: "IdentityUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
