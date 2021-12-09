using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class FixAttackValue2 : Migration
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
                name: "AttackValueId",
                table: "Weapons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_AttackValueId",
                table: "Weapons",
                column: "AttackValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_AttackValue_AttackValueId",
                table: "Weapons",
                column: "AttackValueId",
                principalTable: "AttackValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_AttackValue_AttackValueId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_AttackValueId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "AttackValueId",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "AttackValue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AttackValue_WeaponId",
                table: "AttackValue",
                column: "WeaponId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AttackValue_Weapons_WeaponId",
                table: "AttackValue",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
