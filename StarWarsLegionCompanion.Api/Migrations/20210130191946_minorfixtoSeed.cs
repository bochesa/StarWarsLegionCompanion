using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class minorfixtoSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.UpdateData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 20,
                column: "ChosenUnitId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 21,
                column: "ChosenUnitId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 22,
                column: "ChosenUnitId",
                value: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 20,
                column: "ChosenUnitId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 21,
                column: "ChosenUnitId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 22,
                column: "ChosenUnitId",
                value: 3);

            migrationBuilder.InsertData(
                table: "ChosenUpgrades",
                columns: new[] { "Id", "ChosenUnitId", "UpgradeId" },
                values: new object[] { 23, 3, 5 });
        }
    }
}
