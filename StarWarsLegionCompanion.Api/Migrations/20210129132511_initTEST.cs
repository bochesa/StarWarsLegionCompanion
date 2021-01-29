using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class initTEST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArmyLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: false),
                    PointLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmyLists", x => x.Id);
                });

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
                name: "AttackSurges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackSurges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChosenUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChosenUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChosenUpgrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChosenUpgrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUnique = table.Column<bool>(type: "bit", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: false),
                    RankId = table.Column<int>(type: "int", nullable: false),
                    UnitTypeId = table.Column<int>(type: "int", nullable: false),
                    WoundThreshold = table.Column<int>(type: "int", nullable: false),
                    Courage = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    MinisInUnit = table.Column<int>(type: "int", nullable: false),
                    PointCost = table.Column<int>(type: "int", nullable: false),
                    IsDefenseRed = table.Column<bool>(type: "bit", nullable: false),
                    IsDefenseSurge = table.Column<bool>(type: "bit", nullable: false),
                    AttackSurgeId = table.Column<int>(type: "int", nullable: false),
                    ArmyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Upgrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointCost = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WoundThreshold = table.Column<int>(type: "int", nullable: true),
                    IsExhaustable = table.Column<bool>(type: "bit", nullable: false),
                    IsFreeAction = table.Column<bool>(type: "bit", nullable: false),
                    UpgradeCategoryId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrade", x => x.Id);
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
                    MaxRange = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
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
                    IsCardAction = table.Column<bool>(type: "bit", nullable: false),
                    UpgradeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keywords_Upgrade_UpgradeId",
                        column: x => x.UpgradeId,
                        principalTable: "Upgrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UpgradeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpgradeId = table.Column<int>(type: "int", nullable: false),
                    UpgradeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpgradeCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpgradeCategory_Upgrade_UpgradeId1",
                        column: x => x.UpgradeId1,
                        principalTable: "Upgrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_AttackDieWeapon_Weapons_WeaponsId",
                        column: x => x.WeaponsId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitWeapon",
                columns: table => new
                {
                    UnitsId = table.Column<int>(type: "int", nullable: false),
                    WeaponsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitWeapon", x => new { x.UnitsId, x.WeaponsId });
                    table.ForeignKey(
                        name: "FK_UnitWeapon_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitWeapon_Weapons_WeaponsId",
                        column: x => x.WeaponsId,
                        principalTable: "Weapons",
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
                name: "UnitUpgradeCategory",
                columns: table => new
                {
                    UnitsId = table.Column<int>(type: "int", nullable: false),
                    UpgradeCategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitUpgradeCategory", x => new { x.UnitsId, x.UpgradeCategoriesId });
                    table.ForeignKey(
                        name: "FK_UnitUpgradeCategory_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitUpgradeCategory_UpgradeCategory_UpgradeCategoriesId",
                        column: x => x.UpgradeCategoriesId,
                        principalTable: "UpgradeCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArmyLists",
                columns: new[] { "Id", "FactionId", "Name", "PlayerId", "PointLimit" },
                values: new object[,]
                {
                    { 1, 1, "Holy Molys", 1, 800 },
                    { 2, 2, "City Bois", 2, 800 }
                });

            migrationBuilder.InsertData(
                table: "AttackDie",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 26, "Red", 6 },
                    { 25, "Red", 5 },
                    { 23, "Red", 3 },
                    { 22, "Red", 2 },
                    { 21, "Red", 1 },
                    { 16, "Black", 6 },
                    { 15, "Black", 5 },
                    { 14, "Black", 4 },
                    { 24, "Red", 4 },
                    { 12, "Black", 2 },
                    { 11, "Black", 1 },
                    { 6, "White", 6 },
                    { 5, "White", 5 },
                    { 4, "White", 4 },
                    { 3, "White", 3 },
                    { 2, "White", 2 },
                    { 1, "White", 1 },
                    { 13, "Black", 3 }
                });

            migrationBuilder.InsertData(
                table: "AttackSurges",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "None" },
                    { 2, "Hit" },
                    { 3, "Critical" }
                });

            migrationBuilder.InsertData(
                table: "ChosenUnits",
                columns: new[] { "Id", "ArmyId", "UnitId" },
                values: new object[,]
                {
                    { 13, 2, 50 },
                    { 12, 1, 3 },
                    { 10, 1, 1 },
                    { 11, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Factions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rebel Alliance" },
                    { 2, "Galactic Empire" },
                    { 3, "Separatist Alliance" },
                    { 4, "Galactic Republic" },
                    { 20, "Neutral" }
                });

            migrationBuilder.InsertData(
                table: "Keywords",
                columns: new[] { "Id", "AbilityValue", "IsCardAction", "IsFreeAction", "Name", "Text", "UpgradeId" },
                values: new object[,]
                {
                    { 6, 2, false, false, "Pierce", "When attacking, ignore up to 2 block results.", null },
                    { 8, 3, false, false, "Impact", "While attacking a unit that has Armor, change up to X Dice Hit.png result(s) to Dice Crit.png result(s).", null },
                    { 7, 1, false, false, "Precise 1", "When you spend an aim token, reroll up to 1 additional die.", null },
                    { 5, 2, false, false, "Impact", "While attacking a unit that has Armor, change up to X Dice Hit.png result(s) to Dice Crit.png result(s).", null },
                    { 9, 3, false, false, "Pierce", "When attacking, ignore up to 2 block results.", null },
                    { 3, null, false, false, "Deflect", "After While defending, if you spend a dodge token, you gain “Surge: Block”: if it’s a ranged attack, the attacker suffers 1 wound for each Surge rolled.", null },
                    { 2, null, false, false, "Charge", "After you perform a move action, you may perform a free melee attack action.", null },
                    { 1, 1, true, false, "Jump", "Perform a move during which you ignore terrain that is height 1 or lower. This is treated as a move action.", null },
                    { 4, null, false, false, "Immune: Pierce", "Pierce cannot be used against you.", null }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Henrik" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Kenneth" });

            migrationBuilder.InsertData(
                table: "RangeTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Melee" },
                    { 2, "Ranged" }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Heavy" },
                    { 5, "Support" },
                    { 4, "Special Forces" },
                    { 1, "Commander" },
                    { 2, "Operative" },
                    { 3, "Corps" }
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Ground Vehicle" },
                    { 2, "Repulsor Vehicle" },
                    { 4, "Emplacement Trooper" },
                    { 1, "Trooper" },
                    { 6, "Wookie Tropper" },
                    { 7, "Droid Trooper" },
                    { 8, "Clone Trooper" },
                    { 5, "Creature Tropper" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ArmyId", "AttackSurgeId", "Courage", "FactionId", "IsDefenseRed", "IsDefenseSurge", "IsUnique", "MinisInUnit", "Name", "PointCost", "RankId", "Speed", "SurName", "UnitTypeId", "WoundThreshold" },
                values: new object[,]
                {
                    { 55, null, 3, 2, 2, true, false, false, 1, "E-Web Heavy Blaster Team", 55, 5, 1, null, 4, 4 },
                    { 56, null, 1, 1, 2, true, false, false, 4, "Imperial Royal Guards", 44, 3, 2, null, 1, 1 },
                    { 57, null, 1, 2, 2, false, true, false, 1, "Scout Trooper", 16, 4, 2, "Strike Team", 1, 1 },
                    { 58, null, 1, 2, 2, false, true, false, 4, "Scout Trooper", 60, 4, 2, null, 1, 1 },
                    { 59, null, 3, 2, 2, false, true, true, 1, "Director Orson Krennic", 90, 1, 2, null, 1, 6 },
                    { 60, null, 2, 2, 2, true, true, false, 4, "Imperial Death Trooper", 76, 3, 2, null, 1, 1 },
                    { 61, null, 3, 2, 2, false, false, true, 1, "Bossk", 115, 2, 2, null, 1, 7 },
                    { 62, null, 3, 4, 2, true, true, true, 1, "Emperor Palpatine", 210, 1, 1, "Ruler of The Galactic Empire", 1, 5 },
                    { 74, null, 2, 2, 2, false, true, false, 1, "Imperial Officer", 50, 1, 2, null, 1, 4 },
                    { 63, null, 2, 1, 2, true, false, false, 4, "Snowtrooper", 48, 3, 1, null, 1, 1 },
                    { 65, null, 1, 1, 2, true, false, false, 4, "Shoretrooper", 52, 3, 2, null, 1, 1 },
                    { 66, null, 2, 3, 2, true, false, false, 1, "Iden Versio", 100, 1, 2, null, 1, 6 },
                    { 67, null, 2, 2, 2, true, false, false, 1, "Dewback Rider", 90, 5, 1, null, 5, 6 },
                    { 68, null, 1, 2, 2, true, false, false, 1, "DF-90 Mortar Trooper", 36, 3, 1, null, 4, 3 },
                    { 69, null, 2, 2, 2, true, false, false, 4, "Imperial Special Forces", 68, 3, 2, null, 1, 1 },
                    { 70, null, 2, 2, 2, true, false, false, 1, "Imperial Special Forces", 34, 3, 2, "Inferno Squad", 1, 2 },
                    { 71, null, 3, 3, 2, true, true, true, 1, "Boba Fett", 140, 2, 3, "Infamous Bounty Hunter", 1, 5 },
                    { 72, null, 1, 3, 2, true, false, true, 1, "Darth Vader", 170, 2, 1, "The Emperor's Apprentice", 1, 6 },
                    { 73, null, 3, 2, 2, true, false, true, 1, "Agent Kallus", 90, 1, 2, null, 1, 6 },
                    { 54, null, 2, 0, 2, false, false, false, 2, "74-Z Speeder Bikes", 90, 5, 3, null, 2, 3 },
                    { 64, null, 1, 6, 2, true, false, false, 1, "TX-225 GAVw Occupier Combat Assault Tank", 155, 6, 1, null, 3, 8 },
                    { 53, null, 1, 8, 2, false, true, false, 1, "AT-ST", 195, 6, 2, null, 3, 11 },
                    { 27, null, 3, 2, 1, false, true, true, 1, "Lando Calrissian", 105, 1, 2, "Smooth Operator", 1, 6 },
                    { 51, null, 2, 1, 2, true, false, false, 4, "Storm Trooper", 44, 3, 2, null, 1, 1 },
                    { 52, null, 3, 2, 2, true, false, true, 1, "General Veers", 80, 1, 2, "Master Tactician", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ArmyId", "AttackSurgeId", "Courage", "FactionId", "IsDefenseRed", "IsDefenseSurge", "IsUnique", "MinisInUnit", "Name", "PointCost", "RankId", "Speed", "SurName", "UnitTypeId", "WoundThreshold" },
                values: new object[,]
                {
                    { 1, null, 3, 3, 1, true, false, true, 1, "Luke Skywalker", 160, 1, 2, "HERO OF THE REBELLION", 1, 6 },
                    { 2, null, 3, 2, 1, false, true, true, 1, "Leia Organa", 90, 1, 2, "FEARLESS AND INVENTIVE", 1, 6 },
                    { 3, null, 1, 1, 1, false, true, false, 4, "Rebel Troopers", 40, 3, 2, null, 1, 1 },
                    { 4, null, 2, 1, 1, false, true, false, 4, "Fleet Troopers", 44, 3, 2, null, 1, 1 },
                    { 6, null, 3, 4, 1, false, false, false, 1, "AT-RT", 55, 5, 2, null, 3, 6 },
                    { 7, null, 2, 2, 1, false, true, false, 4, "Rebel Commandos", 60, 4, 2, null, 1, 1 },
                    { 8, null, 2, 2, 1, false, true, false, 1, "Rebel Commandos", 16, 4, 2, "Strike Team", 1, 1 },
                    { 9, null, 3, 2, 1, false, true, true, 1, "Han Solo", 120, 1, 2, "Unorthodox general", 1, 6 },
                    { 10, null, 2, 2, 1, false, true, false, 1, "1.4 FD Laser Cannon Team", 70, 5, 0, null, 4, 6 },
                    { 11, null, 2, 2, 1, false, true, false, 1, "Rebel Officer", 50, 1, 2, "Resolute Commander", 1, 4 },
                    { 12, null, 2, 2, 1, false, false, false, 3, "Wookie Warriors", 75, 4, 2, null, 6, 3 },
                    { 13, null, 3, 2, 1, false, false, true, 1, "Chewbacca", 110, 2, 2, "walking Carpet", 6, 9 },
                    { 14, null, 3, 3, 1, false, true, true, 1, "Jyn Erso", 130, 1, 2, "Stardust", 1, 6 },
                    { 5, null, 3, 5, 1, false, true, false, 1, "T-47 Airspeeder", 175, 6, 3, null, 2, 7 },
                    { 16, null, 2, 4, 1, false, true, false, 1, "X-34 Landspeeder", 75, 6, 2, null, 2, 6 },
                    { 15, null, 2, 2, 1, false, true, false, 4, "Rebel Pathfinders", 68, 4, 2, null, 1, 1 },
                    { 26, null, 2, 2, 1, true, true, false, 1, "Mandalorian Resistance", 34, 4, 3, "Clan Wren", 1, 2 },
                    { 50, null, 1, 0, 2, false, false, true, 1, "Darth Vader", 200, 1, 1, "DARK LORD OF THE SITH", 1, 8 },
                    { 24, null, 3, 2, 1, true, false, true, 1, "K-2SO", 70, 2, 1, "Sardonic Security Droid", 7, 5 },
                    { 23, null, 2, 2, 1, false, true, true, 1, "Casisian Andor", 90, 1, 2, "Capable Intelligence Agent", 1, 6 },
                    { 25, null, 2, 2, 1, true, true, false, 3, "Mandalorian Resistance", 72, 4, 3, null, 1, 1 },
                    { 21, null, 3, 4, 1, true, false, true, 1, "Luke Skywalker", 200, 2, 2, "Jedi Knight", 1, 7 },
                    { 20, null, 2, 2, 1, false, true, false, 1, "Mark II Medium Blaster Trooper", 38, 3, 1, null, 4, 4 },
                    { 19, null, 2, 1, 1, false, true, false, 4, "Rebel Veterans", 44, 3, 2, null, 1, 1 },
                    { 18, null, 2, 2, 1, false, true, false, 2, "Tauntaun Riders", 90, 5, 3, null, 5, 4 },
                    { 17, null, 3, 2, 1, true, true, true, 1, "Sabine Wren", 125, 2, 3, "Explosive Artist", 1, 5 },
                    { 22, null, 2, 2, 1, false, false, true, 1, "R2-D2", 35, 2, 1, "Hero of Thousands Devices", 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "UpgradeCategory",
                columns: new[] { "Id", "Name", "UpgradeId", "UpgradeId1" },
                values: new object[,]
                {
                    { 24, "Heavy Weapon", 0, null },
                    { 25, "Ordnance", 0, null },
                    { 26, "Personnel", 0, null },
                    { 27, "Pilot", 0, null },
                    { 28, "Training", 0, null },
                    { 29, "Armament", 0, null },
                    { 30, "Command", 0, null },
                    { 31, "Comms", 0, null },
                    { 32, "Crew", 0, null },
                    { 38, "Heavy Weapon", 0, null },
                    { 34, "Gear", 0, null },
                    { 35, "Generator", 0, null },
                    { 36, "Grenades", 0, null },
                    { 37, "Hardpoint", 0, null },
                    { 39, "Ordnance", 0, null }
                });

            migrationBuilder.InsertData(
                table: "UpgradeCategory",
                columns: new[] { "Id", "Name", "UpgradeId", "UpgradeId1" },
                values: new object[,]
                {
                    { 40, "Personnel", 0, null },
                    { 41, "Pilot", 0, null },
                    { 42, "Training", 0, null },
                    { 23, "Hardpoint", 0, null },
                    { 33, "Force", 0, null },
                    { 22, "Grenades", 0, null },
                    { 8, "Grenades", 0, null },
                    { 20, "Gear", 0, null },
                    { 1, "Armament", 0, null },
                    { 2, "Command", 0, null },
                    { 3, "Comms", 0, null },
                    { 4, "Crew", 0, null },
                    { 5, "Force", 0, null },
                    { 6, "Gear", 0, null },
                    { 7, "Generator", 0, null },
                    { 21, "Generator", 0, null },
                    { 10, "Heavy Weapon", 0, null },
                    { 9, "Hardpoint", 0, null },
                    { 12, "Personnel", 0, null },
                    { 13, "Pilot", 0, null },
                    { 14, "Training", 0, null },
                    { 15, "Armament", 0, null },
                    { 16, "Command", 0, null },
                    { 17, "Comms", 0, null },
                    { 18, "Crew", 0, null },
                    { 19, "Force", 0, null },
                    { 11, "Ordnance", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "MaxRange", "MinRange", "Name", "RangeTypeId" },
                values: new object[,]
                {
                    { 2, 2, 1, "Luke's DL-44 Blaster Pistol", 2 },
                    { 1, null, null, "Anakin's Lightsaber", 1 },
                    { 3, null, null, "Vader's Lightsaber", 1 }
                });

            migrationBuilder.InsertData(
                table: "AttackDieWeapon",
                columns: new[] { "AttackDieId", "WeaponsId" },
                values: new object[,]
                {
                    { 16, 1 },
                    { 26, 3 },
                    { 22, 2 }
                });

            migrationBuilder.InsertData(
                table: "KeywordUnit",
                columns: new[] { "KeywordsId", "UnitsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 3, 50 },
                    { 4, 50 }
                });

            migrationBuilder.InsertData(
                table: "KeywordWeapon",
                columns: new[] { "KeywordsId", "WeaponsId" },
                values: new object[,]
                {
                    { 8, 3 },
                    { 6, 2 },
                    { 5, 1 },
                    { 9, 3 },
                    { 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitWeapon",
                columns: new[] { "UnitsId", "WeaponsId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 1 },
                    { 50, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttackDieWeapon_WeaponsId",
                table: "AttackDieWeapon",
                column: "WeaponsId");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_UpgradeId",
                table: "Keywords",
                column: "UpgradeId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordUnit_UnitsId",
                table: "KeywordUnit",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordWeapon_WeaponsId",
                table: "KeywordWeapon",
                column: "WeaponsId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitUpgradeCategory_UpgradeCategoriesId",
                table: "UnitUpgradeCategory",
                column: "UpgradeCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitWeapon_WeaponsId",
                table: "UnitWeapon",
                column: "WeaponsId");

            migrationBuilder.CreateIndex(
                name: "IX_UpgradeCategory_UpgradeId1",
                table: "UpgradeCategory",
                column: "UpgradeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmyLists");

            migrationBuilder.DropTable(
                name: "AttackDieWeapon");

            migrationBuilder.DropTable(
                name: "AttackSurges");

            migrationBuilder.DropTable(
                name: "ChosenUnits");

            migrationBuilder.DropTable(
                name: "ChosenUpgrades");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "KeywordUnit");

            migrationBuilder.DropTable(
                name: "KeywordWeapon");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "RangeTypes");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropTable(
                name: "UnitUpgradeCategory");

            migrationBuilder.DropTable(
                name: "UnitWeapon");

            migrationBuilder.DropTable(
                name: "AttackDie");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "UpgradeCategory");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Upgrade");
        }
    }
}
