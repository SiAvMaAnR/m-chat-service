using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Persistence.Migrations;

/// <inheritdoc />
public partial class RenameParentMessageProp : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Messages_Messages_TargetMessageId",
            table: "Messages");

        migrationBuilder.DropColumn(
            name: "AIProfileName",
            table: "Channels");

        migrationBuilder.RenameColumn(
            name: "TargetMessageId",
            table: "Messages",
            newName: "ParentMessageId");

        migrationBuilder.RenameIndex(
            name: "IX_Messages_TargetMessageId",
            table: "Messages",
            newName: "IX_Messages_ParentMessageId");

        migrationBuilder.AddForeignKey(
            name: "FK_Messages_Messages_ParentMessageId",
            table: "Messages",
            column: "ParentMessageId",
            principalTable: "Messages",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Messages_Messages_ParentMessageId",
            table: "Messages");

        migrationBuilder.RenameColumn(
            name: "ParentMessageId",
            table: "Messages",
            newName: "TargetMessageId");

        migrationBuilder.RenameIndex(
            name: "IX_Messages_ParentMessageId",
            table: "Messages",
            newName: "IX_Messages_TargetMessageId");

        migrationBuilder.AddColumn<string>(
            name: "AIProfileName",
            table: "Channels",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Messages_Messages_TargetMessageId",
            table: "Messages",
            column: "TargetMessageId",
            principalTable: "Messages",
            principalColumn: "Id");
    }
}
