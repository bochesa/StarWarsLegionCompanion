using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class AddedArmyChosenUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeOption_Commands_CommandId",
                table: "UpgradeOption");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Commands_CommandId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_CommandId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_UpgradeOption_CommandId",
                table: "UpgradeOption");

            migrationBuilder.DropColumn(
                name: "CommandId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "CommandId",
                table: "UpgradeOption");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Armies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    Faction = table.Column<int>(type: "int", nullable: false),
                    PointLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armies_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChosenCommand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandId = table.Column<int>(type: "int", nullable: false),
                    ArmyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChosenCommand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChosenCommand_Armies_ArmyId",
                        column: x => x.ArmyId,
                        principalTable: "Armies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChosenCommand_Commands_CommandId",
                        column: x => x.CommandId,
                        principalTable: "Commands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChosenUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ArmyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChosenUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChosenUnit_Armies_ArmyId",
                        column: x => x.ArmyId,
                        principalTable: "Armies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChosenUnit_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChosenUpgrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpgradeId = table.Column<int>(type: "int", nullable: false),
                    ChosenUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChosenUpgrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChosenUpgrade_ChosenUnit_ChosenUnitId",
                        column: x => x.ChosenUnitId,
                        principalTable: "ChosenUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChosenUpgrade_Upgrades_UpgradeId",
                        column: x => x.UpgradeId,
                        principalTable: "Upgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armies_PlayerId",
                table: "Armies",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChosenCommand_ArmyId",
                table: "ChosenCommand",
                column: "ArmyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChosenCommand_CommandId",
                table: "ChosenCommand",
                column: "CommandId");

            migrationBuilder.CreateIndex(
                name: "IX_ChosenUnit_ArmyId",
                table: "ChosenUnit",
                column: "ArmyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChosenUnit_UnitId",
                table: "ChosenUnit",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ChosenUpgrade_ChosenUnitId",
                table: "ChosenUpgrade",
                column: "ChosenUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ChosenUpgrade_UpgradeId",
                table: "ChosenUpgrade",
                column: "UpgradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChosenCommand");

            migrationBuilder.DropTable(
                name: "ChosenUpgrade");

            migrationBuilder.DropTable(
                name: "ChosenUnit");

            migrationBuilder.DropTable(
                name: "Armies");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.AddColumn<int>(
                name: "CommandId",
                table: "Weapons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommandId",
                table: "UpgradeOption",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CommandId",
                table: "Weapons",
                column: "CommandId");

            migrationBuilder.CreateIndex(
                name: "IX_UpgradeOption_CommandId",
                table: "UpgradeOption",
                column: "CommandId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpgradeOption_Commands_CommandId",
                table: "UpgradeOption",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Commands_CommandId",
                table: "Weapons",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
