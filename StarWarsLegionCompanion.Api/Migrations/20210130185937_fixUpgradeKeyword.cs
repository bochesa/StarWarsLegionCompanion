using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class fixUpgradeKeyword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KeywordUpgrade",
                keyColumns: new[] { "KeywordsId", "UpgradesId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "KeywordUpgrade",
                columns: new[] { "KeywordsId", "UpgradesId" },
                values: new object[] { 7, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KeywordUpgrade",
                keyColumns: new[] { "KeywordsId", "UpgradesId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "KeywordUpgrade",
                columns: new[] { "KeywordsId", "UpgradesId" },
                values: new object[] { 7, 1 });
        }
    }
}
