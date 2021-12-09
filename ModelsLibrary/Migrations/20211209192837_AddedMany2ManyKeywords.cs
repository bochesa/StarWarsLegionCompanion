using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class AddedMany2ManyKeywords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keyword_Units_UnitId",
                table: "Keyword");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyword_Weapon_WeaponId",
                table: "Keyword");

            migrationBuilder.DropIndex(
                name: "IX_Keyword_UnitId",
                table: "Keyword");

            migrationBuilder.DropIndex(
                name: "IX_Keyword_WeaponId",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Keyword");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Keyword");

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
                        name: "FK_KeywordUnit_Keyword_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "Keyword",
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
                        name: "FK_KeywordWeapon_Keyword_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "Keyword",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordWeapon_Weapon_WeaponsId",
                        column: x => x.WeaponsId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upgrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUnique = table.Column<bool>(type: "bit", nullable: false),
                    PointCost = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WoundThreshold = table.Column<int>(type: "int", nullable: true),
                    IsExhaustable = table.Column<bool>(type: "bit", nullable: false),
                    IsFreeAction = table.Column<bool>(type: "bit", nullable: false),
                    UpgradeType = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upgrade_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
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
                        name: "FK_KeywordUpgrade_Keyword_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "Keyword",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordUpgrade_Upgrade_UpgradesId",
                        column: x => x.UpgradesId,
                        principalTable: "Upgrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Upgrade_WeaponId",
                table: "Upgrade",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeywordUnit");

            migrationBuilder.DropTable(
                name: "KeywordUpgrade");

            migrationBuilder.DropTable(
                name: "KeywordWeapon");

            migrationBuilder.DropTable(
                name: "Upgrade");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Keyword",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Keyword",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keyword_UnitId",
                table: "Keyword",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyword_WeaponId",
                table: "Keyword",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keyword_Units_UnitId",
                table: "Keyword",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Keyword_Weapon_WeaponId",
                table: "Keyword",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
