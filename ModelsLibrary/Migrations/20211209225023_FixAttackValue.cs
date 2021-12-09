using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class FixAttackValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttackValue_Weapons_WeaponId",
                table: "AttackValue");

            migrationBuilder.DropIndex(
                name: "IX_AttackValue_WeaponId",
                table: "AttackValue");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "AttackValue");

            migrationBuilder.AddColumn<int>(
                name: "AttackDieId",
                table: "Weapons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_AttackDieId",
                table: "Weapons",
                column: "AttackDieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_AttackValue_AttackDieId",
                table: "Weapons",
                column: "AttackDieId",
                principalTable: "AttackValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_AttackValue_AttackDieId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_AttackDieId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "AttackDieId",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "AttackValue",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttackValue_WeaponId",
                table: "AttackValue",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttackValue_Weapons_WeaponId",
                table: "AttackValue",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
