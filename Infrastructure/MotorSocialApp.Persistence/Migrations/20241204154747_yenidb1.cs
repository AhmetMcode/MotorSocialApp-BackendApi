using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorSocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class yenidb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatGroups_AspNetUsers_GroupAdminId",
                table: "ChatGroups");

            migrationBuilder.DropIndex(
                name: "IX_ChatGroups_GroupAdminId",
                table: "ChatGroups");

            migrationBuilder.DropColumn(
                name: "GroupAdminId",
                table: "ChatGroups");

            migrationBuilder.DropColumn(
                name: "UserIds",
                table: "ChatGroups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupAdminId",
                table: "ChatGroups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserIds",
                table: "ChatGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ChatGroups_GroupAdminId",
                table: "ChatGroups",
                column: "GroupAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatGroups_AspNetUsers_GroupAdminId",
                table: "ChatGroups",
                column: "GroupAdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
