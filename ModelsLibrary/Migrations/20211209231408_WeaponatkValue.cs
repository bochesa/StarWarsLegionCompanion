using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class WeaponatkValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeOptions_Units_UnitId",
                table: "UpgradeOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UpgradeOptions",
                table: "UpgradeOptions");

            migrationBuilder.RenameTable(
                name: "UpgradeOptions",
                newName: "UpgradeOption");

            migrationBuilder.RenameIndex(
                name: "IX_UpgradeOptions_UnitId",
                table: "UpgradeOption",
                newName: "IX_UpgradeOption_UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpgradeOption",
                table: "UpgradeOption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeOption_Units_UnitId",
                table: "UpgradeOption",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeOption_Units_UnitId",
                table: "UpgradeOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UpgradeOption",
                table: "UpgradeOption");

            migrationBuilder.RenameTable(
                name: "UpgradeOption",
                newName: "UpgradeOptions");

            migrationBuilder.RenameIndex(
                name: "IX_UpgradeOption_UnitId",
                table: "UpgradeOptions",
                newName: "IX_UpgradeOptions_UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpgradeOptions",
                table: "UpgradeOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeOptions_Units_UnitId",
                table: "UpgradeOptions",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
