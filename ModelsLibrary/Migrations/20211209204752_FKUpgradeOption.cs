using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class FKUpgradeOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeywordUpgrade_Upgrade_UpgradesId",
                table: "KeywordUpgrade");

            migrationBuilder.DropForeignKey(
                name: "FK_Upgrade_Weapon_WeaponId",
                table: "Upgrade");

            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeOption_Units_UnitId",
                table: "UpgradeOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UpgradeOption",
                table: "UpgradeOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Upgrade",
                table: "Upgrade");

            migrationBuilder.RenameTable(
                name: "UpgradeOption",
                newName: "UpgradeOptions");

            migrationBuilder.RenameTable(
                name: "Upgrade",
                newName: "Upgrades");

            migrationBuilder.RenameIndex(
                name: "IX_UpgradeOption_UnitId",
                table: "UpgradeOptions",
                newName: "IX_UpgradeOptions_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Upgrade_WeaponId",
                table: "Upgrades",
                newName: "IX_Upgrades_WeaponId");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "UpgradeOptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpgradeOptions",
                table: "UpgradeOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Upgrades",
                table: "Upgrades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordUpgrade_Upgrades_UpgradesId",
                table: "KeywordUpgrade",
                column: "UpgradesId",
                principalTable: "Upgrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeOptions_Units_UnitId",
                table: "UpgradeOptions",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Upgrades_Weapon_WeaponId",
                table: "Upgrades",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeywordUpgrade_Upgrades_UpgradesId",
                table: "KeywordUpgrade");

            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeOptions_Units_UnitId",
                table: "UpgradeOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Upgrades_Weapon_WeaponId",
                table: "Upgrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Upgrades",
                table: "Upgrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UpgradeOptions",
                table: "UpgradeOptions");

            migrationBuilder.RenameTable(
                name: "Upgrades",
                newName: "Upgrade");

            migrationBuilder.RenameTable(
                name: "UpgradeOptions",
                newName: "UpgradeOption");

            migrationBuilder.RenameIndex(
                name: "IX_Upgrades_WeaponId",
                table: "Upgrade",
                newName: "IX_Upgrade_WeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_UpgradeOptions_UnitId",
                table: "UpgradeOption",
                newName: "IX_UpgradeOption_UnitId");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "UpgradeOption",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Upgrade",
                table: "Upgrade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpgradeOption",
                table: "UpgradeOption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordUpgrade_Upgrade_UpgradesId",
                table: "KeywordUpgrade",
                column: "UpgradesId",
                principalTable: "Upgrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Upgrade_Weapon_WeaponId",
                table: "Upgrade",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeOption_Units_UnitId",
                table: "UpgradeOption",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
