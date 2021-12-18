using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class RenamingOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitActivated",
                table: "Commands",
                newName: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Restriction",
                table: "Upgrades",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Restriction",
                table: "Upgrades");

            migrationBuilder.RenameColumn(
                name: "Orders",
                table: "Commands",
                newName: "UnitActivated");
        }
    }
}
