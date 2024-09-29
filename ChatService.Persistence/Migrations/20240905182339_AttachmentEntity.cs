using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatService.Persistence.Migrations;

/// <inheritdoc />
public partial class AttachmentEntity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Attachments",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                MessageId = table.Column<int>(type: "int", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Attachments", x => x.Id);
                table.ForeignKey(
                    name: "FK_Attachments_Messages_MessageId",
                    column: x => x.MessageId,
                    principalTable: "Messages",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Attachments_MessageId",
            table: "Attachments",
            column: "MessageId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Attachments");
    }
}
