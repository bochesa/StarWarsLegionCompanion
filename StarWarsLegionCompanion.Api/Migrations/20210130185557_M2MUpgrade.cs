using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class M2MUpgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keywords_Upgrade_UpgradeId",
                table: "Keywords");

            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeCategory_Upgrade_UpgradeId1",
                table: "UpgradeCategory");

            migrationBuilder.DropIndex(
                name: "IX_Keywords_UpgradeId",
                table: "Keywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Upgrade",
                table: "Upgrade");

            migrationBuilder.DropColumn(
                name: "UpgradeId",
                table: "Keywords");

            migrationBuilder.RenameTable(
                name: "Upgrade",
                newName: "Upgrades");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "ChosenUpgrades",
                newName: "UpgradeId");

            migrationBuilder.RenameColumn(
                name: "ArmyId",
                table: "ChosenUpgrades",
                newName: "ChosenUnitId");

            migrationBuilder.AddColumn<int>(
                name: "UpgradeId",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Upgrades",
                table: "Upgrades",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KeywordUpgrade",
                columns: table => new
                {
                    KeywordsId = table.Column<int>(type: "int", nullable: false),
                    UpgradesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordUpgrade", x => new { x.KeywordsId, x.UpgradesId });
                    table.ForeignKey(
                        name: "FK_KeywordUpgrade_Keywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordUpgrade_Upgrades_UpgradesId",
                        column: x => x.UpgradesId,
                        principalTable: "Upgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChosenUpgrades",
                columns: new[] { "Id", "ChosenUnitId", "UpgradeId" },
                values: new object[,]
                {
                    { 20, 1, 1 },
                    { 21, 1, 3 },
                    { 22, 3, 5 },
                    { 23, 3, 5 },
                    { 24, 13, 2 }
                });

            migrationBuilder.InsertData(
                table: "Upgrades",
                columns: new[] { "Id", "IsExhaustable", "IsFreeAction", "Name", "PointCost", "Text", "UpgradeCategoryId", "WeaponId", "WoundThreshold" },
                values: new object[,]
                {
                    { 1, true, true, "Force Push", 10, "Choose an enemy trooper unit at range 1. Perform a speed-1 move with that unit, even if it is engaged.", 5, 0, null },
                    { 2, true, true, "Force Choke", 5, "Choose a non-commander, non-operative enemy trooper mini at range 1. It suffers 1 wound.", 5, 0, null },
                    { 3, false, false, "Battle Meditation", 10, "While you are issuing orders using a command card, you may issue 1 of those orders to any friendly unit on the battlefield, instead of a unit indicated on the command card.", 5, 0, null },
                    { 4, false, false, "Targeting Scopes", 6, "You gain Precise 1", 6, 0, null }
                });

            migrationBuilder.InsertData(
                table: "KeywordUpgrade",
                columns: new[] { "KeywordsId", "UpgradesId" },
                values: new object[] { 7, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_KeywordUpgrade_UpgradesId",
                table: "KeywordUpgrade",
                column: "UpgradesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeCategory_Upgrades_UpgradeId1",
                table: "UpgradeCategory",
                column: "UpgradeId1",
                principalTable: "Upgrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeCategory_Upgrades_UpgradeId1",
                table: "UpgradeCategory");

            migrationBuilder.DropTable(
                name: "KeywordUpgrade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Upgrades",
                table: "Upgrades");

            migrationBuilder.DeleteData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ChosenUpgrades",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UpgradeId",
                table: "Weapons");

            migrationBuilder.RenameTable(
                name: "Upgrades",
                newName: "Upgrade");

            migrationBuilder.RenameColumn(
                name: "UpgradeId",
                table: "ChosenUpgrades",
                newName: "UnitId");

            migrationBuilder.RenameColumn(
                name: "ChosenUnitId",
                table: "ChosenUpgrades",
                newName: "ArmyId");

            migrationBuilder.AddColumn<int>(
                name: "UpgradeId",
                table: "Keywords",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Upgrade",
                table: "Upgrade",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_UpgradeId",
                table: "Keywords",
                column: "UpgradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keywords_Upgrade_UpgradeId",
                table: "Keywords",
                column: "UpgradeId",
                principalTable: "Upgrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeCategory_Upgrade_UpgradeId1",
                table: "UpgradeCategory",
                column: "UpgradeId1",
                principalTable: "Upgrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
