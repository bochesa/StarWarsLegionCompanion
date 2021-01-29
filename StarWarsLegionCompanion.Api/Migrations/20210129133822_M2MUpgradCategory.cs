using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class M2MUpgradCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
