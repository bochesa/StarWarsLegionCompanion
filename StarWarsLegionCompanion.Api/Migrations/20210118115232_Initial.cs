using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttackDie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackDie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttackSurge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackSurge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefenseDie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenseDie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityValue = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFreeAction = table.Column<bool>(type: "bit", nullable: false),
                    IsCardAction = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttackDieWeapon",
                columns: table => new
                {
                    AttackDieId = table.Column<int>(type: "int", nullable: false),
                    WeaponsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackDieWeapon", x => new { x.AttackDieId, x.WeaponsId });
                    table.ForeignKey(
                        name: "FK_AttackDieWeapon_AttackDie_AttackDieId",
                        column: x => x.AttackDieId,
                        principalTable: "AttackDie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUnique = table.Column<bool>(type: "bit", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: false),
                    UnitTypeId = table.Column<int>(type: "int", nullable: false),
                    RankId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PointCost = table.Column<int>(type: "int", nullable: false),
                    WoundThreshold = table.Column<int>(type: "int", nullable: false),
                    Courage = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    DefenseDieId = table.Column<int>(type: "int", nullable: false),
                    AttackSurgeId = table.Column<int>(type: "int", nullable: false),
                    IsDefenseSurge = table.Column<bool>(type: "bit", nullable: false),
                    MinisInUnit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_AttackSurge_AttackSurgeId",
                        column: x => x.AttackSurgeId,
                        principalTable: "AttackSurge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Units_DefenseDie_DefenseDieId",
                        column: x => x.DefenseDieId,
                        principalTable: "DefenseDie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Units_Rank_RankId",
                        column: x => x.RankId,
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Units_UnitType_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeywordUnit",
                columns: table => new
                {
                    KeywordsId = table.Column<int>(type: "int", nullable: false),
                    UnitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordUnit", x => new { x.KeywordsId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_KeywordUnit_Keywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordUnit_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UpgradeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpgradeCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpgradeCategory_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeTypeId = table.Column<int>(type: "int", nullable: false),
                    MinRange = table.Column<int>(type: "int", nullable: true),
                    MaxRange = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_RangeType_RangeTypeId",
                        column: x => x.RangeTypeId,
                        principalTable: "RangeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weapons_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeywordWeapon",
                columns: table => new
                {
                    KeywordsId = table.Column<int>(type: "int", nullable: false),
                    WeaponsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordWeapon", x => new { x.KeywordsId, x.WeaponsId });
                    table.ForeignKey(
                        name: "FK_KeywordWeapon_Keywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordWeapon_Weapons_WeaponsId",
                        column: x => x.WeaponsId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upgrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsUnique = table.Column<bool>(type: "bit", nullable: false),
                    WoundThreshold = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointCost = table.Column<int>(type: "int", nullable: false),
                    DiscardedAfterUse = table.Column<bool>(type: "bit", nullable: false),
                    IsExhausable = table.Column<bool>(type: "bit", nullable: false),
                    IsFreeAction = table.Column<bool>(type: "bit", nullable: false),
                    IsCardAction = table.Column<bool>(type: "bit", nullable: false),
                    UpgradeCategoryId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upgrades_UpgradeCategory_UpgradeCategoryId",
                        column: x => x.UpgradeCategoryId,
                        principalTable: "UpgradeCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Upgrades_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpgradeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faction_Upgrades_UpgradeId",
                        column: x => x.UpgradeId,
                        principalTable: "Upgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Restriction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpgradeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restriction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restriction_Upgrades_UpgradeId",
                        column: x => x.UpgradeId,
                        principalTable: "Upgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AttackDie",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "White", 1 },
                    { 26, "Red", 6 },
                    { 25, "Red", 5 },
                    { 24, "Red", 4 },
                    { 23, "Red", 3 },
                    { 22, "Red", 2 },
                    { 16, "Black", 6 },
                    { 15, "Black", 5 },
                    { 14, "Black", 4 },
                    { 21, "Red", 1 },
                    { 12, "Black", 2 },
                    { 11, "Black", 1 },
                    { 6, "White", 6 },
                    { 5, "White", 5 },
                    { 4, "White", 4 },
                    { 3, "White", 3 },
                    { 2, "White", 2 },
                    { 13, "Black", 3 }
                });

            migrationBuilder.InsertData(
                table: "AttackSurge",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "None" },
                    { 2, "Hit" },
                    { 3, "Critical" }
                });

            migrationBuilder.InsertData(
                table: "DefenseDie",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "White" },
                    { 2, "Red" }
                });

            migrationBuilder.InsertData(
                table: "Faction",
                columns: new[] { "Id", "Name", "UpgradeId" },
                values: new object[,]
                {
                    { 5, "Galactic Republic", null },
                    { 4, "Separatist Alliance", null },
                    { 1, "Neutral", null },
                    { 2, "Rebel Alliance", null },
                    { 3, "Galactic Empire", null }
                });

            migrationBuilder.InsertData(
                table: "Keywords",
                columns: new[] { "Id", "AbilityValue", "IsCardAction", "IsFreeAction", "Name", "Text" },
                values: new object[,]
                {
                    { 1, 1, true, false, "Jump", "Perform a move during which you ignore terrain that is height 1 or lower. This is treated as a move action." },
                    { 2, null, false, false, "Charge", "After you perform a move action, you may perform a free melee attack action." },
                    { 3, null, false, false, "Deflect", "After While defending, if you spend a dodge token, you gain “Surge: Block”: if it’s a ranged attack, the attacker suffers 1 wound for each Surge rolled." },
                    { 4, null, false, false, "Immune: Pierce", "Pierce cannot be used against you." },
                    { 5, 2, false, false, "Impact", "While attacking a unit that has Armor, change up to X Dice Hit.png result(s) to Dice Crit.png result(s)." },
                    { 6, 2, false, false, "Pierce", "When attacking, ignore up to 2 block results." },
                    { 7, 1, false, false, "Precise 1", "When you spend an aim token, reroll up to 1 additional die." }
                });

            migrationBuilder.InsertData(
                table: "RangeType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Ranged" },
                    { 1, "Melee" }
                });

            migrationBuilder.InsertData(
                table: "Rank",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Commander" },
                    { 2, "Operative" },
                    { 3, "Corps" },
                    { 4, "Special Forces" },
                    { 5, "Support" }
                });

            migrationBuilder.InsertData(
                table: "Rank",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Heavy" });

            migrationBuilder.InsertData(
                table: "UnitType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Wookie Tropper" },
                    { 8, "Clone Trooper" },
                    { 7, "Droid Trooper" },
                    { 5, "Creature Tropper" },
                    { 4, "Emplacement Trooper" },
                    { 3, "Ground Vehicle" },
                    { 2, "Repulsor Vehicle" },
                    { 1, "Trooper" }
                });

            migrationBuilder.InsertData(
                table: "UpgradeCategory",
                columns: new[] { "Id", "Name", "UnitId" },
                values: new object[,]
                {
                    { 23, "Hardpoint", null },
                    { 24, "Heavy Weapon", null },
                    { 25, "Ordnance", null },
                    { 26, "Personnel", null },
                    { 27, "Pilot", null },
                    { 28, "Training", null },
                    { 29, "Armament", null },
                    { 30, "Command", null },
                    { 31, "Comms", null },
                    { 32, "Crew", null },
                    { 33, "Force", null },
                    { 34, "Gear", null },
                    { 35, "Generator", null },
                    { 36, "Grenades", null },
                    { 37, "Hardpoint", null },
                    { 38, "Heavy Weapon", null },
                    { 39, "Ordnance", null },
                    { 40, "Personnel", null },
                    { 22, "Grenades", null },
                    { 21, "Generator", null },
                    { 20, "Gear", null },
                    { 19, "Force", null },
                    { 1, "Armament", null },
                    { 2, "Command", null },
                    { 3, "Comms", null },
                    { 4, "Crew", null },
                    { 5, "Force", null },
                    { 6, "Gear", null },
                    { 7, "Generator", null },
                    { 8, "Grenades", null },
                    { 41, "Pilot", null },
                    { 9, "Hardpoint", null },
                    { 11, "Ordnance", null }
                });

            migrationBuilder.InsertData(
                table: "UpgradeCategory",
                columns: new[] { "Id", "Name", "UnitId" },
                values: new object[,]
                {
                    { 12, "Personnel", null },
                    { 13, "Pilot", null },
                    { 14, "Training", null },
                    { 15, "Armament", null },
                    { 16, "Command", null },
                    { 17, "Comms", null },
                    { 18, "Crew", null },
                    { 10, "Heavy Weapon", null },
                    { 42, "Training", null }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "MaxRange", "MinRange", "Name", "RangeTypeId", "UnitId" },
                values: new object[] { 1, null, null, "Anakin's Lightsaber", 1, null });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "MaxRange", "MinRange", "Name", "RangeTypeId", "UnitId" },
                values: new object[] { 2, 2, 1, "Luke's DL-44 Blaster Pistol", 2, null });

            migrationBuilder.CreateIndex(
                name: "IX_AttackDieWeapon_WeaponsId",
                table: "AttackDieWeapon",
                column: "WeaponsId");

            migrationBuilder.CreateIndex(
                name: "IX_Faction_UpgradeId",
                table: "Faction",
                column: "UpgradeId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordUnit_UnitsId",
                table: "KeywordUnit",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordUpgrade_UpgradesId",
                table: "KeywordUpgrade",
                column: "UpgradesId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordWeapon_WeaponsId",
                table: "KeywordWeapon",
                column: "WeaponsId");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_UpgradeId",
                table: "Restriction",
                column: "UpgradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_AttackSurgeId",
                table: "Units",
                column: "AttackSurgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_DefenseDieId",
                table: "Units",
                column: "DefenseDieId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_FactionId",
                table: "Units",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_RankId",
                table: "Units",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UpgradeCategory_UnitId",
                table: "UpgradeCategory",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Upgrades_UpgradeCategoryId",
                table: "Upgrades",
                column: "UpgradeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Upgrades_WeaponId",
                table: "Upgrades",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_RangeTypeId",
                table: "Weapons",
                column: "RangeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_UnitId",
                table: "Weapons",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttackDieWeapon_Weapons_WeaponsId",
                table: "AttackDieWeapon",
                column: "WeaponsId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Faction_FactionId",
                table: "Units",
                column: "FactionId",
                principalTable: "Faction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Upgrades_Weapons_WeaponId",
                table: "Upgrades");

            migrationBuilder.DropForeignKey(
                name: "FK_Faction_Upgrades_UpgradeId",
                table: "Faction");

            migrationBuilder.DropTable(
                name: "AttackDieWeapon");

            migrationBuilder.DropTable(
                name: "KeywordUnit");

            migrationBuilder.DropTable(
                name: "KeywordUpgrade");

            migrationBuilder.DropTable(
                name: "KeywordWeapon");

            migrationBuilder.DropTable(
                name: "Restriction");

            migrationBuilder.DropTable(
                name: "AttackDie");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "RangeType");

            migrationBuilder.DropTable(
                name: "Upgrades");

            migrationBuilder.DropTable(
                name: "UpgradeCategory");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "AttackSurge");

            migrationBuilder.DropTable(
                name: "DefenseDie");

            migrationBuilder.DropTable(
                name: "Faction");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropTable(
                name: "UnitType");
        }
    }
}
