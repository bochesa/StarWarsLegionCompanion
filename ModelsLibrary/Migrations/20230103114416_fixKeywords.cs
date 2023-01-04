using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityLibrary.Migrations
{
    /// <inheritdoc />
    public partial class fixKeywords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armies_Player_PlayerId",
                table: "Armies");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenCommand_Armies_ArmyId",
                table: "ChosenCommand");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenCommand_Commands_CommandId",
                table: "ChosenCommand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChosenCommand",
                table: "ChosenCommand");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Palyers");

            migrationBuilder.RenameTable(
                name: "ChosenCommand",
                newName: "ChosenCommands");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Keywords",
                newName: "ShortDescription");

            migrationBuilder.RenameIndex(
                name: "IX_ChosenCommand_CommandId",
                table: "ChosenCommands",
                newName: "IX_ChosenCommands_CommandId");

            migrationBuilder.RenameIndex(
                name: "IX_ChosenCommand_ArmyId",
                table: "ChosenCommands",
                newName: "IX_ChosenCommands_ArmyId");

            migrationBuilder.AlterColumn<int>(
                name: "AbilityValue",
                table: "Keywords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KeywordType",
                table: "Keywords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Keywords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Palyers",
                table: "Palyers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChosenCommands",
                table: "ChosenCommands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Armies_Palyers_PlayerId",
                table: "Armies",
                column: "PlayerId",
                principalTable: "Palyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenCommands_Armies_ArmyId",
                table: "ChosenCommands",
                column: "ArmyId",
                principalTable: "Armies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenCommands_Commands_CommandId",
                table: "ChosenCommands",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armies_Palyers_PlayerId",
                table: "Armies");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenCommands_Armies_ArmyId",
                table: "ChosenCommands");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenCommands_Commands_CommandId",
                table: "ChosenCommands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Palyers",
                table: "Palyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChosenCommands",
                table: "ChosenCommands");

            migrationBuilder.DropColumn(
                name: "KeywordType",
                table: "Keywords");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Keywords");

            migrationBuilder.RenameTable(
                name: "Palyers",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "ChosenCommands",
                newName: "ChosenCommand");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Keywords",
                newName: "Text");

            migrationBuilder.RenameIndex(
                name: "IX_ChosenCommands_CommandId",
                table: "ChosenCommand",
                newName: "IX_ChosenCommand_CommandId");

            migrationBuilder.RenameIndex(
                name: "IX_ChosenCommands_ArmyId",
                table: "ChosenCommand",
                newName: "IX_ChosenCommand_ArmyId");

            migrationBuilder.AlterColumn<int>(
                name: "AbilityValue",
                table: "Keywords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChosenCommand",
                table: "ChosenCommand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Armies_Player_PlayerId",
                table: "Armies",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenCommand_Armies_ArmyId",
                table: "ChosenCommand",
                column: "ArmyId",
                principalTable: "Armies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenCommand_Commands_CommandId",
                table: "ChosenCommand",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
