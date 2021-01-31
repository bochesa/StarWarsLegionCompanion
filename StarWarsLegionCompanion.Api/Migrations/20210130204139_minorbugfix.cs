using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class minorbugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 22,
                column: "UpgradeId",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 22,
                column: "UpgradeId",
                value: 5);
        }
    }
}
