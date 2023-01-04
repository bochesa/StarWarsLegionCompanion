using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityLibrary.Migrations
{
    /// <inheritdoc />
    public partial class image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeywordUnit");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Upgrades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Keywords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_UnitId",
                table: "Keywords",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keywords_Units_UnitId",
                table: "Keywords",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keywords_Units_UnitId",
                table: "Keywords");

            migrationBuilder.DropIndex(
                name: "IX_Keywords_UnitId",
                table: "Keywords");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Upgrades");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Keywords");

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
                        name: "FK_KeywordUnit_Keywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordUnit_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeywordUnit_UnitsId",
                table: "KeywordUnit",
                column: "UnitsId");
        }
    }
}
