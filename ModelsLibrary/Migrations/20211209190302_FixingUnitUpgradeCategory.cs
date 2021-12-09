using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class FixingUnitUpgradeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeCategory_Units_UnitId",
                table: "UpgradeCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapon_UpgradeCategory_UpgradeCategoryId",
                table: "Weapon");

            migrationBuilder.DropTable(
                name: "AttackDie");

            migrationBuilder.DropIndex(
                name: "IX_Weapon_UpgradeCategoryId",
                table: "Weapon");

            migrationBuilder.DropIndex(
                name: "IX_UpgradeCategory_UnitId",
                table: "UpgradeCategory");

            migrationBuilder.DropColumn(
                name: "UpgradeCategoryId",
                table: "Weapon");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "UpgradeCategory");

            migrationBuilder.DropColumn(
                name: "ArmyId",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "MinRange",
                table: "Weapon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AttackValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedDie = table.Column<int>(type: "int", nullable: false),
                    BlackDie = table.Column<int>(type: "int", nullable: false),
                    WhiteDie = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttackValue_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_AttackValue_WeaponId",
                table: "AttackValue",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitUpgradeCategory_UpgradeCategoriesId",
                table: "UnitUpgradeCategory",
                column: "UpgradeCategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttackValue");

            migrationBuilder.DropTable(
                name: "UnitUpgradeCategory");

            migrationBuilder.AlterColumn<int>(
                name: "MinRange",
                table: "Weapon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpgradeCategoryId",
                table: "Weapon",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "UpgradeCategory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArmyId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AttackDie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackDie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttackDie_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_UpgradeCategoryId",
                table: "Weapon",
                column: "UpgradeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UpgradeCategory_UnitId",
                table: "UpgradeCategory",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AttackDie_WeaponId",
                table: "AttackDie",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeCategory_Units_UnitId",
                table: "UpgradeCategory",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapon_UpgradeCategory_UpgradeCategoryId",
                table: "Weapon",
                column: "UpgradeCategoryId",
                principalTable: "UpgradeCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
