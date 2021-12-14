using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class addedReconfigure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReconfigureId",
                table: "Upgrades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Upgrades_ReconfigureId",
                table: "Upgrades",
                column: "ReconfigureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Upgrades_Upgrades_ReconfigureId",
                table: "Upgrades",
                column: "ReconfigureId",
                principalTable: "Upgrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Upgrades_Upgrades_ReconfigureId",
                table: "Upgrades");

            migrationBuilder.DropIndex(
                name: "IX_Upgrades_ReconfigureId",
                table: "Upgrades");

            migrationBuilder.DropColumn(
                name: "ReconfigureId",
                table: "Upgrades");
        }
    }
}
