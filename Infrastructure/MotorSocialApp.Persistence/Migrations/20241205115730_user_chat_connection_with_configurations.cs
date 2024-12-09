using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorSocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class user_chat_connection_with_configurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChatGroupConnections_ChatGroups_ChatGroupId",
                table: "UserChatGroupConnections");

            migrationBuilder.DropIndex(
                name: "IX_UserChatGroupConnections_ChatGroupId",
                table: "UserChatGroupConnections");

            migrationBuilder.DropColumn(
                name: "ChatGroupId",
                table: "UserChatGroupConnections");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ChatGroups_UniqueId",
                table: "ChatGroups",
                column: "UniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChatGroupConnections_ChatGroupUniqueId",
                table: "UserChatGroupConnections",
                column: "ChatGroupUniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChatGroupConnections_ChatGroups_ChatGroupUniqueId",
                table: "UserChatGroupConnections",
                column: "ChatGroupUniqueId",
                principalTable: "ChatGroups",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChatGroupConnections_ChatGroups_ChatGroupUniqueId",
                table: "UserChatGroupConnections");

            migrationBuilder.DropIndex(
                name: "IX_UserChatGroupConnections_ChatGroupUniqueId",
                table: "UserChatGroupConnections");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ChatGroups_UniqueId",
                table: "ChatGroups");

            migrationBuilder.AddColumn<int>(
                name: "ChatGroupId",
                table: "UserChatGroupConnections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserChatGroupConnections_ChatGroupId",
                table: "UserChatGroupConnections",
                column: "ChatGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChatGroupConnections_ChatGroups_ChatGroupId",
                table: "UserChatGroupConnections",
                column: "ChatGroupId",
                principalTable: "ChatGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
