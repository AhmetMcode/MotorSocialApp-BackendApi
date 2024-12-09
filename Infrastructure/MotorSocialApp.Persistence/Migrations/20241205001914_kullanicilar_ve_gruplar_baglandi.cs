using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorSocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class kullanicilar_ve_gruplar_baglandi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ChatGroups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatGroups_UserId",
                table: "ChatGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatGroups_AspNetUsers_UserId",
                table: "ChatGroups",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatGroups_AspNetUsers_UserId",
                table: "ChatGroups");

            migrationBuilder.DropIndex(
                name: "IX_ChatGroups_UserId",
                table: "ChatGroups");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChatGroups");
        }
    }
}
