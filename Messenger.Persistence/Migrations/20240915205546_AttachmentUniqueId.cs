using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messenger.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AttachmentUniqueId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Attachments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)"
            );

            migrationBuilder.AddColumn<string>(
                name: "UniqueId",
                table: "Attachments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.Sql("UPDATE Attachments SET UniqueId = NEWID()");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_Type",
                table: "Attachments",
                column: "Type"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_UniqueId",
                table: "Attachments",
                column: "UniqueId",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_Attachments_Type", table: "Attachments");

            migrationBuilder.DropIndex(name: "IX_Attachments_UniqueId", table: "Attachments");

            migrationBuilder.DropColumn(name: "UniqueId", table: "Attachments");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)"
            );
        }
    }
}
