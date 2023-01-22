using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityLibrary.Migrations
{
    /// <inheritdoc />
    public partial class upgradeOptionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "UpgradeOption",
                newName: "UpgradeOptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpgradeOptionId",
                table: "UpgradeOption",
                newName: "Amount");
        }
    }
}
