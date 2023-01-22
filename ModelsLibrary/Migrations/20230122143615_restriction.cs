using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityLibrary.Migrations
{
    /// <inheritdoc />
    public partial class restriction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armies_Palyers_PlayerId",
                table: "Armies");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenUpgrade_ChosenUnit_ChosenUnitId",
                table: "ChosenUpgrade");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenUpgrade_Upgrades_UpgradeId",
                table: "ChosenUpgrade");

            migrationBuilder.DropIndex(
                name: "IX_ChosenUpgrade_ChosenUnitId",
                table: "ChosenUpgrade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Palyers",
                table: "Palyers");

            migrationBuilder.DropColumn(
                name: "Restriction",
                table: "Upgrades");

            migrationBuilder.RenameTable(
                name: "Palyers",
                newName: "Players");

            migrationBuilder.RenameColumn(
                name: "PointLimit",
                table: "Armies",
                newName: "ArmySetupId");

            migrationBuilder.AlterColumn<int>(
                name: "WoundThreshold",
                table: "Upgrades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAction",
                table: "Upgrades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UpgradeId",
                table: "ChosenUpgrade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChosenUnitId",
                table: "ChosenUpgrade",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArmyId",
                table: "ChosenUpgrade",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChosenUpgradeOption",
                table: "ChosenUpgrade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpgradeType",
                table: "ChosenUpgrade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ArmySetup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointLimit = table.Column<int>(type: "int", nullable: false),
                    CommanderMinimum = table.Column<int>(type: "int", nullable: false),
                    CommanderMaximum = table.Column<int>(type: "int", nullable: false),
                    OperativeMinimum = table.Column<int>(type: "int", nullable: false),
                    OperativeMaximum = table.Column<int>(type: "int", nullable: false),
                    CorpsMinimum = table.Column<int>(type: "int", nullable: false),
                    CorpsMaximum = table.Column<int>(type: "int", nullable: false),
                    SpecialForcesMinimum = table.Column<int>(type: "int", nullable: false),
                    SpecialForcesMaximum = table.Column<int>(type: "int", nullable: false),
                    SupportMinimum = table.Column<int>(type: "int", nullable: false),
                    SupportMaximum = table.Column<int>(type: "int", nullable: false),
                    HeavyMinimum = table.Column<int>(type: "int", nullable: false),
                    HeavyMaximum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmySetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestrictionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpgradeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restrictions_Upgrades_UpgradeId",
                        column: x => x.UpgradeId,
                        principalTable: "Upgrades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChosenUpgrade_ArmyId",
                table: "ChosenUpgrade",
                column: "ArmyId");

            migrationBuilder.CreateIndex(
                name: "IX_Armies_ArmySetupId",
                table: "Armies",
                column: "ArmySetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Restrictions_UpgradeId",
                table: "Restrictions",
                column: "UpgradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armies_ArmySetup_ArmySetupId",
                table: "Armies",
                column: "ArmySetupId",
                principalTable: "ArmySetup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Armies_Players_PlayerId",
                table: "Armies",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenUpgrade_Armies_ArmyId",
                table: "ChosenUpgrade",
                column: "ArmyId",
                principalTable: "Armies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenUpgrade_Upgrades_UpgradeId",
                table: "ChosenUpgrade",
                column: "UpgradeId",
                principalTable: "Upgrades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armies_ArmySetup_ArmySetupId",
                table: "Armies");

            migrationBuilder.DropForeignKey(
                name: "FK_Armies_Players_PlayerId",
                table: "Armies");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenUpgrade_Armies_ArmyId",
                table: "ChosenUpgrade");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenUpgrade_Upgrades_UpgradeId",
                table: "ChosenUpgrade");

            migrationBuilder.DropTable(
                name: "ArmySetup");

            migrationBuilder.DropTable(
                name: "Restrictions");

            migrationBuilder.DropIndex(
                name: "IX_ChosenUpgrade_ArmyId",
                table: "ChosenUpgrade");

            migrationBuilder.DropIndex(
                name: "IX_Armies_ArmySetupId",
                table: "Armies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsAction",
                table: "Upgrades");

            migrationBuilder.DropColumn(
                name: "ArmyId",
                table: "ChosenUpgrade");

            migrationBuilder.DropColumn(
                name: "ChosenUpgradeOption",
                table: "ChosenUpgrade");

            migrationBuilder.DropColumn(
                name: "UpgradeType",
                table: "ChosenUpgrade");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Palyers");

            migrationBuilder.RenameColumn(
                name: "ArmySetupId",
                table: "Armies",
                newName: "PointLimit");

            migrationBuilder.AlterColumn<int>(
                name: "WoundThreshold",
                table: "Upgrades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Restriction",
                table: "Upgrades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpgradeId",
                table: "ChosenUpgrade",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChosenUnitId",
                table: "ChosenUpgrade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Palyers",
                table: "Palyers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChosenUpgrade_ChosenUnitId",
                table: "ChosenUpgrade",
                column: "ChosenUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armies_Palyers_PlayerId",
                table: "Armies",
                column: "PlayerId",
                principalTable: "Palyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenUpgrade_ChosenUnit_ChosenUnitId",
                table: "ChosenUpgrade",
                column: "ChosenUnitId",
                principalTable: "ChosenUnit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenUpgrade_Upgrades_UpgradeId",
                table: "ChosenUpgrade",
                column: "UpgradeId",
                principalTable: "Upgrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
