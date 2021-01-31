using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class AddUpgradeCategries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitUpgradeCategory_UpgradeCategory_UpgradeCategoriesId",
                table: "UnitUpgradeCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeCategory_Upgrades_UpgradeId1",
                table: "UpgradeCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UpgradeCategory",
                table: "UpgradeCategory");

            migrationBuilder.RenameTable(
                name: "UpgradeCategory",
                newName: "UpgradeCategories");

            migrationBuilder.RenameIndex(
                name: "IX_UpgradeCategory_UpgradeId1",
                table: "UpgradeCategories",
                newName: "IX_UpgradeCategories_UpgradeId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpgradeCategories",
                table: "UpgradeCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitUpgradeCategory_UpgradeCategories_UpgradeCategoriesId",
                table: "UnitUpgradeCategory",
                column: "UpgradeCategoriesId",
                principalTable: "UpgradeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeCategories_Upgrades_UpgradeId1",
                table: "UpgradeCategories",
                column: "UpgradeId1",
                principalTable: "Upgrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitUpgradeCategory_UpgradeCategories_UpgradeCategoriesId",
                table: "UnitUpgradeCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeCategories_Upgrades_UpgradeId1",
                table: "UpgradeCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UpgradeCategories",
                table: "UpgradeCategories");

            migrationBuilder.RenameTable(
                name: "UpgradeCategories",
                newName: "UpgradeCategory");

            migrationBuilder.RenameIndex(
                name: "IX_UpgradeCategories_UpgradeId1",
                table: "UpgradeCategory",
                newName: "IX_UpgradeCategory_UpgradeId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpgradeCategory",
                table: "UpgradeCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitUpgradeCategory_UpgradeCategory_UpgradeCategoriesId",
                table: "UnitUpgradeCategory",
                column: "UpgradeCategoriesId",
                principalTable: "UpgradeCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeCategory_Upgrades_UpgradeId1",
                table: "UpgradeCategory",
                column: "UpgradeId1",
                principalTable: "Upgrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
