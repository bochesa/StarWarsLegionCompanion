using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsLegionCompanion.Api.Migrations
{
    public partial class updateChosenUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitRankId",
                table: "ChosenUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ChosenUnits",
                keyColumn: "Id",
                keyValue: 10,
                column: "UnitRankId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ChosenUnits",
                keyColumn: "Id",
                keyValue: 11,
                column: "UnitRankId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ChosenUnits",
                keyColumn: "Id",
                keyValue: 12,
                column: "UnitRankId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ChosenUnits",
                keyColumn: "Id",
                keyValue: 13,
                column: "UnitRankId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitRankId",
                table: "ChosenUnits");
        }
    }
}
