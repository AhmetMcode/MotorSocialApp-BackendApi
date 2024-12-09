using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorSocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserChatGroupConnections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatGroupUniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChatGroupConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChatGroupConnections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChatGroupConnections_ChatGroups_ChatGroupId",
                        column: x => x.ChatGroupId,
                        principalTable: "ChatGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserChatGroupConnections_ChatGroupId",
                table: "UserChatGroupConnections",
                column: "ChatGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChatGroupConnections_UserId",
                table: "UserChatGroupConnections",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChatGroupConnections");
        }
    }
}
