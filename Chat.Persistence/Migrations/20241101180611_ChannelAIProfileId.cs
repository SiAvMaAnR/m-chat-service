using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Persistence.Migrations;

/// <inheritdoc />
public partial class ChannelAIProfileId : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "RefreshTokens");

        migrationBuilder.AddColumn<int>(
            name: "AIProfileId",
            table: "Channels",
            type: "int",
            nullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "ChannelId",
            table: "Attachments",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Messages_IsDeleted",
            table: "Messages",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_Messages_IsRead",
            table: "Messages",
            column: "IsRead");

        migrationBuilder.CreateIndex(
            name: "IX_Channels_AIProfileId",
            table: "Channels",
            column: "AIProfileId");

        migrationBuilder.CreateIndex(
            name: "IX_Channels_IsDeleted",
            table: "Channels",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_Attachments_ChannelId",
            table: "Attachments",
            column: "ChannelId");

        migrationBuilder.CreateIndex(
            name: "IX_Attachments_IsDeleted",
            table: "Attachments",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_Attachments_OwnerId",
            table: "Attachments",
            column: "OwnerId");

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_IsActive",
            table: "Accounts",
            column: "IsActive");

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_IsBanned",
            table: "Accounts",
            column: "IsBanned");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_Messages_IsDeleted",
            table: "Messages");

        migrationBuilder.DropIndex(
            name: "IX_Messages_IsRead",
            table: "Messages");

        migrationBuilder.DropIndex(
            name: "IX_Channels_AIProfileId",
            table: "Channels");

        migrationBuilder.DropIndex(
            name: "IX_Channels_IsDeleted",
            table: "Channels");

        migrationBuilder.DropIndex(
            name: "IX_Attachments_ChannelId",
            table: "Attachments");

        migrationBuilder.DropIndex(
            name: "IX_Attachments_IsDeleted",
            table: "Attachments");

        migrationBuilder.DropIndex(
            name: "IX_Attachments_OwnerId",
            table: "Attachments");

        migrationBuilder.DropIndex(
            name: "IX_Accounts_IsActive",
            table: "Accounts");

        migrationBuilder.DropIndex(
            name: "IX_Accounts_IsBanned",
            table: "Accounts");

        migrationBuilder.DropColumn(
            name: "AIProfileId",
            table: "Channels");

        migrationBuilder.AlterColumn<int>(
            name: "ChannelId",
            table: "Attachments",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.CreateTable(
            name: "RefreshTokens",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AccountId = table.Column<int>(type: "int", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                table.ForeignKey(
                    name: "FK_RefreshTokens_Accounts_AccountId",
                    column: x => x.AccountId,
                    principalTable: "Accounts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_RefreshTokens_AccountId",
            table: "RefreshTokens",
            column: "AccountId");
    }
}
