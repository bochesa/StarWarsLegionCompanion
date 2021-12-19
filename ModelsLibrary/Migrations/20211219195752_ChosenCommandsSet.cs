using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityLibrary.Migrations
{
    public partial class ChosenCommandsSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChosenCommand_Armies_ArmyId",
                table: "ChosenCommand");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenCommand_Commands_CommandId",
                table: "ChosenCommand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChosenCommand",
                table: "ChosenCommand");

            migrationBuilder.RenameTable(
                name: "ChosenCommand",
                newName: "ChosenCommands");

            migrationBuilder.RenameIndex(
                name: "IX_ChosenCommand_CommandId",
                table: "ChosenCommands",
                newName: "IX_ChosenCommands_CommandId");

            migrationBuilder.RenameIndex(
                name: "IX_ChosenCommand_ArmyId",
                table: "ChosenCommands",
                newName: "IX_ChosenCommands_ArmyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChosenCommands",
                table: "ChosenCommands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenCommands_Armies_ArmyId",
                table: "ChosenCommands",
                column: "ArmyId",
                principalTable: "Armies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenCommands_Commands_CommandId",
                table: "ChosenCommands",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChosenCommands_Armies_ArmyId",
                table: "ChosenCommands");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenCommands_Commands_CommandId",
                table: "ChosenCommands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChosenCommands",
                table: "ChosenCommands");

            migrationBuilder.RenameTable(
                name: "ChosenCommands",
                newName: "ChosenCommand");

            migrationBuilder.RenameIndex(
                name: "IX_ChosenCommands_CommandId",
                table: "ChosenCommand",
                newName: "IX_ChosenCommand_CommandId");

            migrationBuilder.RenameIndex(
                name: "IX_ChosenCommands_ArmyId",
                table: "ChosenCommand",
                newName: "IX_ChosenCommand_ArmyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChosenCommand",
                table: "ChosenCommand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenCommand_Armies_ArmyId",
                table: "ChosenCommand",
                column: "ArmyId",
                principalTable: "Armies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
