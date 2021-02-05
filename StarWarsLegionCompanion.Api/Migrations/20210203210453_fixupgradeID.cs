using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class fixupgradeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpgradeCategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpgradeCategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpgradeCategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpgradeCategoryId",
                value: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpgradeCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpgradeCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpgradeCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpgradeCategoryId",
                value: 6);
        }
    }
}
