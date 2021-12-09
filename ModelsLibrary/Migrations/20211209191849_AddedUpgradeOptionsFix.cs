using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class AddedUpgradeOptionsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitUpgradeCategory");

            migrationBuilder.DropTable(
                name: "UpgradeCategory");

            migrationBuilder.CreateTable(
                name: "UpgradeOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpgradeType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpgradeOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpgradeOption_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpgradeOption_UnitId",
                table: "UpgradeOption",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpgradeOption");

            migrationBuilder.CreateTable(
                name: "UpgradeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpgradeCategory", x => x.Id);
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
                name: "IX_UnitUpgradeCategory_UpgradeCategoriesId",
                table: "UnitUpgradeCategory",
                column: "UpgradeCategoriesId");
        }
    }
}
