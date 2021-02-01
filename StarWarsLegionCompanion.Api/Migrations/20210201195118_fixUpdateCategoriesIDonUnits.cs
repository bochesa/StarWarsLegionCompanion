using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class fixUpdateCategoriesIDonUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 50, 5 });

            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 50, 19 });

            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 50, 33 });

            migrationBuilder.InsertData(
                table: "UnitUpgradeCategory",
                columns: new[] { "UnitsId", "UpgradeCategoriesId" },
                values: new object[,]
                {
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 16 },
                    { 50, 13 },
                    { 50, 14 },
                    { 50, 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 50, 13 });

            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 50, 14 });

            migrationBuilder.DeleteData(
                table: "UnitUpgradeCategory",
                keyColumns: new[] { "UnitsId", "UpgradeCategoriesId" },
                keyValues: new object[] { 50, 15 });

            migrationBuilder.InsertData(
                table: "UnitUpgradeCategory",
                columns: new[] { "UnitsId", "UpgradeCategoriesId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 1, 19 },
                    { 1, 6 },
                    { 50, 5 },
                    { 50, 19 },
                    { 50, 33 }
                });
        }
    }
}
