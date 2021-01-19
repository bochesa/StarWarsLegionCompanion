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
                name: "Faction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faction", x => x.Id);
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
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeTypeId = table.Column<int>(type: "int", nullable: false),
                    MinRange = table.Column<int>(type: "int", nullable: true),
                    MaxRange = table.Column<int>(type: "int", nullable: true),
                    AttackValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    AttackSurgeId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Units_Faction_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Faction",
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
                    { 21, "Red", 1 },
                    { 15, "Black", 5 },
                    { 14, "Black", 4 },
                    { 16, "Black", 6 },
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
                table: "Faction",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Galactic Republic" },
                    { 3, "Galactic Empire" },
                    { 4, "Separatist Alliance" },
                    { 1, "Neutral" },
                    { 2, "Rebel Alliance" }
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
                    { 1, "Melee" },
                    { 2, "Ranged" }
                });

            migrationBuilder.InsertData(
                table: "Rank",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Heavy" },
                    { 5, "Support" },
                    { 4, "Special Forces" },
                    { 2, "Operative" },
                    { 1, "Commander" },
                    { 3, "Corps" }
                });

            migrationBuilder.InsertData(
                table: "UnitType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Creature Tropper" });

            migrationBuilder.InsertData(
                table: "UnitType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Wookie Tropper" },
                    { 4, "Emplacement Trooper" },
                    { 7, "Droid Trooper" },
                    { 2, "Repulsor Vehicle" },
                    { 1, "Trooper" },
                    { 3, "Ground Vehicle" },
                    { 8, "Clone Trooper" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AttackSurgeId", "Courage", "FactionId", "IsDefenseRed", "IsDefenseSurge", "IsUnique", "MinisInUnit", "Name", "PointCost", "RankId", "Speed", "SurName", "UnitTypeId", "WoundThreshold" },
                values: new object[] { 1, 3, 3, 2, true, false, true, 1, "Luke Skywalker", 160, 1, 2, "HERO OF THE REBELLION", 1, 6 });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "AttackValue", "MaxRange", "MinRange", "Name", "RangeTypeId" },
                values: new object[] { 2, null, 2, 1, "Luke's DL-44 Blaster Pistol", 2 });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "AttackValue", "MaxRange", "MinRange", "Name", "RangeTypeId" },
                values: new object[] { 1, null, null, null, "Anakin's Lightsaber", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_KeywordUnit_UnitsId",
                table: "KeywordUnit",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordWeapon_WeaponsId",
                table: "KeywordWeapon",
                column: "WeaponsId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_AttackSurgeId",
                table: "Units",
                column: "AttackSurgeId");

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
                name: "IX_UnitWeapon_WeaponsId",
                table: "UnitWeapon",
                column: "WeaponsId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_RangeTypeId",
                table: "Weapons",
                column: "RangeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttackDie");

            migrationBuilder.DropTable(
                name: "KeywordUnit");

            migrationBuilder.DropTable(
                name: "KeywordWeapon");

            migrationBuilder.DropTable(
                name: "UnitWeapon");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "AttackSurge");

            migrationBuilder.DropTable(
                name: "Faction");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropTable(
                name: "UnitType");

            migrationBuilder.DropTable(
                name: "RangeType");
        }
    }
}
