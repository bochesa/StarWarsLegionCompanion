using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class fixedUnitAffiliation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commands_Units_AffiliationId",
                table: "Commands");

            migrationBuilder.RenameColumn(
                name: "AffiliationId",
                table: "Commands",
                newName: "UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Commands_AffiliationId",
                table: "Commands",
                newName: "IX_Commands_UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_Units_UnitId",
                table: "Commands",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commands_Units_UnitId",
                table: "Commands");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "Commands",
                newName: "AffiliationId");

            migrationBuilder.RenameIndex(
                name: "IX_Commands_UnitId",
                table: "Commands",
                newName: "IX_Commands_AffiliationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_Units_AffiliationId",
                table: "Commands",
                column: "AffiliationId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
