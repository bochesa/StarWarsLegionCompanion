using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class AddedCommands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttackSurge",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffiliationId = table.Column<int>(type: "int", nullable: true),
                    Pips = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitActivated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commands_Units_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CommandId",
                table: "Weapons",
                column: "CommandId");

            migrationBuilder.CreateIndex(
                name: "IX_UpgradeOption_CommandId",
                table: "UpgradeOption",
                column: "CommandId");

            migrationBuilder.CreateIndex(
                name: "IX_Commands_AffiliationId",
                table: "Commands",
                column: "AffiliationId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpgradeOption_Commands_CommandId",
                table: "UpgradeOption");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Commands_CommandId",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_CommandId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_UpgradeOption_CommandId",
                table: "UpgradeOption");

            migrationBuilder.DropColumn(
                name: "AttackSurge",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "CommandId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "CommandId",
                table: "UpgradeOption");
        }
    }
}
