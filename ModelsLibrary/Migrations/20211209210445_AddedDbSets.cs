using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class AddedDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttackValue_Weapon_WeaponId",
                table: "AttackValue");

            migrationBuilder.DropForeignKey(
                name: "FK_KeywordUnit_Keyword_KeywordsId",
                table: "KeywordUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_KeywordUpgrade_Keyword_KeywordsId",
                table: "KeywordUpgrade");

            migrationBuilder.DropForeignKey(
                name: "FK_KeywordWeapon_Keyword_KeywordsId",
                table: "KeywordWeapon");

            migrationBuilder.DropForeignKey(
                name: "FK_KeywordWeapon_Weapon_WeaponsId",
                table: "KeywordWeapon");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitWeapon_Weapon_WeaponsId",
                table: "UnitWeapon");

            migrationBuilder.DropForeignKey(
                name: "FK_Upgrades_Weapon_WeaponId",
                table: "Upgrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keyword",
                table: "Keyword");

            migrationBuilder.RenameTable(
                name: "Weapon",
                newName: "Weapons");

            migrationBuilder.RenameTable(
                name: "Keyword",
                newName: "Keywords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keywords",
                table: "Keywords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttackValue_Weapons_WeaponId",
                table: "AttackValue",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordUnit_Keywords_KeywordsId",
                table: "KeywordUnit",
                column: "KeywordsId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordUpgrade_Keywords_KeywordsId",
                table: "KeywordUpgrade",
                column: "KeywordsId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordWeapon_Keywords_KeywordsId",
                table: "KeywordWeapon",
                column: "KeywordsId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordWeapon_Weapons_WeaponsId",
                table: "KeywordWeapon",
                column: "WeaponsId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitWeapon_Weapons_WeaponsId",
                table: "UnitWeapon",
                column: "WeaponsId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Upgrades_Weapons_WeaponId",
                table: "Upgrades",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttackValue_Weapons_WeaponId",
                table: "AttackValue");

            migrationBuilder.DropForeignKey(
                name: "FK_KeywordUnit_Keywords_KeywordsId",
                table: "KeywordUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_KeywordUpgrade_Keywords_KeywordsId",
                table: "KeywordUpgrade");

            migrationBuilder.DropForeignKey(
                name: "FK_KeywordWeapon_Keywords_KeywordsId",
                table: "KeywordWeapon");

            migrationBuilder.DropForeignKey(
                name: "FK_KeywordWeapon_Weapons_WeaponsId",
                table: "KeywordWeapon");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitWeapon_Weapons_WeaponsId",
                table: "UnitWeapon");

            migrationBuilder.DropForeignKey(
                name: "FK_Upgrades_Weapons_WeaponId",
                table: "Upgrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keywords",
                table: "Keywords");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "Weapon");

            migrationBuilder.RenameTable(
                name: "Keywords",
                newName: "Keyword");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keyword",
                table: "Keyword",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttackValue_Weapon_WeaponId",
                table: "AttackValue",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordUnit_Keyword_KeywordsId",
                table: "KeywordUnit",
                column: "KeywordsId",
                principalTable: "Keyword",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordUpgrade_Keyword_KeywordsId",
                table: "KeywordUpgrade",
                column: "KeywordsId",
                principalTable: "Keyword",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordWeapon_Keyword_KeywordsId",
                table: "KeywordWeapon",
                column: "KeywordsId",
                principalTable: "Keyword",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordWeapon_Weapon_WeaponsId",
                table: "KeywordWeapon",
                column: "WeaponsId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitWeapon_Weapon_WeaponsId",
                table: "UnitWeapon",
                column: "WeaponsId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Upgrades_Weapon_WeaponId",
                table: "Upgrades",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
